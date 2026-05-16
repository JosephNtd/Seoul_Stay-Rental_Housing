using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DangNhap_Form
{
    public partial class UC_TransactionTypesManagement : UserControl
    {
        private readonly BUS_TransactionType _bus = new BUS_TransactionType();
        private List<ET_TransactionTypes> _allData;
        private string _mode = "";      // "ADD", "EDIT", "VIEW"
        private long _currentId = 0;

        public UC_TransactionTypesManagement()
        {
            InitializeComponent();
        }

        private void UC_TransactionTypesManagement_Load(object sender, EventArgs e)
        {
            // Ẩn panel chi tiết ban đầu
            HideDetailPanel();

            // Load dữ liệu
            LoadData();
            LoadComboBoxSort();

            // Đăng ký sự kiện lọc
            txtSearch.EditValueChanged += Filters;
            cboSort.EditValueChanged += Filters;

            // Sự kiện grid
            gvTransactionTypes.DoubleClick += gvTransactionTypes_DoubleClick;
            repoBtnActions.ButtonClick += repoBtnActions_ButtonClick;

        }

        #region Load Data & Combobox

        private void LoadData()
        {
            _allData = _bus.GetData();
            gcTransactionTypes.DataSource = _allData;
            gvTransactionTypes.RefreshData();

            // Ẩn cột không cần thiết
            if (gvTransactionTypes.Columns["ID"] != null)
                gvTransactionTypes.Columns["ID"].Visible = false;
            if (gvTransactionTypes.Columns["GUID"] != null)
                gvTransactionTypes.Columns["GUID"].Visible = false;
        }

        private void LoadComboBoxSort()
        {
            cboSort.Properties.Items.Clear();
            cboSort.Properties.Items.AddRange(new string[]
            {
                "Name (A - Z)",
                "Name (Z - A)"
            });
            cboSort.SelectedIndex = -1;
            cboSort.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cboSort.Properties.NullText = "--- Sort by ---";
        }

        #endregion

        #region Filter & Sort

        private void Filters(object sender, EventArgs e)
        {
            if (_allData == null) return;

            IEnumerable<ET_TransactionTypes> filtered = _allData;

            // Tìm kiếm theo tên
            string keyword = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filtered = filtered.Where(x => x.Name.ToLower().Contains(keyword));
            }

            // Sắp xếp
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

            gcTransactionTypes.DataSource = filtered.ToList();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
            cboSort.SelectedIndex = -1;
            gcTransactionTypes.DataSource = _allData;
        }

        #endregion

        #region Detail Panel (Add/Edit/View)

        private void ShowDetailPanel()
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            splitContainerControl1.SplitterPosition = this.Width - 500;
        }

        private void HideDetailPanel()
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            _mode = "";
            _currentId = 0;
        }

        private void SetUIState(string mode, ET_TransactionTypes data = null)
        {
            _mode = mode;
            ShowDetailPanel();

            bool isEditable = (mode == "ADD" || mode == "EDIT");
            txtName.Enabled = isEditable;
            btnSave.Visible = isEditable;
            btnCancel.Visible = isEditable;

            if (mode == "ADD")
            {
                _currentId = 0;
                lblDetailTitle.Text = "Add Transaction Type";
                txtName.Text = "";
            }
            else if (data != null)
            {
                _currentId = data.ID;
                lblDetailTitle.Text = (mode == "EDIT") ? "Edit Transaction Type" : "View Details";
                txtName.Text = data.Name;
                if (mode == "VIEW")
                {
                    txtName.Enabled = false;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetUIState("ADD");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            HideDetailPanel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu đã nhập
            txtName.Text = "";
        }

        #endregion

        #region Grid Events (Double click + Action buttons)

        private void gvTransactionTypes_DoubleClick(object sender, EventArgs e)
        {
            var data = gvTransactionTypes.GetFocusedRow() as ET_TransactionTypes;
            if (data != null)
                SetUIState("VIEW", data);
        }

        private void repoBtnActions_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var row = gvTransactionTypes.GetFocusedRow() as ET_TransactionTypes;
            if (row == null) return;

            if (e.Button.Tag.ToString() == "edit")
            {
                SetUIState("EDIT", row);
            }
            else if (e.Button.Tag.ToString() == "delete")
            {
                if (XtraMessageBox.Show($"Are you sure you want to delete '{row.Name}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_bus.Delete(row.ID))
                    {
                        XtraMessageBox.Show("Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        HideDetailPanel();
                    }
                    else
                    {
                        XtraMessageBox.Show("Cannot delete this transaction type. It may be in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Save (Insert/Update)

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            ET_TransactionTypes et = new ET_TransactionTypes
            {
                ID = _currentId,
                Name = txtName.Text.Trim()
            };

            bool success = (_mode == "ADD") ? _bus.Insert(et) : _bus.Update(et);

            if (success)
            {
                XtraMessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HideDetailPanel();
                LoadData();
            }
            else
            {
                XtraMessageBox.Show("Save failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateData()
        {
            string name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                XtraMessageBox.Show("Name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (name.Length < 2 || name.Length > 50)
            {
                XtraMessageBox.Show("Name must be between 2 and 50 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // Kiểm tra ký tự đặc biệt (chỉ cho phép chữ, số, khoảng trắng)
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9\s]+$");
            if (!regex.IsMatch(name))
            {
                XtraMessageBox.Show("Name can only contain letters, numbers and spaces.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // Kiểm tra trùng tên
            if (_bus.IsNameExists(name, _currentId))
            {
                XtraMessageBox.Show("This name already exists. Please choose another.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            return true;
        }

        #endregion
    }
}