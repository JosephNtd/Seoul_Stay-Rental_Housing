using BUS;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
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
        private PopupMenu popupAccount;

        public GUI_HomePage_Host()
        {
            InitializeComponent();
        }

        public GUI_HomePage_Host(ET_Users currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            SetupAccountMenu();
        }


            private void SetupAccountMenu()
        {
            // Tạo ContextMenuStrip cho menu tài khoản
            contextMenu = new ContextMenuStrip();
            var itemProfile = new ToolStripMenuItem("My Profile");
            itemProfile.Click += (s, e) => ShowUC(new UC_MyProfile_Host(_currentUser.ID));
            var itemSettings = new ToolStripMenuItem("Settings");
            itemSettings.Click += (s, e) =>
                XtraMessageBox.Show("Settings page will be available soon.", "Settings");
            var itemLogout = new ToolStripMenuItem("Log-out");
            itemLogout.Click += (s, e) => Logout();
            contextMenu.Items.AddRange(new ToolStripItem[] { itemProfile, itemSettings, itemLogout });

            // Tạo phần tử "M" ở cuối AccordionControl
            //var accountElement = new AccordionControlElement
            //{
            //    Text = "M",  // hoặc lấy chữ cái đầu tên
            //    Style = ElementStyle.Item,
            //    Height = 40
            //};
            acc_MyProfile.Click += (s, e) =>
            {
                // Hiển thị context menu ngay tại vị trí chuột
                contextMenu.Show(Cursor.Position);
            };

            // Thêm vào cuối danh sách các mục của AccordionControl
            //accordionControl1.Elements.Add(accountElement);
        }
        
        
        private void Logout()
        {
            // Đóng form host hiện tại
            this.Close();
            // Mở form login
            var loginForm = new Form_Login();
            loginForm.Show();
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
