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
    public partial class Form_Login : Form
    {
        private readonly BUS_User _bus = new BUS_User();
        public Form_Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }
        private void Form_Login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.IsRemember)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
                cbKeep.Checked = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCreate_Click(object sender, EventArgs e)
        {
            Form_CreateAccount frm = new Form_CreateAccount();
            frm.ShowDialog();
        }
        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !cbShow.Checked;
        }
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password.",
                                "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var user = _bus.Login(username, password, employeeOnly: false);

            if (user == null)
            {
                MessageBox.Show("Username or password are incorrect.",
                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }
            else
            {
                MessageBox.Show("Login sucessfully!");

                if (cbKeep.Checked)
                {
                    Properties.Settings.Default.Username = txtUsername.Text;
                    Properties.Settings.Default.Password = txtPassword.Text;
                    Properties.Settings.Default.IsRemember = true;
                }
                else
                {
                    Properties.Settings.Default.IsRemember = false;
                }

                Properties.Settings.Default.Save();

                Form nextForm = null;

                if (user.IsAdmin)
                {
                    // 1. Admin
                    nextForm = new GUI_HomePage_Admin();
                }
                else
                {
                    // 2. Kiểm tra xem có phải Host không (có bản ghi trong bảng Hosts)
                    var hostProfile = new BUS_Host().GetHostProfile(user.ID);
                    if (hostProfile != null) // Nếu muốn yêu cầu Host đã được verify thì thêm: && hostProfile.IsVerified
                    {
                        nextForm = new GUI_HomePage_Host(user);
                    }
                    else
                    {
                        // 3. Guest (mặc định)
                        nextForm = new GUI_HomePage_User(user);
                    }
                }

                this.Hide();
                nextForm.ShowDialog();
                this.Show();
            }
        }
    }
}
