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

namespace DangNhap_Form
{
    public partial class UC_AmenityManagement : UserControl
    {
        private readonly BUS_Amenity _bus = new BUS_Amenity();
        private List<ET_Amenities> _allData;
        public UC_AmenityManagement()
        {
            InitializeComponent();
        }

        private void UC_AmenityManagement_Load(object sender, EventArgs e)
        {
            repoBtnActions.ButtonClick += repoBtnActions_ButtonClick;

            LoadData();
            LoadCombobox();

            txtSearch.EditValueChanged += Filters;
            cboSort.EditValueChanged += Filters;

        }

        private void LoadData()
        {
            _allData = _bus.GetAllData();

            ET_Amenities.DefaultIcon = Properties.Resources.WSC2022SE_TP09_Logo_actual_en1;

            gcAmenities.DataSource = null;
            gcAmenities.DataSource = _allData;

            gvAmenities.RefreshData();

            if (gvAmenities.Columns["AmenitiesID"] != null)
                gvAmenities.Columns["AmenitiesID"].Visible = false;

        }

        private void LoadCombobox()
        {
            cboSort.Properties.Items.AddRange(new string[]
            {
                "Sort by Name - Ascending",
                "Sort by Name - Descending",
            });
            cboSort.Properties.NullText = "---Sort by---";

            cboSort.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cboSort.SelectedIndex = -1;
        }
        private void Filters(object sender, EventArgs e)
        {
            if (_allData == null) return;

            IEnumerable<ET_Amenities> filteredData = _allData;

            // Search
            string keyword = txtSearch.Text?.Trim().ToLower() ?? "";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                filteredData = filteredData.Where(a =>
                    (a.AmenitiesName ?? "").ToLower().Contains(keyword)).ToList();
            }

            switch (cboSort.Text)
            {
                case "Sort by Name - Ascending":
                    filteredData = filteredData.OrderBy(x => x.AmenitiesName).ToList();
                    break;
                case "Sort by Name - Descending":
                    filteredData = filteredData.OrderByDescending(x => x.AmenitiesName).ToList();
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
    }
}
