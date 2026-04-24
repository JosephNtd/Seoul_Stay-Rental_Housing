using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
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

namespace DangNhap_Form
{
    public partial class Form_Management : DevExpress.XtraEditors.XtraForm
    {
        private readonly BUS_Items _bus = new BUS_Items();
        private readonly ET_Users _currentUser;

        public Form_Management() : this(null)
        {
        }

        public Form_Management(ET_Users currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }
        private void Form_Management_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'seoul_StayDataSet.Areas' table. You can move, or remove it, as needed.
            this.areasTableAdapter.Fill(this.seoul_StayDataSet.Areas);

        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SummaryFooter(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.Columns[0].Summary.Clear();
            gridView.Columns[0].Summary.Add(
                DevExpress.Data.SummaryItemType.Count,
                gridView.Columns[0].FieldName,
                "{0} items found."
            );
        }
        private void gcTraveler_Load(object sender, EventArgs e)
        {
            gcTraveler.DataSource = _bus.GetData();
            SummaryFooter(gvTraveler);
            gvTraveler.BestFitColumns();
        }
        
        private void gcManager_Load(object sender, EventArgs e)
        {
            LoadManagerListings();
            gvManager.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;

            var btn = AddActionColumn();     // tạo cột
            HandleActionClick(btn);          // gán event
            
            SummaryFooter(gvManager);
            gvManager.OptionsBehavior.Editable = true;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvManager.Columns)
            {
                col.OptionsColumn.AllowEdit = false;
            }
            gvManager.Columns["Action"].OptionsColumn.AllowEdit = true;
            gvManager.Columns["Action"].OptionsColumn.ReadOnly = false;
            gvManager.OptionsBehavior.Editable = true;
            gvManager.BestFitColumns();
        }

        private RepositoryItemButtonEdit AddActionColumn()
        {
            // Tạo cột
            var col = gvManager.Columns.AddField("Action");
            col.Visible = true;
            col.Width = 180;
            col.OptionsColumn.FixedWidth = true;

            // Tạo button
            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            // Xóa button mặc định
            btn.Buttons.Clear();

            // Thêm button mới
            btn.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(
                DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                Caption = "Edit Details"
            });
            // Add vào grid
            gcManager.RepositoryItems.Add(btn);
            col.ColumnEdit = btn;

            return btn; // trả về để gán event
        }

        private void HandleActionClick(RepositoryItemButtonEdit btn)
        {
            btn.ButtonClick += Btn_ButtonClick;
        }
        private void Btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            int rowHandle = gvManager.FocusedRowHandle;

            if (rowHandle >= 0)
            {
                var data_dto = gvManager.GetRow(rowHandle) as DTO_ItemsView;

                if (e.Button.Index == 0 && data_dto != null)
                {
                    var data_et = _bus.GetEditItems(data_dto.ID);
                    Form_AddEditListing frm = new Form_AddEditListing(data_et, true);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadManagerListings();
                    }
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
            }
        }

        private void LoadManagerListings()
        {
            gcManager.DataSource = _bus.GetData(_currentUser?.ID);
        }
    }
}
