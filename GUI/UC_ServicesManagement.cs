using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap_Form
{
    public partial class UC_ServicesManagement : UserControl
    {
        private readonly BUS_Services _bus = new BUS_Services();
        private readonly BUS_ServiceType _busType = new BUS_ServiceType();

        private List<ET_Services> _allData;
        private string _mode = "";
        private long _currentId = 0;
        public UC_ServicesManagement()
        {
            InitializeComponent();
        }
        private void UC_ServicesManagement_Load(object sender, EventArgs e)
        {
            HideDetailPanel();

            LoadComboboxes();
            LoadData();

            // Đăng ký sự kiện
            txtSearch.EditValueChanged += Filters;
            cboSort.EditValueChanged += Filters;
            cboServiceTypeSort.EditValueChanged += Filters;

            repoBtnActions.ButtonClick += repoBtnActions_ButtonClick;
            gvServices.DoubleClick += gvServices_DoubleClick;

            btnInvite.Click += btnInvite_Click; // Nút Add
            btnClose.Click += btnClose_Click;
            btnCancel.Click += btnClose_Click;
            btnSave.Click += btnSave_Click;
            btnReset.Click += btnReset_Click;

        }

        private void LoadData()
        {
            _allData = _bus.GetAll();
            gcServices.DataSource = _allData;
            gvServices.RefreshData();

            if (gvServices.Columns["ID"] != null) gvServices.Columns["ID"].Visible = false;
            if (gvServices.Columns["GUID"] != null) gvServices.Columns["GUID"].Visible = false;
            if (gvServices.Columns["ServiceTypeID"] != null) gvServices.Columns["ServiceTypeID"].Visible = false;

            // Format cột giá
            if (gvServices.Columns["Price"] != null)
                gvServices.Columns["Price"].DisplayFormat.FormatString = "n2";
        }

        private void LoadComboboxes()
        {
            // 1. cboServiceTypes (Form Add/Edit)
            var serviceTypes = _busType.GetData();

            cboServiceTypes.Properties.DataSource = serviceTypes;
            cboServiceTypes.Properties.DisplayMember = "Name";
            cboServiceTypes.Properties.ValueMember = "ID";
            cboServiceTypes.Properties.NullText = "--- Select Type ---";
            cboServiceTypes.Properties.TextEditStyle =
                DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // Chỉ hiển thị cột Name
            cboServiceTypes.Properties.Columns.Clear();
            cboServiceTypes.Properties.Columns.Add(
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Service Type")
            );

            // Ẩn footer/search
            cboServiceTypes.Properties.ShowHeader = false;
            cboServiceTypes.Properties.ShowFooter = false;



            // cboServiceTypeSort (Filter)
            cboServiceTypeSort.Properties.Items.Clear();

            // Option ALL
            cboServiceTypeSort.Properties.Items.Add("All");

            // Chỉ add Name
            foreach (var item in serviceTypes)
            {
                cboServiceTypeSort.Properties.Items.Add(item.Name);
            }

            cboServiceTypeSort.SelectedIndex = 0;
            cboServiceTypeSort.Properties.TextEditStyle =
                DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;


            // 2. Sort
            cboSort.Properties.Items.Clear();
            cboSort.Properties.Items.AddRange(new string[] { "Name (A - Z)", "Name (Z - A)", "Price (Low - High)", "Price (High - Low)" });
            cboSort.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            // 3. CheckedComboBoxes cho Ngày trong Tuần và Tháng
            chkDaysOfWeek.Properties.Items.AddRange(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });

            for (int i = 1; i <= 31; i++)
            {
                chkDaysOfMonth.Properties.Items.Add(i.ToString());
            }
        }

        // QUẢN LÝ TRẠNG THÁI PANEL
        private void ShowDetailPanel()
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            splitContainerControl1.SplitterPosition = this.Width - 450;
        }

        private void HideDetailPanel()
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            _mode = "";
            _currentId = 0;
        }

        private void SetUIState(string mode, ET_Services data = null)
        {
            _mode = mode;
            ShowDetailPanel();

            bool isMapping = (mode == "ADD" || mode == "EDIT");

            txtName.Enabled = isMapping;
            cboServiceTypes.Enabled = isMapping;
            numPrice.Enabled = isMapping;
            numDuration.Enabled = isMapping;
            txtDescription.Enabled = isMapping;
            chkDaysOfWeek.Enabled = isMapping;
            chkDaysOfMonth.Enabled = isMapping;
            numDailyCapacity.Enabled = isMapping;
            numBookingCapacity.Enabled = isMapping;

            btnSave.Visible = isMapping;
            btnCancel.Visible = isMapping;

            if (mode == "ADD")
            {
                _currentId = 0;
                lblDetailTitle.Text = "Create New Service";
                btnSave.Text = "Create";

                txtName.Text = "";
                cboServiceTypes.EditValue = null;
                numPrice.Value = 0;
                numDuration.Value = 0;
                txtDescription.Text = "";
                chkDaysOfWeek.SetEditValue("");
                chkDaysOfMonth.SetEditValue("");
                numDailyCapacity.Value = 1; // Default
                numBookingCapacity.Value = 1; // Default
            }
            else if (data != null)
            {
                _currentId = data.ID;
                lblDetailTitle.Text = (mode == "EDIT") ? "Edit Service" : "View Details";
                btnSave.Text = "Update";

                txtName.Text = data.Name;
                cboServiceTypes.EditValue = data.ServiceTypeID;
                numPrice.Value = data.Price;
                numDuration.Value = data.Duration ?? 0;
                txtDescription.Text = data.Description;

                // Set multi-select combobox values
                chkDaysOfWeek.SetEditValue(data.DayOfWeek);
                chkDaysOfMonth.SetEditValue(data.DayOfMonth);

                numDailyCapacity.Value = data.DailyCap;
                numBookingCapacity.Value = data.BookingCap;
            }
        }

        // ==========================================
        // SỰ KIỆN CLICK & SAVE
        // ==========================================
        private void btnInvite_Click(object sender, EventArgs e) => SetUIState("ADD");
        private void btnClose_Click(object sender, EventArgs e) => HideDetailPanel();

        private void gvServices_DoubleClick(object sender, EventArgs e)
        {

        }

        private void repoBtnActions_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var row = gvServices.GetFocusedRow() as ET_Services;
            if (row == null) return;

            if (e.Button.Tag.ToString() == "edit")
            {
                SetUIState("EDIT", row);
            }
            else if (e.Button.Tag.ToString() == "delete")
            {
                if (XtraMessageBox.Show($"Xóa dịch vụ: {row.Name}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_bus.Delete(row.ID))
                    {
                        XtraMessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadData();
                    }
                    else XtraMessageBox.Show("Xóa thất bại!", "Lỗi");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            ET_Services et = new ET_Services
            {
                ID = _currentId,
                ServiceTypeID = Convert.ToInt64(cboServiceTypes.EditValue),
                Name = txtName.Text.Trim(),
                Price = numPrice.Value,
                Duration = numDuration.Value <= 0 ? (long?)null : Convert.ToInt64(numDuration.Value),
                Description = txtDescription.Text.Trim(),
                DayOfWeek = chkDaysOfWeek.EditValue?.ToString(),
                DayOfMonth = chkDaysOfMonth.EditValue?.ToString(),
                DailyCap = Convert.ToInt64(numDailyCapacity.Value),
                BookingCap = Convert.ToInt64(numBookingCapacity.Value)
            };

            bool success = (_mode == "ADD") ? _bus.Insert(et) : _bus.Update(et);

            if (success)
            {
                XtraMessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HideDetailPanel();
                LoadData();
            }
            else
            {
                XtraMessageBox.Show("Có lỗi xảy ra khi lưu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // VALIDATION NGHIỆP VỤ (BUSINESS LOGIC)
        // ==========================================
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("Tên dịch vụ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus(); return false;
            }

            if (cboServiceTypes.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn Loại dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboServiceTypes.Focus(); return false;
            }

            if (numPrice.Value < 0)
            {
                XtraMessageBox.Show("Giá dịch vụ không được âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrice.Focus(); return false;
            }

            if (numDailyCapacity.Value < 1 || numBookingCapacity.Value < 1)
            {
                XtraMessageBox.Show("Sức chứa tối thiểu phải từ 1 trở lên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDailyCapacity.Focus(); return false;
            }

            if (_bus.IsNameExists(txtName.Text.Trim(), _currentId))
            {
                XtraMessageBox.Show("Tên dịch vụ đã tồn tại! Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus(); return false;
            }

            return true;
        }

        // ==========================================
        // FILTER & SORT
        // ==========================================
        private void Filters(object sender, EventArgs e)
        {
            if (_allData == null) return;
            var filtered = _allData.AsEnumerable();

            string keyword = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(x => x.Name.ToLower().Contains(keyword) ||
                                               (x.ServiceTypeName != null && x.ServiceTypeName.ToLower().Contains(keyword)));
            }

            switch (cboSort.Text)
            {
                case "Name (A - Z)": filtered = filtered.OrderBy(x => x.Name); break;
                case "Name (Z - A)": filtered = filtered.OrderByDescending(x => x.Name); break;
                case "Price (Low - High)": filtered = filtered.OrderBy(x => x.Price); break;
                case "Price (High - Low)": filtered = filtered.OrderByDescending(x => x.Price); break;
            }

            string selectedType = cboServiceTypeSort.Text;

            if (!string.IsNullOrEmpty(selectedType)
                && selectedType != "All")
            {
                filtered = filtered.Where(x =>
                    x.ServiceTypeName == selectedType);
            }

            gcServices.DataSource = filtered.ToList();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
            cboSort.SelectedIndex = -1;
            gcServices.DataSource = _allData;
        }

        private void txtName1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
