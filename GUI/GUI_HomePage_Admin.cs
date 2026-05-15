using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
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
    public partial class GUI_HomePage_Admin : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public GUI_HomePage_Admin()
        {
            InitializeComponent();
        }

        private void ShowUC(UserControl uc)
        {
            main.SuspendLayout();
            
            main.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            main.Controls.Add(uc);

            main.ResumeLayout();
        }

        private void acc_User_Click(object sender, EventArgs e)
        {
            ShowUC(new UC_UserManagement());
        }

        private void accArrea_Click(object sender, EventArgs e)
        {
            ShowUC(new UC_AreaManagement());
        }

        private void accAmmenities_Click(object sender, EventArgs e)
        {
            ShowUC(new UC_AmenityManagement());
        }

        private void accAttraction_Click(object sender, EventArgs e)
        {
            ShowUC(new UC_AttractionManagement());
        }

        private void accCoupons_Click(object sender, EventArgs e)
        {
            ShowUC(new UC_CouponManagement());
        }

        private void accItemTypes_Click(object sender, EventArgs e)
        {
            ShowUC(new UC_ItemTypesManagement());

        }

        private void acc_Services_Click(object sender, EventArgs e)
        {
            ShowUC(new UC_ServicesManagement());
        }

        private void acc_ServiceTypes_Click(object sender, EventArgs e)
        {
            ShowUC(new UC_ServiceTypeManagement());
        }
    }
}
