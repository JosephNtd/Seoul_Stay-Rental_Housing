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
        private List<DTO_UserDisplay> _allUsers; // dữ liệu gốc

        public UC_UserManagement()
        {
            InitializeComponent();
        }

        private void UC_UserManagement_Load(object sender, EventArgs e)
        {
            txtSearch.EditValueChanged += FilterUsers;

            cboRole.EditValueChanged += FilterUsers;
            cboStatus.EditValueChanged += FilterUsers;

            repoBtnActions.ButtonClick += repoBtnActions_ButtonClick;

            LoadUserData();
            LoadComboBox();
        }

        private void LoadUserData()
        {
            _allUsers = _busUser.GetAllUsersDisplay();

            gcUsers.DataSource = _allUsers;
            //gvUsers.PopulateColumns(); 
            // nếu cột chưa được tạo sẵn trong Designer 
            // Ẩn cột UserID nếu cần
            if (gvUsers.Columns["UserID"] != null)
                gvUsers.Columns["UserID"].Visible = false;
            //ApplyFilters();
            gvUsers.Columns["Status"].ColumnEdit = repositoryItemComboBox1;
        }
        private void LoadComboBox()
        {
            cboRole.Properties.Items.AddRange(new string[]
            {
                "Administrator",
                "Host",
                "Guest"
            });

            cboStatus.Properties.Items.AddRange(new string[]
            {
                "Active",
                "Locked",
            });

            cboRole.Properties.TextEditStyle =
                TextEditStyles.DisableTextEditor;

            cboRole.SelectedIndex = -1;

            cboStatus.Properties.TextEditStyle =
                TextEditStyles.DisableTextEditor;

            cboStatus.SelectedIndex = -1;
        }
        private void FilterUsers(object sender, EventArgs e)
        {
            if (_allUsers == null)
                return;

            IEnumerable<DTO_UserDisplay> filtered = _allUsers;

            // SEARCH
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
                string role = cboRole.EditValue.ToString();

                filtered = filtered.Where(u => u.Role == role);
            }

            // STATUS FILTER
            if (cboStatus.EditValue != null)
            {
                string status = cboStatus.EditValue.ToString();

                filtered = filtered.Where(u => u.Status == status);
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
                    XtraMessageBox.Show("Edit nè", "Edit");
                    break;
                case "lock":
                    XtraMessageBox.Show("Lock nè", "Lock");
                    // Đảo trạng thái IsActive
                    break;
                case "delete":
                    XtraMessageBox.Show("Delete nè", "Edit", MessageBoxButtons.YesNoCancel);
                    // Xóa user (ẩn)
                    break;
            }
        }

        private void gvUsers_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IsActive")
            {
                bool isActive = Convert.ToBoolean(e.Value);
                e.DisplayText = isActive ? "Active" : "Locked";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
            cboRole.EditValue = null;
            cboStatus.EditValue = null;

            gcUsers.DataSource = _allUsers;
        }
    }
}