using BUS;
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
    public partial class GUI_HomePage_Host : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        //private UC_Management ucManagement;
        private readonly ET_Users _currentUser;
        public GUI_HomePage_Host()
        {
            InitializeComponent();
        }

        public GUI_HomePage_Host(ET_Users currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void acc_MyList_Click(object sender, EventArgs e)
        {
            //if (ucManagement == null)
            //    ucManagement = new UC_Management(_currentUser);

            ShowUC(new UC_Management(_currentUser));

        }
        private void ShowUC(UserControl uc)
        {
            main.SuspendLayout();

            main.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            main.Controls.Add(uc);

            main.ResumeLayout();
        }
        public void ShowPricingCalendar(long itemId)
        {
            var uc = new UC_PricingCalendar(itemId);
            // Khi user nhấn Back, ta quay lại UC_Management
            uc.BackRequested += (s, e) => {
                var mgmt = new UC_Management(_currentUser);
                ShowUC(mgmt);
            };
            ShowUC(uc);
        }
    }
}
