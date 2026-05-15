using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace DangNhap_Form
{
    public partial class UC_AreaManagement : UserControl
    {
        private readonly BUS_Area _bus = new BUS_Area();
        private List<DTO_AreaDisplay> _allData;
        public UC_AreaManagement()
        {
            InitializeComponent();
        }

        private void UC_AreaManagement_Load(object sender, EventArgs e)
        {
            HideDetailPanel();
            LoadData();
            LoadCombobox();

            txtSearch.EditValueChanged += Filters;
            cboSort.EditValueChanged += Filters;
        }

        private void LoadData()
        {
            _allData = _bus.GetData();

            gcAreas.DataSource = null;
            gcAreas.DataSource = _allData;

            gvAreas.RefreshData();

            if (gvAreas.Columns["AreaID"] != null)
                gvAreas.Columns["AreaID"].Visible = false;
            
        }

        private void LoadCombobox()
        {
            cboSort.Properties.Items.AddRange(new string[]
            {
                "Sort by Name - Ascending",
                "Sort by Name - Descending",
                "Sort by Stay Count - Ascending",
                "Sort by Stay Count - Descending"
            });
            cboSort.Properties.NullText = "---Sort by---";

            cboSort.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cboSort.SelectedIndex = -1;
        }
        private void Filters(object sender, EventArgs e)
        {
            if (_allData == null) return;

            IEnumerable<DTO_AreaDisplay> filteredData = _allData;

            // Search
            string keyword = txtSearch.Text?.Trim().ToLower() ?? "";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filteredData = filteredData.Where(a =>
                    (a.AreaName ?? "").ToLower().Contains(keyword)).ToList();
            }

            switch (cboSort.Text)
            {
                case "Sort by Name - Ascending":
                    filteredData = filteredData.OrderBy(x => x.AreaName).ToList();
                    break;
                case "Sort by Name - Descending":
                    filteredData = filteredData.OrderByDescending(x => x.AreaName).ToList();
                    break;
                case "Sort by Stay Count - Ascending":
                    filteredData = filteredData.OrderBy(x => x.StayCount).ToList();
                    break;
                case "Sort by Stay Count - Descending":
                    filteredData = filteredData.OrderByDescending(x => x.StayCount).ToList();
                    break;
            }

            gcAreas.DataSource = filteredData.ToList();
            gvAreas.RefreshData();
        }

        private void gvAreas_DoubleClick(object sender, EventArgs e)
        {
            ShowDetailPanel();
            // Lấy dòng đang được click đúp
            var row = gvAreas.GetFocusedRow() as DTO_AreaDisplay;
            if (row == null) return;

            long areaId = row.AreaID;

            // --- TAB 1: HIỂN THỊ TỔNG QUAN ---
            // Sử dụng biến StayCount có sẵn từ DTO của bạn cho "Lượt khách" hoặc "Số lượng phòng"
            lblStayCount.Text = $"Lượt chỗ nghỉ/khách: {row.StayCount}";
            lblDetailTitle.Text = $"KHÁM PHÁ: {row.AreaName.ToUpper()}"; // Đổi tiêu đề Panel

            // Gọi BUS lấy thêm thống kê sâu hơn
            DTO_AreaOverview overview = _bus.GetAreaOverview(areaId);
            if (overview != null)
            {
                lblTotalItems.Text = $"Tổng số Chỗ nghỉ: {overview.TotalItems}";
                lblTotalAmenities.Text = $"Tổng số Tiện ích cung cấp: {overview.TotalAmenities}";
            }

            // --- TAB 2: DANH SÁCH CHỖ NGHỈ ---
            gcAreaItems.DataSource = _bus.GetItemsByArea(areaId);
            if (gvAreaItems.Columns["ID"] != null) gvAreaItems.Columns["ID"].Visible = false;
            gvAreaItems.BestFitColumns();

            // --- TAB 3: ĐIỂM THAM QUAN ---
            gcAreaAttractions.DataSource = _bus.GetAttractionsByArea(areaId);
            if (gvAreaAttractions.Columns["ID"] != null) gvAreaAttractions.Columns["ID"].Visible = false;
            gvAreaAttractions.BestFitColumns();

            // Auto chuyển focus sang tab Tổng quan mỗi khi click mới
            xtraTabAreaInsights.SelectedTabPage = xtraTabAreaInsights.TabPages[0];
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
            cboSort.EditValue = null;

            gcAreas.DataSource = _allData;
        }
        private void ShowDetailPanel()
        {
            splitContainerControl1.PanelVisibility =
                SplitPanelVisibility.Both;

            splitContainerControl1.SplitterPosition =
                this.Width - 600;
        }

        private void HideDetailPanel()
        {
            splitContainerControl1.PanelVisibility =
                SplitPanelVisibility.Panel1;
        }
    }
}
