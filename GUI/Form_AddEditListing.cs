using BUS;
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
    public partial class Form_AddEditListing : Form
    {
        BUS_Amenity _amenity = new BUS_Amenity();
        public Form_AddEditListing()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void gcAmenity_Load(object sender, EventArgs e)
        {
            gcAmenity.DataSource = _amenity.GetData();
            gvAmenity.PopulateColumns();
            gvAmenity.BestFitColumns();
        }

    }
}
