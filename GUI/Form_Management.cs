using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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

        private void AddActionColumn()
        {
            // Tạo cột
            var col = gvManager.Columns.AddField("Action");
            col.Visible = true;
            col.Width = 180;
            col.OptionsColumn.FixedWidth = true;

            // Tạo button
            RepositoryItemButtonEdit btnAction = new RepositoryItemButtonEdit();

            btnAction.TextEditStyle = TextEditStyles.HideTextEditor;

            // Xóa button mặc định
            btnAction.Buttons.Clear();

            // Thêm button mới
            var btnEdit = new DevExpress.XtraEditors.Controls.EditorButton(
            DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph);
            btnEdit.Caption = "";
            btnEdit.Tag = "edit";
            //btnEdit.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromResources("DangNhap_Form.Resources.edit.svg", typeof().Assembly);
            btnEdit.Appearance.ForeColor = Color.DimGray;

            // 🔹 Nút Delete
            var btnDelete = new DevExpress.XtraEditors.Controls.EditorButton(
                DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph);
            btnDelete.Caption = "";
            btnDelete.Tag = "delete";
            //btnDelete.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromResources("DangNhap_Form.Resources.delete.svg", typeof().Assembly);
            btnDelete.Appearance.ForeColor = Color.Red;

            btnAction.Buttons.Add(btnEdit);
            btnAction.Buttons.Add(btnDelete);

            btnAction.ButtonClick += Btn_ButtonClick;

            // Add vào grid
            gcManager.RepositoryItems.Add(btnAction);
            col.ColumnEdit = btnAction;

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
                        var data_et = _bus.GetEditItems(item.ID);
                        Form_AddEditListing frm = new Form_AddEditListing(data_et, true);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LoadManagerListings();
                        }
                }
                else if (action == "delete")
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
                            LoadManagerListings();
                        else
                            MessageBox.Show(_bus.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
