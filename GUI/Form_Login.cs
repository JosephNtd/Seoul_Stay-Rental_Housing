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

                Form_Management f = new Form_Management(user);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
        }

        private void Form_Login_Enter(object sender, EventArgs e)
        {
            btnLogin.PerformClick();
        }
    }
}
