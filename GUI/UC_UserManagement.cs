using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DangNhap_Form
{
    public partial class UC_UserManagement : UserControl
    {
        private readonly BUS_User _busUser = new BUS_User();
        private List<DTO_UserDisplay> _allUsers;
        private string _mode = "";
        private long _currentUserId = 0;

        public UC_UserManagement()
        {
            InitializeComponent();
        }

        private void UC_UserManagement_Load(object sender, EventArgs e)
        {
            HideDetailPanel();
            txtSearch.EditValueChanged += FilterUsers;

            cboRole.EditValueChanged += FilterUsers;
            cboStatus.EditValueChanged += FilterUsers;

            repoBtnActions.ButtonClick += repoBtnActions_ButtonClick;
            gvUsers.DoubleClick += gvUsers_DoubleClick;

            LoadUserData();
            LoadComboBox(); // Khởi tạo dữ liệu cho tất cả ComboBox lọc và nhập liệu
        }

        private void LoadUserData()
        {
            _allUsers = _busUser.GetAllUsersDisplay();
            gcUsers.DataSource = _allUsers;

            if (gvUsers.Columns["UserID"] != null)
                gvUsers.Columns["UserID"].Visible = false;
        }

        private void LoadComboBox()
        {
            // 1. Cấu hình Combobox Bộ Lọc (Filter ở thanh top)
            var rolesList = new string[] { "Administrator", "Host", "Guest" };
            cboRole.Properties.Items.AddRange(rolesList);
            cboStatus.Properties.Items.AddRange(new string[] { "Active", "Locked" });

            cboRole.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cboStatus.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cboRole.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;

            // 2. Cấu hình LookUpEdit trong Panel Nhập liệu (cboAddEditRole)
            cboAddEditRole.Properties.DataSource = rolesList.Select(r => new { RoleName = r }).ToList();
            cboAddEditRole.Properties.DisplayMember = "RoleName";
            cboAddEditRole.Properties.ValueMember = "RoleName";

            // Tạo cột hiển thị tường minh cho LookUpEdit trực quan
            cboAddEditRole.Properties.Columns.Clear();
            cboAddEditRole.Properties.Columns.Add(new LookUpColumnInfo("RoleName", "Chọn vai trò"));
            cboAddEditRole.Properties.NullText = "-- Chọn Vai Trò --";
        }

        private void FilterUsers(object sender, EventArgs e)
        {
            if (_allUsers == null) return;

            IEnumerable<DTO_UserDisplay> filtered = _allUsers;
            string keyword = txtSearch.Text?.Trim().ToLower() ?? "";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filtered = filtered.Where(u =>
                    (u.FullName ?? "").ToLower().Contains(keyword) ||
                    (u.Email ?? "").ToLower().Contains(keyword) ||
                    (u.Role ?? "").ToLower().Contains(keyword) ||
                    (u.Status ?? "").ToLower().Contains(keyword));
            }

            if (cboRole.EditValue != null)
            {
                filtered = filtered.Where(u => u.Role == cboRole.EditValue.ToString());
            }

            if (cboStatus.EditValue != null)
            {
                filtered = filtered.Where(u => u.Status == cboStatus.EditValue.ToString());
            }

            gcUsers.DataSource = filtered.ToList();
        }

        private void repoBtnActions_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var row = gvUsers.GetFocusedRow() as DTO_UserDisplay;
            if (row == null) return;

            switch (e.Button.Tag.ToString())
            {
                case "edit":
                    SetUIState("EDIT", row);
                    break;
                case "lock":
                    string actionText = row.Status.Trim() == "Active" ? "KHÓA" : "MỞ KHÓA";

                    if (XtraMessageBox.Show($"Bạn có chắc chắn muốn {actionText} tài khoản của [{row.FullName}] không?",
                                            "Xác nhận thay đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_busUser.ToggleLock(row.UserID))
                        {
                            XtraMessageBox.Show($"Đã {actionText.ToLower()} tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserData();
                        }
                    }
                    break;

                case "delete":
                    if (XtraMessageBox.Show($"Bạn có chắc chắn muốn XÓA người dùng [{row.FullName}]?\nHành động này không thể hoàn tác!",
                                            "Cảnh báo xóa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (_busUser.DeleteUser(row.UserID))
                        {
                            XtraMessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserData();
                        }
                    }
                    break;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
            cboRole.EditValue = null;
            cboStatus.EditValue = null;
            gcUsers.DataSource = _allUsers;
        }

        private void ShowDetailPanel()
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            splitContainerControl1.SplitterPosition = this.Width - 450;
        }

        private void HideDetailPanel()
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            _mode = "";
            _currentUserId = 0;
        }

        private void gvUsers_DoubleClick(object sender, EventArgs e)
        {
            var data = gvUsers.GetFocusedRow() as DTO_UserDisplay;
            if (data != null) SetUIState("VIEW", data);
        }

        private void SetUIState(string mode, DTO_UserDisplay data = null)
        {
            _mode = mode;
            ShowDetailPanel();

            bool isEditable = (mode == "ADD" || mode == "EDIT");

            txtName.Enabled = isEditable;
            txtEmail.Enabled = isEditable;
            cboAddEditRole.Enabled = isEditable; // Cho phép hoặc khóa quyền chọn combobox vai trò

            btnSave.Visible = isEditable;
            btnCancel.Visible = isEditable;

            if (mode == "ADD")
            {
                _currentUserId = 0;
                lblDetailTitle.Text = "THÊM NGƯỜI DÙNG";
                txtName.Text = "";
                txtEmail.Text = "";
                txtUsername.Text = "";
                txtPassword.Text = "";
                cboAddEditRole.EditValue = null; // Trả về trạng thái trống ban đầu
            }
            else if (data != null)
            {
                _currentUserId = data.UserID;
                lblDetailTitle.Text = (mode == "EDIT") ? "SỬA NGƯỜI DÙNG" : "CHI TIẾT NGƯỜI DÙNG";

                txtName.Text = data.FullName;
                txtEmail.Text = data.Email;
                cboAddEditRole.EditValue = data.Role?.Trim(); // Đổ dữ liệu vai trò hiện tại vào Combobox
                txtUsername.Text = data.Username;
                txtUsername.Enabled = false;
                txtPassword.Text = data.Password;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetUIState("ADD");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_mode == "EDIT")
            {
                var row = gvUsers.GetFocusedRow() as DTO_UserDisplay;
                if (row != null) SetUIState("EDIT", row);
            }
            else if (_mode == "ADD")
            {
                txtName.Text = "";
                txtEmail.Text = "";
                cboAddEditRole.EditValue = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            HideDetailPanel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu hợp lệ (gồm cả việc chọn combobox vai trò)
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cboAddEditRole.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ Tên, Email và Chọn vai trò cho người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gom dữ liệu bằng DTO_User (Đúng luật 3 lớp, không reference DAL)
            DTO_User user = new DTO_User
            {
                ID = _currentUserId,
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                FullName = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            string selectedRole = cboAddEditRole.EditValue.ToString();

            bool success = false;
            if (_mode == "ADD")
            {
                success = _busUser.InsertUser(user, selectedRole);
            }
            else if (_mode == "EDIT")
            {
                success = _busUser.UpdateUser(user, selectedRole);
            }

            // 3. Phản hồi kết quả lên View
            if (success)
            {
                XtraMessageBox.Show("Lưu dữ liệu người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserData();
                HideDetailPanel();
            }
            else
            {
                XtraMessageBox.Show("Có lỗi xảy ra trong quá trình lưu, vui lòng kiểm tra lại dữ liệu (Email trùng lặp)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if(chkShow.CheckState == CheckState.Checked)
                txtPassword.Properties.UseSystemPasswordChar = false;
            else
                txtPassword.Properties.UseSystemPasswordChar = true;
        }
    }
}