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
            repoBtnActions.ButtonClick += repoBtnActions_ButtonClick;

            LoadData();
            LoadCombobox();

            txtSearch.EditValueChanged += Filters;
            cboSort.EditValueChanged += Filters;
        }

        private void LoadData()
        {
            _allData = _bus.GetData();

            gcAmenities.DataSource = null;
            gcAmenities.DataSource = _allData;

            gvAmenities.RefreshData();

            if (gvAmenities.Columns["AreaID"] != null)
                gvAmenities.Columns["AreaID"].Visible = false;
            
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

            gcAmenities.DataSource = filteredData.ToList();
            gvAmenities.RefreshData();
        }

        private void repoBtnActions_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var row = gvAmenities.GetFocusedRow() as DTO_AreaDisplay;
            if (row == null) return;

            switch (e.Button.Tag.ToString())
            {
                case "edit":
                    XtraMessageBox.Show("Edit ne", "Edit", MessageBoxButtons.OKCancel);
                    break;
                case "delete":
                    XtraMessageBox.Show("Delete ne", "Edit", MessageBoxButtons.OKCancel);
                    break;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
            cboSort.EditValue = null;

            gcAmenities.DataSource = _allData;
        }
    }
}
