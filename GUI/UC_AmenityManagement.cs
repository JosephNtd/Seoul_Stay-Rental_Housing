using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DangNhap_Form
{
    public partial class UC_AmenityManagement : UserControl
    {
        private readonly BUS_Amenity _bus = new BUS_Amenity();
        private List<ET_Amenities> _allData;

        private string _mode = "";
        private long _currentId = 0;
        private string _selectedImagePath = ""; // Lưu đường dẫn file ảnh vừa Browse

        public UC_AmenityManagement()
        {
            InitializeComponent();
        }

        private void UC_AmenityManagement_Load(object sender, EventArgs e)
        {
            HideDetailPanel();
            LoadData();

            // Đăng ký sự kiện
            txtSearch.EditValueChanged += Filters;
            cboSort.EditValueChanged += Filters;

            gvAmenities.DoubleClick += gvAmenities_DoubleClick;
            repoBtnActions.ButtonClick += repoBtnActions_ButtonClick;

            // Xử lý sự kiện cho ảnh và các nút
            picIcon.Click += picIcon_Click;
        }

        private void LoadData()
        {
            _allData = _bus.GetAllData();
            ET_Amenities.DefaultIcon = Properties.Resources.WSC2022SE_TP09_Logo_actual_en1; // Default icon

            gcAmenities.DataSource = _allData;
            gvAmenities.RefreshData();

            if (gvAmenities.Columns["ID"] != null) gvAmenities.Columns["ID"].Visible = false;
            if (gvAmenities.Columns["GUID"] != null) gvAmenities.Columns["GUID"].Visible = false;
            if (gvAmenities.Columns["IconName"] != null) gvAmenities.Columns["IconName"].Visible = false;
        }

        // QUẢN LÝ PANEL (ẢN/HIỆN & TRẠNG THÁI)
        private void ShowDetailPanel()
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            splitContainerControl1.SplitterPosition = this.Width - 350;
        }

        private void HideDetailPanel()
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            _mode = "";
            _currentId = 0;
            _selectedImagePath = "";
        }

        private void SetUIState(string mode, ET_Amenities data = null)
        {
            _mode = mode;
            ShowDetailPanel();
            _selectedImagePath = "";

            bool isEditable = (mode == "ADD" || mode == "EDIT");
            txtName.Enabled = isEditable;
            picIcon.Properties.ReadOnly = !isEditable;

            btnSave.Visible = isEditable;
            btnCancel.Visible = isEditable;

            if (mode == "ADD")
            {
                _currentId = 0;
                lblDetailTitle.Text = "Add Amenity";
                txtName.Text = "";
                picIcon.Image = null;
            }
            else if (data != null)
            {
                _currentId = data.ID;
                lblDetailTitle.Text = (mode == "EDIT") ? "Edit Amenity" : "Amenity Details";
                txtName.Text = data.AmenitiesName;
                picIcon.Image = data.Icon; // Hiển thị ảnh hiện tại
            }
        }

        // Sự kiện dùng cho nút "Thêm Mới" trên giao diện (nếu bạn có thiết kế)
        private void btnAdd_Click(object sender, EventArgs e) => SetUIState("ADD");
        private void btnClose_Click(object sender, EventArgs e) => HideDetailPanel();

        // GRIDVIEW NHẤN ĐÚP & NÚT ACTIONS
        private void gvAmenities_DoubleClick(object sender, EventArgs e)
        {
            var data = gvAmenities.GetFocusedRow() as ET_Amenities;
            if (data != null) SetUIState("VIEW", data);
        }

        private void repoBtnActions_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            // Sửa lỗi: Ép kiểu chuẩn về ET_Amenities thay vì DTO_AreaDisplay
            var row = gvAmenities.GetFocusedRow() as ET_Amenities;
            if (row == null) return;

            if (e.Button.Tag.ToString() == "edit")
            {
                SetUIState("EDIT", row);
            }
            else if (e.Button.Tag.ToString() == "delete")
            {
                if (XtraMessageBox.Show($"Bạn có chắc muốn xóa tiện nghi '{row.AmenitiesName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_bus.Delete(row.ID))
                    {
                        LoadData();
                    }
                    else
                    {
                        XtraMessageBox.Show("Tiện nghi này đang được sử dụng bởi các chỗ nghỉ (Items). Không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // UPLOAD ẢNH & SAVE DỮ LIỆU
        private void picIcon_Click(object sender, EventArgs e)
        {
            if (_mode == "VIEW") return;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Chọn Icon cho Tiện Nghi";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    picIcon.Image = Image.FromFile(_selectedImagePath);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            string iconFileName = null;

            // Nếu người dùng có chọn ảnh mới thì lưu ảnh vào thư mục Images
            if (!string.IsNullOrEmpty(_selectedImagePath))
            {
                string ext = Path.GetExtension(_selectedImagePath);
                iconFileName = $"amenity_{Guid.NewGuid()}{ext}"; // Đặt prefix cho dễ quản lý
                string destFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

                if (!Directory.Exists(destFolder)) Directory.CreateDirectory(destFolder);

                string destPath = Path.Combine(destFolder, iconFileName);
                File.Copy(_selectedImagePath, destPath, true);
            }

            ET_Amenities et = new ET_Amenities
            {
                ID = _currentId,
                AmenitiesName = txtName.Text.Trim()
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
            else
            {
                XtraMessageBox.Show("Lỗi lưu dữ liệu. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // VALIDATION DỮ LIỆU
        private bool ValidateData()
        {
            string name = txtName.Text.Trim();

            // 1. Rỗng
            if (string.IsNullOrWhiteSpace(name))
            {
                XtraMessageBox.Show("Tên tiện nghi không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus(); return false;
            }

            // 2. Biên dưới / Biên trên
            if (name.Length < 2 || name.Length > 50)
            {
                XtraMessageBox.Show("Tên tiện nghi phải từ 2 đến 50 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus(); return false;
            }

            // 3. Ký tự đặc biệt (Chỉ cho chữ, số, khoảng trắng)
            var regexName = new Regex(@"^[a-zA-Z0-9\sÀ-ỹ]+$");
            if (!regexName.IsMatch(name))
            {
                XtraMessageBox.Show("Tên tiện nghi không được chứa ký tự đặc biệt!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus(); return false;
            }

            // 4. Bắt lỗi không có ảnh (Nếu yêu cầu lúc tạo mới bắt buộc phải có ảnh)
            if (_mode == "ADD" && string.IsNullOrEmpty(_selectedImagePath))
            {
                XtraMessageBox.Show("Vui lòng chọn Icon cho tiện nghi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 5. Trùng lặp
            if (_bus.IsNameExists(name, _currentId))
            {
                XtraMessageBox.Show("Tên tiện nghi này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus(); return false;
            }

            return true;
        }

        // LỌC DỮ LIỆU (FILTERS)
        private void Filters(object sender, EventArgs e)
        {
            if (_allData == null) return;
            IEnumerable<ET_Amenities> filteredData = _allData;

            string keyword = txtSearch.Text?.Trim().ToLower() ?? "";
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filteredData = filteredData.Where(a => (a.AmenitiesName ?? "").ToLower().Contains(keyword));
            }

            switch (cboSort.Text)
            {
                case "Sort by Name - Ascending":
                    filteredData = filteredData.OrderBy(x => x.AmenitiesName); break;
                case "Sort by Name - Descending":
                    filteredData = filteredData.OrderByDescending(x => x.AmenitiesName); break;
            }

            gcAmenities.DataSource = filteredData.ToList();
            gvAmenities.RefreshData();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
            cboSort.SelectedIndex = -1;
            Filters(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            picIcon.EditValue = null;
            txtName.Text = "";
        }
    }
}