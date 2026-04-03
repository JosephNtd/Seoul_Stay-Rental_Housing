using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
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
        public Form_Management()
        {
            InitializeComponent();
        }
        private void Form_Management_Load(object sender, EventArgs e)
        {            
            
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
                "{0} iztems found."
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
            gcManager.DataSource = _bus.GetData();
            gvManager.OptionsBehavior.Editable = true;
            gvManager.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;

            var btn = AddActionColumn();     // tạo cột
            HandleActionClick(btn);          // gán event
            SummaryFooter(gvManager);
            gvManager.BestFitColumns();
        }

        private RepositoryItemButtonEdit AddActionColumn()
        {
            // Tạo cột
            var col = gvManager.Columns.AddField("Action");
            col.Visible = true;
            col.Width = 120;
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
            var view = gvManager;

            int rowHandle = view.FocusedRowHandle;

            if (rowHandle >= 0)
            {
                var data = view.GetRow(rowHandle);

                Form_AddEditListing frm = new Form_AddEditListing();
                frm.ShowDialog();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form_AddEditListing frm = new Form_AddEditListing();
            frm.ShowDialog();
        }
    }
}
