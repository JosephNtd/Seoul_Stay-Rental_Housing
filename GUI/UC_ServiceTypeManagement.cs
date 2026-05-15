using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap_Form
{
    public partial class UC_ServiceTypeManagement : UserControl
    {
        private readonly BUS_ServiceType _bus = new BUS_ServiceType();
        private List<ET_ServiceType> _allData;

        private string _mode = "";
        private long _currentId = 0;
        private string _selectedImagePath = ""; // Lưu tạm đường dẫn ảnh khi User Browse file
        public UC_ServiceTypeManagement()
        {
            InitializeComponent();
        }

        private void UC_ServiceType_Load(object sender, EventArgs e)
        {
            HideDetailPanel();
            LoadData();
            LoadComboBox();

            txtSearch.EditValueChanged += Filters;
            cboSort.EditValueChanged += Filters;

            // Gán sự kiện Grid
            gvServiceType.DoubleClick += gvServiceType_DoubleClick;
            repoBtnActions.ButtonClick += repoBtnActions_ButtonClick;

            // Gán sự kiện cho Icon PictureEdit (Click để đổi ảnh)
            picIcon.Click += picIcon_Click;
            
        }
        private void LoadData()
        {
            _allData = _bus.GetData();

            ET_ServiceType.DefaultIcon = Properties.Resources.WSC2022SE_TP09_Logo_actual_en1;
            gcServiceType.DataSource = _allData;
            gvServiceType.RefreshData();

            // Ẩn cột không cần thiết
            if (gvServiceType.Columns["ID"] != null) gvServiceType.Columns["ID"].Visible = false;
            if (gvServiceType.Columns["GUID"] != null) gvServiceType.Columns["GUID"].Visible = false;
            if (gvServiceType.Columns["IconPath"] != null) gvServiceType.Columns["IconPath"].Visible = false; // Đã hiển thị qua ImageDisplay
        }
        private void LoadComboBox()
        {
            // Sort
            cboSort.Properties.Items.Clear();
            cboSort.Properties.NullText = "---Sort by---";
            cboSort.Properties.Items.AddRange(new string[] { "Name (A - Z)", "Name (Z - A)"});
            cboSort.SelectedIndex = -1;
            cboSort.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

        }
        // QUẢN LÝ TRẠNG THÁI PANEL CHI TIẾT
        private void ShowDetailPanel()
        {
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            splitContainerControl1.SplitterPosition = this.Width - 550;
        }

        private void HideDetailPanel()
        {
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            _mode = "";
            _currentId = 0;
            _selectedImagePath = "";
        }

        private void SetUIState(string mode, ET_ServiceType data = null)
        {
            _mode = mode;
            ShowDetailPanel();
            _selectedImagePath = ""; // Reset đường dẫn ảnh mới

            bool isMapping = (mode == "ADD" || mode == "EDIT");
            txtName.Enabled = isMapping;
            txtDescription.Enabled = isMapping;
            picIcon.Properties.ReadOnly = !isMapping; // Tắt tính năng chọn ảnh nếu là VIEW

            btnSave.Visible = isMapping;
            btnCancel.Visible = isMapping;

            if (mode == "ADD")
            {
                _currentId = 0;
                lblDetailTitle.Text = "Add Item Type";
                txtName.Text = "";
                txtDescription.Text = "";
                picIcon.Image = null; // Trống ảnh
            }
            else if (data != null)
            {
                _currentId = data.ID;
                lblDetailTitle.Text = (mode == "EDIT") ? "Edit Item Type" : "View Details";
                txtName.Text = data.Name;
                txtDescription.Text = data.Description;

                // Hiển thị ảnh hiện tại
                picIcon.Image = data.Icon;
            }
        }

        // ==========================================
        // XỬ LÝ CHỌN ẢNH (BROWSE IMAGE)
        // ==========================================
        private void picIcon_Click(object sender, EventArgs e)
        {
            if (_mode == "VIEW") return;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp; *.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Select Icon Image";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    picIcon.Image = Image.FromFile(_selectedImagePath); // Show ảnh xem thử
                }
            }
        }

        // VALIDATE VÀ LƯU DỮ LIỆU
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }
            string name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                XtraMessageBox.Show("Vui lòng nhập Tên loại chỗ nghỉ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (_bus.IsNameExists(name, _currentId))
            {
                XtraMessageBox.Show("Tên này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xử lý lưu ảnh vào thư mục Images
            string iconFileName = null;
            if (!string.IsNullOrEmpty(_selectedImagePath))
            {
                // Tạo tên file ngẫu nhiên để tránh trùng
                string ext = Path.GetExtension(_selectedImagePath);
                iconFileName = $"{Guid.NewGuid()}{ext}";
                string destFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

                if (!Directory.Exists(destFolder)) Directory.CreateDirectory(destFolder);

                string destPath = Path.Combine(destFolder, iconFileName);
                File.Copy(_selectedImagePath, destPath, true);
            }

            // Gói dữ liệu
            ET_ServiceType et = new ET_ServiceType
            {
                ID = _currentId,
                Name = name,
                Description = txtDescription.Text.Trim()
            };

            bool success = (_mode == "ADD")
                ? _bus.Insert(et, iconFileName)
                : _bus.Update(et, iconFileName);

            if (success)
            {
                XtraMessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HideDetailPanel();
                LoadData();
            }
        }

        // CÁC SỰ KIỆN TRÊN GRIDVIEW
        private void gvServiceType_DoubleClick(object sender, EventArgs e)
        {
            var data = gvServiceType.GetFocusedRow() as ET_ServiceType;
            if (data != null) SetUIState("VIEW", data);
        }

        private void repoBtnActions_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var data = gvServiceType.GetFocusedRow() as ET_ServiceType;
            if (data == null) return;

            if (e.Button.Tag.ToString() == "edit")
            {
                SetUIState("EDIT", data);
            }
            else if (e.Button.Tag.ToString() == "delete")
            {
                if (XtraMessageBox.Show($"Xóa loại: {data.Name}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (_bus.Delete(data.ID))
                    {
                        LoadData();
                    }
                    else
                    {
                        XtraMessageBox.Show("Không thể xóa do loại chỗ nghỉ này đang được sử dụng ở các Item khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // FILTER
        private void Filters(object sender, EventArgs e)
        {
            if (_allData == null) return;

            IEnumerable<ET_ServiceType> filtered = _allData;

            // Search
            string keyword = txtSearch.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(x =>
                    !string.IsNullOrEmpty(x.Name) &&
                    x.Name.ToLower().Contains(keyword));
            }
            // Sort
            string sortOption = cboSort.Text;

            switch (sortOption)
            {
                case "Name (A - Z)":
                    filtered = filtered.OrderBy(x => x.Name);
                    break;

                case "Name (Z - A)":
                    filtered = filtered.OrderByDescending(x => x.Name);
                    break;

            }

            gcServiceType.DataSource = filtered.ToList();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
            cboSort.SelectedIndex = -1;
            Filters(null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _mode = "ADD";
            SetUIState(_mode);
            ShowDetailPanel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            picIcon.EditValue = null;
            txtName.Text = "";
            txtDescription.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            HideDetailPanel();
        }
        private bool ValidateData()
        {
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();

            // 1. RÀNG BUỘC RỖNG (EMPTY)
            if (string.IsNullOrWhiteSpace(name))
            {
                XtraMessageBox.Show("Tên loại chỗ nghỉ (Item Type) không được để trống!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // 2. BIÊN DƯỚI (MIN LENGTH)
            // Tên loại thường phải có ý nghĩa, hiếm khi dưới 3 ký tự (Ví dụ: "Nhà", "Lều", "Villa")
            if (name.Length < 3)
            {
                XtraMessageBox.Show("Tên loại chỗ nghỉ quá ngắn (Tối thiểu 3 ký tự)!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // 3. BIÊN TRÊN (MAX LENGTH - Dựa theo DB)
            // DB cho phép Name nvarchar(50)
            if (name.Length > 50)
            {
                XtraMessageBox.Show("Tên loại chỗ nghỉ quá dài (Tối đa 50 ký tự)!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // DB cho phép Description nvarchar(500)
            if (description.Length > 500)
            {
                XtraMessageBox.Show("Mô tả quá dài (Tối đa 500 ký tự)!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            // 4. KÝ TỰ ĐẶC BIỆT & SỐ (REGEX)
            // Chỉ cho phép chữ (kể cả Tiếng Việt), số, khoảng trắng và các dấu câu cơ bản (, . -)
            // Chặn các ký tự như @, #, $, %, ^, &, *, <, >, !, ?
            var regexName = new Regex(@"^[a-zA-Z0-9\s,.\-À-ỹ]+$");
            if (!regexName.IsMatch(name))
            {
                XtraMessageBox.Show("Tên loại chỗ nghỉ không hợp lệ! Không được chứa ký tự đặc biệt lạ.", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // 5. TRÙNG LẶP DỮ LIỆU (DUPLICATE)
            if (_bus.IsNameExists(name, _currentId))
            {
                XtraMessageBox.Show("Tên loại chỗ nghỉ này đã tồn tại trong hệ thống. Vui lòng nhập tên khác!", "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            return true;
        }
    }
}
