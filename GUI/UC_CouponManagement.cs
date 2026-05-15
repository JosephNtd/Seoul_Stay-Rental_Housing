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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DangNhap_Form
{
    public partial class UC_CouponManagement : UserControl
    {
        private readonly BUS_Coupon _bus = new BUS_Coupon();
        private List<ET_Coupons> _allData;
        private string _mode = "";
        private long _currentId = 0;
        public UC_CouponManagement()
        {
            InitializeComponent();
        }

        private void UC_CouponManagement_Load(object sender, EventArgs e)
        {
            repoBtnActions.ButtonClick += repoBtnActions_ButtonClick;

            gvCoupons.DoubleClick += gvCoupons_DoubleClick;

            btnClose.Click += btnClose_Click;

            splitContainerControl1.FixedPanel =
                SplitFixedPanel.Panel2;

            splitContainerControl1.PanelVisibility =
                SplitPanelVisibility.Panel1;

            splitContainerControl1.Panel2.MinSize = 320;
            LoadComboboxSort();
            LoadData();

            // Đăng ký sự kiện lọc
            txtSearch.EditValueChanged += Filters;
            cboSort.EditValueChanged += Filters;
            cboStatusSort.EditValueChanged += Filters;

            gvCoupons.OptionsBehavior.Editable = true;

            gvCoupons.FocusRectStyle =
                DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;

            gvCoupons.OptionsSelection.EnableAppearanceFocusedCell = false;

            Actions.OptionsColumn.AllowEdit = true;
        }
        private void LoadData()
        {
            _allData = _bus.GetAll();
            gcCoupons.DataSource = _allData;
            gvCoupons.RefreshData();

            // Ẩn các cột không cần thiết
            if (gvCoupons.Columns["ID"] != null) gvCoupons.Columns["ID"].Visible = false;
            if (gvCoupons.Columns["GUID"] != null) gvCoupons.Columns["GUID"].Visible = false;

        }
        
        // 2. Hàm nạp dữ liệu cho Combobox Sort
        private void LoadComboboxSort()
        {
            cboSort.Properties.Items.Clear();
            cboSort.Properties.Items.AddRange(new string[]
            {
                "Code (A - Z)",
                "Code (Z - A)",
                "Expiration Date (Oldest)",
                "Expiration Date (Newest)",
                "Discount % (Low - High)",
                "Discount % (High - Low)"
            });
            cboSort.SelectedIndex = -1;
            cboSort.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cboSort.Properties.NullText = "--- Sort by ---";

            cboStatusSort.Properties.Items.Clear();
            cboStatusSort.Properties.Items.AddRange(new string[]
            {
                "Active",
                "Inactive",
            });
            cboStatusSort.SelectedIndex = -1;
            cboStatusSort.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cboStatusSort.Properties.NullText = "--- Status ---";
        }

        // 3. Hàm Lọc và Sắp xếp (Filters)
        private void Filters(object sender, EventArgs e)
        {
            if (_allData == null) return;

            IEnumerable<ET_Coupons> filtered = _allData;

            // Search
            string keyword = txtSearch.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(x =>
                    x.CouponCode.ToLower().Contains(keyword));
            }

            // Status
            string status = cboStatusSort.Text;

            switch (status)
            {
                case "Active":
                    filtered = filtered.Where(x => x.IsActive);
                    break;

                case "Inactive":
                    filtered = filtered.Where(x => !x.IsActive);
                    break;
            }

            // Sort
            string sortOption = cboSort.Text;

            switch (sortOption)
            {
                case "Code (A - Z)":
                    filtered = filtered.OrderBy(x => x.CouponCode);
                    break;

                case "Code (Z - A)":
                    filtered = filtered.OrderByDescending(x => x.CouponCode);
                    break;

                case "Expiration Date (Oldest)":
                    filtered = filtered.OrderBy(x => x.ExpirationDate);
                    break;

                case "Expiration Date (Newest)":
                    filtered = filtered.OrderByDescending(x => x.ExpirationDate);
                    break;

                case "Discount % (Low - High)":
                    filtered = filtered.OrderBy(x => x.DiscountPercent);
                    break;

                case "Discount % (High - Low)":
                    filtered = filtered.OrderByDescending(x => x.DiscountPercent);
                    break;
            }

            gcCoupons.DataSource = filtered.ToList();
        }

        private void ShowDetailPanel()
        {
            splitContainerControl1.PanelVisibility =
                SplitPanelVisibility.Both;

            splitContainerControl1.SplitterPosition =
                this.Width - 850;
        }

        private void HideDetailPanel()
        {
            splitContainerControl1.PanelVisibility =
                SplitPanelVisibility.Panel1;
            _mode = "";
            _currentId = 0;
        }

        private void SetUIState(string mode, ET_Coupons data = null)
        {
            _mode = mode;
            ShowDetailPanel();

            // Khóa hoặc mở các control nhập liệu
            bool mappingEnabled = (mode == "ADD" || mode == "EDIT");
            txtCouponCode.Enabled = mappingEnabled;
            numDiscountPercent.Enabled = mappingEnabled;
            numMaximumDiscountAmount.Enabled = mappingEnabled;
            deStartedDate.Enabled = mappingEnabled;
            deExpirationDate.Enabled = mappingEnabled;
            numMaxUsage.Enabled = mappingEnabled;
            chkIsActive.Enabled = mappingEnabled;

            btnSave.Visible = mappingEnabled;
            btnCancel.Visible = mappingEnabled;

            if (mode == "ADD")
            {
                _currentId = 0;
                lblDetailTitle.Text = "Create New Coupon";
                btnSave.Text = "Create";
                // Clear trắng form
                txtCouponCode.Text = "";
                numDiscountPercent.Value = 0;
                numMaximumDiscountAmount.Value = 0;
                deStartedDate.EditValue = DateTime.Now;
                deExpirationDate.EditValue = DateTime.Now.AddDays(30);
                numMaxUsage.Value = 100;
                chkIsActive.Checked = true;
            }
            else if (data != null)
            {
                _currentId = data.ID;
                lblDetailTitle.Text = (mode == "EDIT") ? "Update Coupon" : "Coupon Information";
                btnSave.Text = "Update";

                // Đổ dữ liệu vào control
                txtCouponCode.Text = data.CouponCode;
                numDiscountPercent.Value = data.DiscountPercent;
                numMaximumDiscountAmount.Value = data.MaximumDiscountAmount;
                deStartedDate.EditValue = data.StartedDate;
                deExpirationDate.EditValue = data.ExpirationDate;
                Convert.ToDecimal(data.MaxUsageCount ?? 0);
                chkIsActive.Checked = data.IsActive;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
            cboSort.SelectedIndex = -1;
            gcCoupons.DataSource = _allData;
        }

        void repoBtnActions_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var row = gvCoupons.GetFocusedRow() as ET_Coupons;

            if (row == null) return;

            switch (e.Button.Tag.ToString())
            {
                case "edit":
                    _mode = "EDIT";
                    SetUIState( _mode, row);

                    ShowDetailPanel();

                    break;

                case "delete":
                    DialogResult dialogResult = XtraMessageBox.Show(
                $"Bạn có chắc chắn muốn xóa điểm tham quan '{row.CouponCode}' không?",
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

        private void btnInvite_Click(object sender, EventArgs e)
        {
            _mode = "ADD";
            SetUIState(_mode);
            ShowDetailPanel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            HideDetailPanel();
        }
        private void gvCoupons_DoubleClick(object sender, EventArgs e)
        {
            var row =
                gvCoupons.GetFocusedRow()
                as ET_Coupons;

            if (row == null) return;
            _mode = "VIEW";
            SetUIState(_mode, row);

            ShowDetailPanel();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }
            ET_Coupons et = new ET_Coupons
            {
                ID = _currentId,
                CouponCode = txtCouponCode.Text.Trim().ToUpper(), // Chuyển chữ hoa luôn cho chuẩn
                DiscountPercent = numDiscountPercent.Value,
                MaximumDiscountAmount = numMaximumDiscountAmount.Value,
                StartedDate = Convert.ToDateTime(deStartedDate.EditValue),

                // Ép kiểu an toàn cho DateTime?
                ExpirationDate = (deExpirationDate.EditValue == null || string.IsNullOrWhiteSpace(deExpirationDate.Text))
                     ? (DateTime?)null
                     : Convert.ToDateTime(deExpirationDate.EditValue),

                // Ép kiểu an toàn cho int? (Giả sử bằng 0 tức là vô hạn)
                MaxUsageCount = numMaxUsage.Value <= 0
                     ? (int?)null
                     : Convert.ToInt32(numMaxUsage.Value),

                IsActive = chkIsActive.Checked
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
                    $"Bạn có chắc chắn muốn cập nhật '{txtCouponCode.Text.ToString()}' không?",
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
            string code = txtCouponCode.Text.Trim();

            // 1. RÀNG BUỘC RỖNG & KÝ TỰ ĐẶC BIỆT MÃ COUPON
            if (string.IsNullOrWhiteSpace(code))
            {
                XtraMessageBox.Show("Mã Coupon không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCouponCode.Focus();
                return false;
            }

            // Mã Coupon thường chỉ cho phép Viết Hoa và Số (Ví dụ: SUMMER2024)
            var regexCode = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]+$");
            if (!regexCode.IsMatch(code))
            {
                XtraMessageBox.Show("Mã Coupon chỉ được chứa chữ cái không dấu và số, không có khoảng trắng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCouponCode.Focus();
                return false;
            }

            // 2. RÀNG BUỘC NGÀY THÁNG (DATES)
            if (deStartedDate.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn Ngày bắt đầu áp dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                deStartedDate.Focus();
                return false;
            }

            DateTime startDate = Convert.ToDateTime(deStartedDate.EditValue);

            // Nếu có nhập ngày hết hạn, thì ngày hết hạn phải >= ngày bắt đầu
            if (deExpirationDate.EditValue != null && !string.IsNullOrEmpty(deExpirationDate.Text))
            {
                DateTime endDate = Convert.ToDateTime(deExpirationDate.EditValue);
                if (endDate <= startDate)
                {
                    XtraMessageBox.Show("Ngày hết hạn phải lớn hơn Ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    deExpirationDate.Focus();
                    return false;
                }
            }

            // 3. RÀNG BUỘC KIỂU SỐ (BIÊN TRÊN/DƯỚI)
            // Giả sử hệ thống lưu % dưới dạng số nguyên (10%) hoặc số thập phân tuỳ bạn thiết lập. Ở đây chặn từ 0 -> 100.
            if (numDiscountPercent.Value <= 0 || numDiscountPercent.Value > 100)
            {
                XtraMessageBox.Show("Phần trăm giảm giá phải lớn hơn 0 và tối đa là 100%!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDiscountPercent.Focus();
                return false;
            }

            if (numMaximumDiscountAmount.Value < 0)
            {
                XtraMessageBox.Show("Số tiền giảm giá tối đa không được để số âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMaximumDiscountAmount.Focus();
                return false;
            }

            if (numMaxUsage.Value < 0)
            {
                XtraMessageBox.Show("Số lượt sử dụng tối đa không được phép âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMaxUsage.Focus();
                return false;
            }

            // 4. KIỂM TRA TRÙNG LẶP (DUPLICATE)=
            if (_bus.IsCodeExists(code, _currentId))
            {
                XtraMessageBox.Show("Mã Coupon này đã tồn tại trên hệ thống! Vui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCouponCode.Focus();
                return false;
            }

            return true;
        }
    }
}
