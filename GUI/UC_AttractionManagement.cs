using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DTO;
using ET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap_Form
{
    public partial class UC_AttractionManagement : UserControl
    {
        private readonly BUS_Attraction _bus = new BUS_Attraction();
        private readonly BUS_Area _busArea = new BUS_Area();
        private List<DTO_AttractionDisplay> _allData;
        private string _mode = "";
        private long _currentId = 0;
        public UC_AttractionManagement()
        {
            InitializeComponent();
        }

        private void UC_AttractionManagement_Load(object sender, EventArgs e)
        {
            repoBtnActions.ButtonClick += repoBtnActions_ButtonClick;

            gvAttraction.DoubleClick += gvAttraction_DoubleClick;

            btnClose.Click += btnClose_Click;

            splitContainerControl1.FixedPanel =
                SplitFixedPanel.Panel2;

            splitContainerControl1.PanelVisibility =
                SplitPanelVisibility.Panel1;

            splitContainerControl1.Panel2.MinSize = 320;

            LoadData();
            LoadCombobox();

            txtSearch.EditValueChanged += Filters;
            cboSort.EditValueChanged += Filters;
            cboArea.EditValueChanged += Filters;
        }
        private void LoadData()
        {
            _allData = _bus.GetAllWithAreaName();

            lblSubtitle.Text = $"Manage {_allData.Count().ToString()} landmarks across {_busArea.GetData().Count().ToString()} Seoul districts.";

            gcAttraction.DataSource = null;
            gcAttraction.DataSource = _allData;

            gvAttraction.RefreshData();

            if (gvAttraction.Columns["AreaID"] != null)
                gvAttraction.Columns["AreaID"].Visible = false;
            if (gvAttraction.Columns["GUID"] != null)
                gvAttraction.Columns["GUID"].Visible = false;
            if (gvAttraction.Columns["ID"] != null)
                gvAttraction.Columns["ID"].Visible = false;

        }

        private void LoadCombobox()
        {
            cboSort.Properties.Items.AddRange(new string[]
            {
                "Sort by Name - Ascending",
                "Sort by Name - Descending",
            });
            cboSort.Properties.NullText = "---Sort by---";

            cboSort.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cboSort.SelectedIndex = -1;

            var areaList = _busArea.GetAreasName();
            areaList.Insert(0, new ET_Areas { ID = 0, Name = "--- All Areas ---" });

            cboArea.Properties.DataSource = areaList;
            cboArea.Properties.DisplayMember = "Name";
            cboArea.Properties.ValueMember = "ID";

            cboArea.Properties.PopulateColumns();

            if (cboArea.Properties.Columns["ID"] != null) cboArea.Properties.Columns["ID"].Visible = false;
            if (cboArea.Properties.Columns["GUID"] != null) cboArea.Properties.Columns["GUID"].Visible = false;
            cboArea.Properties.NullText = "--- Select Area ---";

            // ADD/EDIT AREA COMBO

            cboAddEditArea.Properties.DataSource =
                areaList.Where(x => x.ID != 0).ToList();

            cboAddEditArea.Properties.DisplayMember = "Name";
            cboAddEditArea.Properties.ValueMember = "ID";

            cboAddEditArea.Properties.PopulateColumns();

            if (cboAddEditArea.Properties.Columns["ID"] != null)
                cboAddEditArea.Properties.Columns["ID"].Visible = false;

            if (cboAddEditArea.Properties.Columns["GUID"] != null)
                cboAddEditArea.Properties.Columns["GUID"].Visible = false;
        }
        private void Filters(object sender, EventArgs e)
        {
            if (_allData == null) return;

            IEnumerable<DTO_AttractionDisplay> filteredData = _allData;

            // Search
            string keyword = txtSearch.Text?.Trim().ToLower() ?? "";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filteredData = filteredData.Where(a =>
                    (a.AttractionName ?? "").ToLower().Contains(keyword) ||
                    (a.Address ?? "").ToLower().Contains(keyword) ||
                    a.AreaName.ToLower().Contains(keyword));
            }

            long? selectedAreaId = cboArea.EditValue as long?;
            if (selectedAreaId.HasValue && selectedAreaId.Value > 0)
            {
                filteredData = filteredData.Where(a => a.AreaID == selectedAreaId.Value);
            }

            switch (cboSort.Text)
            {
                case "Sort by Name - Ascending":
                    filteredData = filteredData.OrderBy(x => x.AttractionName).ToList();
                    break;
                case "Sort by Name - Descending":
                    filteredData = filteredData.OrderByDescending(x => x.AttractionName).ToList();
                    break;
            }

            gcAttraction.DataSource = filteredData.ToList();
            gvAttraction.RefreshData();
        }

        private void repoBtnActions_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var row = gvAttraction.GetFocusedRow() as DTO_AttractionDisplay;

            if (row == null) return;

            switch (e.Button.Tag.ToString())
            {
                case "edit":

                    LoadDetailData(row);

                    SetEditMode();

                    ShowDetailPanel();

                    break;

                case "delete":
                    DialogResult dialogResult = XtraMessageBox.Show(
                $"Bạn có chắc chắn muốn xóa điểm tham quan '{row.AttractionName}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        bool isSuccess = _bus.Delete(row.ID); // Gọi BUS để xóa theo ID
                        if (isSuccess)
                        {
                            XtraMessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Load lại lưới dữ liệu
                        }
                        else
                        {
                            XtraMessageBox.Show("Xóa thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
            cboSort.EditValue = null;
            cboArea.EditValue = 0;

            gcAttraction.DataSource = _allData;
            gvAttraction.RefreshData();
        }

        private void ShowDetailPanel()
        {
            splitContainerControl1.PanelVisibility =
                SplitPanelVisibility.Both;

            splitContainerControl1.SplitterPosition =
                this.Width - 1250;
        }

        private void HideDetailPanel()
        {
            splitContainerControl1.PanelVisibility =
                SplitPanelVisibility.Panel1;
        }

        private void SetAddMode()
        {
            _mode = "ADD";

            _currentId = 0;

            txtName.Text = "";
            txtAddress.Text = "";
            cboAddEditArea.EditValue = null;

            txtName.Enabled = true;
            txtAddress.Enabled = true;
            cboAddEditArea.Enabled = true;

            btnSave.Visible = true;
            btnSave.Text = "Create";

            btnCancel.Visible = true;
        }

        private void SetEditMode()
        {
            _mode = "EDIT";

            txtName.Enabled = true;
            txtAddress.Enabled = true;
            cboAddEditArea.Enabled = true;

            btnSave.Visible = true;
            btnSave.Text = "Update";

            btnCancel.Visible = true;
        }

        private void SetViewMode()
        {
            _mode = "VIEW";

            txtName.Enabled = false;
            txtAddress.Enabled = false;
            cboAddEditArea.Enabled = false;

            btnSave.Visible = false;

            btnCancel.Visible = false;
        }


        private void LoadDetailData(DTO_AttractionDisplay row)
        {
            _currentId = row.ID;

            txtName.Text = row.AttractionName;

            txtAddress.Text = row.Address;

            cboAddEditArea.EditValue =
                row.AreaID;
        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            SetAddMode();

            ShowDetailPanel();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            HideDetailPanel();
        }

        private void gvAttraction_DoubleClick(object sender, EventArgs e)
        {
            var row =
                gvAttraction.GetFocusedRow()
                as DTO_AttractionDisplay;

            if (row == null) return;

            LoadDetailData(row);

            SetViewMode();

            ShowDetailPanel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Nếu kiểm tra không qua -> Dừng luôn, không cho gọi hàm Insert/Update
            if (!ValidateData())
            {
                return;
            }
            string name = txtName.Text.ToString();
            string address = txtAddress.Text.ToString();
            long areaID = (long)cboAddEditArea.EditValue;
            ET_Attractions et = new ET_Attractions
            {
                ID = _currentId,
                AreaID = Convert.ToInt64(cboAddEditArea.EditValue),
                AttractionName = txtName.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };
            if (_mode == "ADD")
            {
                bool isSuccessAdd = _bus.Insert(et);
                if (isSuccessAdd)
                {
                    XtraMessageBox.Show(
                        "Thêm thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadData();
                    HideDetailPanel();
                }
                else
                {
                    XtraMessageBox.Show(
                        "Thêm thất bại!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else if (_mode == "EDIT")
            {
                DialogResult dialogResult = XtraMessageBox.Show(
                    $"Bạn có chắc chắn muốn cập nhật '{name}' không?",
                    "Xác nhận cập nhật",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    bool isSuccessEdit = _bus.Update(et);
                    if (isSuccessEdit)
                    {
                        XtraMessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Load lại lưới dữ liệu
                    }
                    else
                    {
                        XtraMessageBox.Show("Sửa thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            LoadData();
        }


        private bool ValidateData()
        {
            string name = txtName.Text.Trim();
            string address = txtAddress.Text.Trim();

            // Ép kiểu AreaID an toàn
            long areaId = cboAddEditArea.EditValue == null ? 0 : Convert.ToInt64(cboAddEditArea.EditValue);

            // 1. RÀNG BUỘC RỖNG (EMPTY)
            if (string.IsNullOrWhiteSpace(name))
            {
                XtraMessageBox.Show("Tên địa điểm không được để trống!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                XtraMessageBox.Show("Địa chỉ không được để trống!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (areaId == 0) // AreaID = 0 tương đương với chưa chọn
            {
                XtraMessageBox.Show("Vui lòng chọn Khu vực (Area)!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboArea.Focus();
                return false;
            }

            // 2. BIÊN TRÊN (MAX LENGTH)
            if (name.Length > 150)
            {
                XtraMessageBox.Show("Tên địa điểm quá dài (Tối đa 150 ký tự)!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (address.Length > 250)
            {
                XtraMessageBox.Show("Địa chỉ quá dài (Tối đa 250 ký tự)!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            // 3. KÝ TỰ ĐẶC BIỆT (REGEX)
            // Chỉ cho phép: Chữ cái (bao gồm tiếng Việt), Số, Khoảng trắng, và các dấu chấm, phẩy, gạch ngang.
            // Chặn các ký tự gây lỗi SQL Injection hoặc ký tự lạ như: @, #, $, %, ^, &, *, <, >, !, ?
            var regexName = new Regex(@"^[a-zA-Z0-9\s,.\-À-ỹ]+$");

            if (!regexName.IsMatch(name))
            {
                XtraMessageBox.Show("Tên địa điểm không hợp lệ! Không được chứa ký tự đặc biệt lạ (chỉ cho phép chữ, số, dấu phẩy, chấm, gạch ngang).", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // Address thường có sẹc (/) hoặc ngoặc (), nên có thể cho phép nhiều hơn 1 chút
            var regexAddress = new Regex(@"^[a-zA-Z0-9\s,.\-\/()À-ỹ]+$");
            if (!regexAddress.IsMatch(address))
            {
                XtraMessageBox.Show("Địa chỉ chứa ký tự không hợp lệ!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            // 4. BIÊN DƯỚI (MIN LENGTH)
            // Một cái tên địa điểm hoặc địa chỉ thực tế hiếm khi ngắn hơn 3 ký tự.
            if (name.Length < 3)
            {
                XtraMessageBox.Show("Tên địa điểm quá ngắn (Phải có ít nhất 3 ký tự)!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // 5. TRÙNG LẶP DỮ LIỆU (DUPLICATE)
            // Truyền _currentId vào (nếu Form Thêm mới thì _currentId = 0)
            if (_bus.IsNameExists(name, _currentId))
            {
                XtraMessageBox.Show("Tên địa điểm này đã tồn tại trong hệ thống. Vui lòng nhập tên khác!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // Nếu qua hết các ải trên -> Trả về true
            return true;
        }
    }
}
