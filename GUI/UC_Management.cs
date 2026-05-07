using BUS;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DTO;
using ET;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DangNhap_Form
{
    public partial class UC_Management : UserControl
    {
        private readonly BUS_Items _bus = new BUS_Items();
        private readonly ET_Users _currentUser;
        private ContextMenuStrip contextMenu;

        public UC_Management(ET_Users currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        public UC_Management()
        {
            InitializeComponent();
        }

        private void UC_Management_Load(object sender, EventArgs e)
        {
            InitContextMenu();

            SetupTileView();
            LoadManagerListings();
        }
        private void InitContextMenu()
        {
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Edit Listing", null, (s, ev) =>
            {
                var item = tvManager.GetFocusedRow() as DTO_ItemCard;
                if (item != null) OpenEditListing(item);
            });
            contextMenu.Items.Add("Edit Price", null, (s, ev) =>
            {
                var item = tvManager.GetFocusedRow() as DTO_ItemCard;
                if (item != null) OnEditPrice(item);
            });
            contextMenu.Items.Add("Delete Listing", null, (s, ev) =>
            {
                var item = tvManager.GetFocusedRow() as DTO_ItemCard;
                if (item != null) OpenDeleteListing(item);
            });

            gcManager.ContextMenuStrip = contextMenu;

            // Đảm bảo khi click chuột phải sẽ chọn đúng dòng
            tvManager.MouseDown += TvManager_MouseDown;
        }
        private void LoadManagerListings()
        {
            gcManager.DataSource = _bus.GetItemCards(_currentUser?.ID);
            SummaryFooter(tvManager);

        }

        private void SetupTileView()
        {
            tvManager.Columns.Clear();

            tvManager.Columns.AddVisible(nameof(DTO_ItemCard.Title));
            tvManager.Columns.AddVisible(nameof(DTO_ItemCard.ApproximateAddress));
            tvManager.Columns.AddVisible(nameof(DTO_ItemCard.MinPrice));
            tvManager.Columns.AddVisible(nameof(DTO_ItemCard.NumberOfBeds));
            tvManager.Columns.AddVisible(nameof(DTO_ItemCard.NumberOfBathrooms));
            tvManager.Columns.AddVisible(nameof(DTO_ItemCard.ThumbnailPath));
            tvManager.Columns.AddVisible(nameof(DTO_ItemCard.Status));

            tvManager.OptionsTiles.RowCount = 0;

            tvManager.OptionsTiles.ItemSize = new Size(320, 520);

            tvManager.OptionsTiles.Padding = new Padding(20);

            tvManager.OptionsTiles.Orientation = Orientation.Vertical;

            tvManager.OptionsTiles.LayoutMode =
                DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.Default;

            tvManager.BorderStyle = BorderStyles.NoBorder;
        }



        private void TvManager_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = tvManager.CalcHitInfo(e.Location);

            if (hit.RowHandle < 0)
                return;

            tvManager.FocusedRowHandle = hit.RowHandle;

            var item = tvManager.GetRow(hit.RowHandle) as DTO_ItemCard;

            if (item == null)
                return;

            // RIGHT CLICK
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(Cursor.Position);
                return;
            }

            // LEFT CLICK
            // Xuống chức năng tvManager_HtmlElementMouseClick
        }

        // Đổi tên thành nhận tham số DTO_ItemsView cho nhất quán
        private void OnEditPrice(DTO_ItemCard item)
        {
            if (item != null)
            {
                var parent = this.FindForm() as GUI_HomePage_Host_Copy;
                parent?.ShowPricingCalendar(item.ID);
            }
        }

        private void SummaryFooter(DevExpress.XtraGrid.Views.Tile.TileView tileView)
        {
            if (tileView.Columns.Count == 0) return;
            tileView.Columns[0].Summary.Clear();
            tileView.Columns[0].Summary.Add(
                DevExpress.Data.SummaryItemType.Count,
                tileView.Columns[0].FieldName,
                "{0} items found."
            );
        }

        private void OpenEditListing(DTO_ItemCard item)
        {
            var data_et = _bus.GetEditItems(item.ID);
            Form_AddEditListing frm = new Form_AddEditListing(data_et, true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadManagerListings();
            }
        }

        private void OpenDeleteListing(DTO_ItemCard item)
        {
            var result = MessageBox.Show(
                "Are you sure you want to delete this listing?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.Yes)
            {
                if (_bus.Delete(item.ID))
                {
                    LoadManagerListings();
                    //LoadTravelerListings();
                }
                else
                    MessageBox.Show(_bus.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form_AddEditListing frm = new Form_AddEditListing(_currentUser?.ID ?? 0, false);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadManagerListings();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Xử lý đăng xuất: quay lại form login
            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
            Form_Login login = new Form_Login();
            login.Show();
        }

        private void tvManager_HtmlElementMouseClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewHtmlElementMouseEventArgs e)
        {
            var item = tvManager.GetRow(e.RowHandle) as DTO_ItemCard;
            if (item == null) return;

            if (e.ElementId == "editBtn")
            {
                OpenEditListing(item);
            }
            if (e.ElementId == "moreBtn")
            {
                contextMenu.Show(Cursor.Position);
            }
        }

        private void tvManager_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}