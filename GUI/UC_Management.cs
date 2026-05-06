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
            //LoadTravelerListings();
            LoadManagerListings();
            ConfigureManagerGrid();
        }

        private void InitContextMenu()
        {
            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Edit Listing", null, (s, ev) => {
                var item = gvManager.GetFocusedRow() as DTO_ItemsView;
                if (item != null) OpenEditListing(item);
            });
            contextMenu.Items.Add("Edit Price", null, (s, ev) => {
                var item = gvManager.GetFocusedRow() as DTO_ItemsView;
                if (item != null) OnEditPrice(item);
            });
            contextMenu.Items.Add("Delete Listing", null, (s, ev) => {
                var item = gvManager.GetFocusedRow() as DTO_ItemsView;
                if (item != null) OpenDeleteListing(item);
            });

            gcManager.ContextMenuStrip = contextMenu;

            // Đảm bảo khi click chuột phải sẽ chọn đúng dòng
            gvManager.MouseDown += GvManager_MouseDown;
        }

        private void GvManager_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitInfo = gvManager.CalcHitInfo(e.Location);
                if (hitInfo.InRow)
                {
                    gvManager.FocusedRowHandle = hitInfo.RowHandle;
                }
            }
        }

        // Đổi tên thành nhận tham số DTO_ItemsView cho nhất quán
        private void OnEditPrice(DTO_ItemsView item)
        {
            if (item != null)
            {
                var parent = this.FindForm() as GUI_HomePage_Host;
                parent?.ShowPricingCalendar(item.ID);
            }
        }

        private void ConfigureManagerGrid()
        {
            gvManager.OptionsBehavior.Editable = true;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvManager.Columns)
            {
                if (col.FieldName != "Action")
                    col.OptionsColumn.AllowEdit = false;
            }

            if (gvManager.Columns["Action"] == null)
                AddActionColumn();
            else
            {
                gvManager.Columns["Action"].OptionsColumn.AllowEdit = true;
                gvManager.Columns["Action"].OptionsColumn.ReadOnly = false;
            }
        }

        private void AddActionColumn()
        {
            if (gvManager.Columns["Action"] != null) return;

            var col = gvManager.Columns.AddField("Action");
            col.Visible = true;
            col.Width = 180;
            col.OptionsColumn.FixedWidth = true;
            col.UnboundType = DevExpress.Data.UnboundColumnType.Object;

            RepositoryItemButtonEdit btnAction = new RepositoryItemButtonEdit();
            btnAction.TextEditStyle = TextEditStyles.HideTextEditor;
            btnAction.Buttons.Clear();

            var btnEdit = new EditorButton(ButtonPredefines.Glyph)
            {
                Tag = "edit"
            };
            btnEdit.ImageOptions.Image = Properties.Resources._006_pencil;
            btnEdit.ImageOptions.SvgImageSize = new Size(16, 16);
            btnEdit.Appearance.ForeColor = Color.DimGray;

            var btnDelete = new EditorButton(ButtonPredefines.Glyph)
            {
                Tag = "delete"
            };
            btnDelete.ImageOptions.Image = Properties.Resources.bin;
            btnDelete.ImageOptions.SvgImageSize = new Size(16, 16);
            btnDelete.Appearance.ForeColor = Color.Red;

            btnAction.Buttons.Add(btnEdit);
            btnAction.Buttons.Add(btnDelete);
            btnAction.ButtonClick += Btn_ButtonClick;

            gcManager.RepositoryItems.Add(btnAction);
            col.ColumnEdit = btnAction;

            col.OptionsColumn.AllowEdit = true;
            col.OptionsColumn.ReadOnly = false;
        }

        private void SummaryFooter(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            if (gridView.Columns.Count == 0) return;
            gridView.Columns[0].Summary.Clear();
            gridView.Columns[0].Summary.Add(
                DevExpress.Data.SummaryItemType.Count,
                gridView.Columns[0].FieldName,
                "{0} items found."
            );
        }

        //private void gcTraveler_Load(object sender, EventArgs e)
        //{
        //    LoadTravelerListings();
        //    SummaryFooter(gvTraveler);
        //    gvTraveler.BestFitColumns();
        //}

        //private void LoadTravelerListings()
        //{
        //    gcTraveler.DataSource = _bus.GetData();
        //}

        private void LoadManagerListings()
        {
            gcManager.DataSource = _bus.GetData(_currentUser?.ID);
            SummaryFooter(gvManager);
            gvManager.BestFitColumns();
        }

        private void OpenEditListing(DTO_ItemsView item)
        {
            var data_et = _bus.GetEditItems(item.ID);
            Form_AddEditListing frm = new Form_AddEditListing(data_et, true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadManagerListings();
                //LoadTravelerListings();
            }
        }

        private void OpenDeleteListing(DTO_ItemsView item)
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

        private void Btn_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int rowHandle = gvManager.FocusedRowHandle;
            string action = e.Button.Tag?.ToString();
            if (rowHandle >= 0)
            {
                var item = gvManager.GetRow(rowHandle) as DTO_ItemsView;
                if (item == null) return;

                if (action == "edit")
                {
                    OpenEditListing(item);
                }
                else if (action == "delete")
                {
                    OpenDeleteListing(item);
                }
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
                //LoadTravelerListings();
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
    }
}