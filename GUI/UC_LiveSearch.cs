using BUS;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Tile;
using DTO;
using ET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DXItemCheckEventArgs =
    DevExpress.XtraEditors.Controls.ItemCheckEventArgs;
namespace DangNhap_Form
{
    public partial class UC_LiveSearch : UserControl
    {
        private readonly BUS_Items _busItems = new BUS_Items();

        private readonly BUS_Amenity _busAmenities = new BUS_Amenity();

        private List<DTO_ItemCard> _allData;

        private Timer _searchTimer;

        public UC_LiveSearch()
        {
            InitializeComponent();


            this.Font = new Font("Be Vietnam Pro", 10f);

            InitTimer();
        }

        private void UC_LiveSearch_Load(object sender, EventArgs e)
        {
            InitUI();

            SetupTileView();

            InitCombobox();

            InitAmenities();


            RegisterEvents();

            LoadData();
        }
        public void SetupTileView()
        {
            tvListings.OptionsTiles.ItemSize =
    new Size(340, 420);

            tvListings.OptionsTiles.Padding =
                new Padding(18);

            tvListings.OptionsTiles.IndentBetweenItems =
                24;

            tvListings.OptionsTiles.RowCount = 0;

            tvListings.OptionsTiles.Orientation =
                Orientation.Vertical;

            tvListings.BorderStyle =
                BorderStyles.NoBorder;

            tvListings.Columns.Clear();

            tvListings.Columns.AddVisible("Title");
            tvListings.Columns.AddVisible("ApproximateAddress");
            tvListings.Columns.AddVisible("MinPrice");
            tvListings.Columns.AddVisible("NumberOfBeds");
            tvListings.Columns.AddVisible("NumberOfBathrooms");
            tvListings.Columns.AddVisible("Capacity");
            tvListings.Columns.AddVisible("Status");
            tvListings.Columns.AddVisible("ImageDisplay");
        }
        private void ResetFilters()
        {
            txtSearch.Text = "";

            cboSort.SelectedIndex = 0;

            spinGuests.Value = 1;

            for (int i = 0; i < clbAmenities.ItemCount; i++)
            {
                clbAmenities.SetItemChecked(i, false);
            }

            ApplyFilters();
        }
        

        private void InitCombobox()
        {
            cboSort.Properties.Items.Clear();

            cboSort.Properties.Items.AddRange(new string[]
            {
        "Newest",
        "Price Low → High",
        "Price High → Low",
        "Capacity High → Low"
            });

            cboSort.SelectedIndex = 0;

            cboSort.Properties.TextEditStyle =
                TextEditStyles.DisableTextEditor;
        }
        private void InitUI()
        {
            tvListings.OptionsBehavior.Editable = false;

            tvListings.OptionsSelection.MultiSelect = false;

            tvListings.OptionsTiles.IndentBetweenGroups = 24;

            tvListings.OptionsTiles.IndentBetweenItems = 24;

            tvListings.OptionsTiles.Padding =
                new Padding(24);

            tvListings.OptionsTiles.ItemSize =
                new Size(320, 420);

            tvListings.OptionsTiles.LayoutMode =
                DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.Kanban;

            tvListings.OptionsTiles.Orientation =
                Orientation.Vertical;

            tvListings.OptionsBehavior.AllowSmoothScrolling = true;

            tvListings.Appearance.ItemFocused.BorderColor =
                Color.Transparent;

            tvListings.Appearance.ItemFocused.Options.UseBorderColor = true;

            gcListings.UseEmbeddedNavigator = false;

            flyoutFilters.HidePopup();

            flyoutSuggestions.HidePopup();

            cboSort.Properties.TextEditStyle =
                TextEditStyles.DisableTextEditor;

            flyoutSuggestions.OptionsBeakPanel.BeakLocation =
                DevExpress.Utils.BeakPanelBeakLocation.Default;

            
            flyoutSuggestions.Options.CloseOnOuterClick = true;

            // Cho phép Flyout tự co giãn kích thước theo các control bên trong
            flyoutFilters.Options.CloseOnOuterClick = true; // Bấm ra ngoài tự ẩn

            // Đảm bảo control cha bên trong không bị fix cứng kích thước
            flyoutPanelControlfilter.AutoSize = true;
            flyoutPanelControlfilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Mặc định ẩn tất cả các panel lọc chi tiết khi chưa bấm nút gì
            clbAmenities.Visible = false;
            rangePrice.Visible = false;
            spinGuests.Visible = false;
            lblAmennities.Visible = false;
            lblPriceRange.Visible = false;
            lblGuest.Visible = false;
        }

        private void InitAmenities()
        {
            var amenities =
                _busAmenities.GetData();

            clbAmenities.Items.Clear();

            foreach (var item in amenities)
            {
                clbAmenities.Items.Add(
                    item,
                    item.Name,
                    CheckState.Unchecked,
                    true);
            }
        }

        private void InitTimer()
        {
            _searchTimer = new Timer();

            _searchTimer.Interval = 350;

            _searchTimer.Tick += SearchTimer_Tick;
        }
        private void RegisterEvents()
        {
            txtSearch.EditValueChanged += TxtSearch_EditValueChanged;

            cboSort.EditValueChanged += FiltersChanged;

            spinGuests.EditValueChanged += FiltersChanged;

            btnApplyFilters.Click += BtnApplyFilters_Click;

            clbAmenities.ItemCheck += ClbAmenities_ItemCheck;

            lstSuggestions.Click += LstSuggestions_Click;

            txtSearch.KeyDown += TxtSearch_KeyDown;

            btnFilter.Click += BtnFilter_Click;

            chkPrice.Click += CheckButtonFilter_Click;

            chkAmenities.Click += CheckButtonFilter_Click;

            chkGuests.Click += CheckButtonFilter_Click;

            chkAvailability.Click += CheckButtonFilter_Click;

            //tvListings.HtmlElementMouseClick += TvListings_HtmlElementMouseClick;
        }

        private void CheckButtonFilter_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckButton currentButton = sender as DevExpress.XtraEditors.CheckButton;
            if (currentButton == null) return;

            // Nếu nút bị bỏ chọn (Unchecked), ẩn Flyout đi
            if (!currentButton.Checked)
            {
                flyoutFilters.HidePopup();
                return;
            }

            // Tắt trạng thái Checked của các nút khác để tạo hiệu ứng Radio (chỉ hiện 1 bộ lọc tại 1 thời điểm)
            UncheckOtherButtons(currentButton);

            // Ẩn toàn bộ các control lọc trước khi quyết định hiện cái nào
            lblPriceRange.Visible = rangePrice.Visible = false;
            lblAmennities.Visible = clbAmenities.Visible = false;
            lblGuest.Visible = spinGuests.Visible = false;

            // Dựa vào tên nút để hiển thị control tương ứng
            if (currentButton == chkPrice)
            {
                lblPriceRange.Visible = rangePrice.Visible = true;
            }
            else if (currentButton == chkAmenities)
            {
                lblAmennities.Visible = clbAmenities.Visible = true;
            }
            else if (currentButton == chkGuests)
            {
                lblGuest.Visible = spinGuests.Visible = true;
            }
            else if (currentButton == chkAvailability)
            {
                // Khi chọn chkAvailability, hiển thị giao diện tổng thể hoặc gọi lệnh lọc ngay lập tức
                // Ở đây hiển thị toàn bộ hoặc hiển thị phần chọn ngày (nếu giao diện của bạn có DateEdit)
                lblPriceRange.Visible = rangePrice.Visible = true;
                lblAmennities.Visible = clbAmenities.Visible = true;
                lblGuest.Visible = spinGuests.Visible = true;
            }

            // ĐỊNH VỊ: Đặt Flyout xuất hiện ngay dưới nút vừa click
            flyoutFilters.OwnerControl = currentButton;

            // Ép Flyout tính toán lại kích thước dựa trên các control vừa được đặt Visible = true
            flyoutFilters.ShowPopup();
        }

        // Hàm phụ trợ bỏ chọn các nút còn lại để giao diện đồng nhất
        private void UncheckOtherButtons(DevExpress.XtraEditors.CheckButton checkedButton)
        {
            if (checkedButton != chkPrice) chkPrice.Checked = false;
            if (checkedButton != chkAmenities) chkAmenities.Checked = false;
            if (checkedButton != chkGuests) chkGuests.Checked = false;
            if (checkedButton != chkAvailability) chkAvailability.Checked = false;
        }
        private void FilterChip_Click(object sender, EventArgs e)        
        {
            flyoutFilters.OwnerControl =
                btnFilter;

            flyoutFilters.ShowPopup();
        }
        private void ChkAmenities_CheckedChanged(object sender, EventArgs e)
        {
            flyoutFilters.ShowPopup();

            clbAmenities.Focus();
        }
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            flyoutFilters.OwnerControl = btnFilter;

            flyoutFilters.ShowPopup();
        }
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                flyoutSuggestions.HidePopup();

                ApplyFilters();
            }
        }
        //    private void TvListings_HtmlElementMouseClick(
        //object sender,
        //TileViewHtmlElementMouseEventArgs e)
        //    {
        //        var item =
        //            tvListings.GetRow(e.RowHandle)
        //            as DTO_ItemCard;

        //        if (item == null)
        //            return;

        //        OpenDetail(item.ID);
        //    }
        private void LstSuggestions_Click(
    object sender,
    EventArgs e)
        {
            if (lstSuggestions.SelectedItem == null)
                return;

            txtSearch.Text =
                lstSuggestions.SelectedItem.ToString();

            flyoutSuggestions.HidePopup();

            ApplyFilters();
        }
        private void LoadData()
        {
            _allData =
                _busItems.GetItemCards();

            ApplyFilters();
        }
        private void ApplyFilters()
        {
            if (_allData == null)
                return;

            IEnumerable<DTO_ItemCard> query =
                _allData;

            #region SEARCH

            string keyword =
                txtSearch.Text?
                .Trim()
                .ToLower() ?? "";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x => (x.Title ?? "").ToLower().Contains(keyword)                ||
                                        (x.ApproximateAddress ?? "").ToLower().Contains(keyword)    ||
                                        (x.Type ?? "").ToLower().Contains(keyword));
            }

            #endregion

            #region PRICE

            decimal minPrice = rangePrice.Value.Minimum;

            decimal maxPrice = rangePrice.Value.Maximum;

            query = query.Where(x =>
                (x.MinPrice ?? 0) >= minPrice
                &&
                (x.MinPrice ?? 0) <= maxPrice);

            #endregion

            #region GUESTS

            int guests =
                Convert.ToInt32(spinGuests.Value);

            query = query.Where(x =>
                x.Capacity >= guests);

            #endregion

            #region AMENITIES

            List<long> selectedAmenities =
                new List<long>();

            foreach (CheckedListBoxItem item
                in clbAmenities.CheckedItems)
            {
                if (item.Value is DTO_Amenities amenity)
                {
                    selectedAmenities.Add(
                        amenity.ID);
                }
            }

            if (selectedAmenities.Count > 0)
            {
                var matchedIds = _busItems.GetItemIdsByAmenities(selectedAmenities);

                query = query.Where(x =>matchedIds.Contains(x.ID));
            }

            #endregion

            if (chkAvailability.Checked)
            {
                // Gọi tầng BUS/DAL lấy ra những ItemID đang có trạng thái IsAvailable = true trong bảng ItemAvailability
                // Thực tế đề thi: Thường sẽ lọc kèm theo khoảng ngày Check-in/Check-out. 
                // Nếu đề không có ô chọn ngày, ta lọc những chỗ ở đang "Active" hoặc có lịch trống trong tương lai:
                List<long> availableItemIds = _busItems.GetCurrentlyAvailableItemIds();
                query = query.Where(x => availableItemIds.Contains(x.ID));
            }

            #region SORT

            switch (cboSort.Text)
            {
                case "Price Low → High":

                    query =
                        query.OrderBy(x => x.MinPrice);

                    break;

                case "Price High → Low":

                    query =
                        query.OrderByDescending(x => x.MinPrice);

                    break;

                case "Capacity High → Low":

                    query =
                        query.OrderByDescending(x => x.Capacity);

                    break;

                default:

                    query =
                        query.OrderByDescending(x => x.ID);

                    break;
            }

            #endregion

            var result =
                query.ToList();


            gcListings.DataSource = result;

            tvListings.RefreshData();

            lblResultCount.Text =
                $"{result.Count} serene stays found";

            pnlEmptyState.Visible =
                result.Count == 0;

            LoadSuggestions();
        }
        private void LoadSuggestions()
        {
            string keyword =
                txtSearch.Text
                .Trim()
                .ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                flyoutSuggestions.HidePopup();

                return;
            }

            var suggestions =
                _allData
                .Where(x =>
                    (x.Title ?? "")
                    .ToLower()
                    .Contains(keyword))
                .Select(x => x.Title)
                .Distinct()
                .Take(8)
                .ToList();

            lstSuggestions.DataSource = null;

            lstSuggestions.DataSource =
                suggestions;

            if (suggestions.Count > 0)
            {
                flyoutSuggestions.OwnerControl =
                    txtSearch;

                flyoutSuggestions.ShowPopup();
            }
            else
            {
                flyoutSuggestions.HidePopup();
            }
        }
        private void TxtSearch_EditValueChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();

            _searchTimer.Start();
        }
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop();

            ApplyFilters();
        }
        private void FiltersChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void BtnApplyFilters_Click(object sender, EventArgs e)
        {
            ApplyFilters();

            flyoutFilters.HidePopup();
        }
        private void ClbAmenities_ItemCheck(object sender, DXItemCheckEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                ApplyFilters();
            }));
        }
    }
}