using BUS;
using DevExpress.XtraEditors.Controls;
using Helper;
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
    public partial class Form_CreateAccount : Form
    {
        private readonly BUS_User _bus = new BUS_User();
        public string RegisteredUsername { get; private set; } = "";
        public Form_CreateAccount()
        {
            InitializeComponent();
        }

        private void Form_CreateAccount_Load(object sender, EventArgs e)
        {
            radioGroupGender.Properties.Items.Add(new RadioGroupItem((byte)0, "Unknown"));
            radioGroupGender.Properties.Items.Add(new RadioGroupItem((byte)1, "Male"));
            radioGroupGender.Properties.Items.Add(new RadioGroupItem((byte)2, "Female"));
            radioGroupGender.Properties.Items.Add(new RadioGroupItem((byte)3, "Other"));
            dtpBirthDate.Value = DateTime.Today.AddYears(-18);
            dtpBirthDate.MaxDate = DateTime.Today;
            txtUsername.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtRePassword.Text;
            string fullName = txtFullname.Text.Trim();
            byte gender = (byte)radioGroupGender.EditValue; // 0 = Unknown  1 = Male  2 = Female  3 = Other

            string error = ValidateRegister(
                username, password, confirmPassword,
                fullName, dtpBirthDate.Value);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Lỗi đăng ký",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!cbAgree.Checked)
            {
                MessageBox.Show("Bạn chưa chấp nhận các điều khoản",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = _bus.Register(
                username, password, fullName,
                gender, dtpBirthDate.Value);
            

            if (success)
            {
                RegisteredUsername = username;
                MessageBox.Show($"Đăng ký thành công!\nChào mừng bạn, {fullName}.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại, vui lòng thử lại.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string ValidateRegister(string username, string password,
                                        string confirmPassword, string fullName,
                                        DateTime? birthDate)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return "Username không được để trống.";
            }
            if (username.Trim().Length < 4)
                return "Username phải có ít nhất 4 ký tự.";

            if (_bus.CheckUsername(username.Trim()))
                return "Username đã tồn tại, vui lòng chọn tên khác.";

            if (string.IsNullOrWhiteSpace(password))
                return "Password không được để trống.";

            if (password.Length < 5)
                return "Password phải có ít nhất 5 ký tự.";

            if (password != confirmPassword)
                return "Xác nhận mật khẩu không khớp.";

            if (string.IsNullOrWhiteSpace(fullName))
                return "Họ tên không được để trống.";

            if (birthDate == null)
                return "Vui lòng chọn ngày sinh.";

            if (birthDate.Value > DateTime.Today)
                return "Ngày sinh không hợp lệ.";

            return "";
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Seoul Stay Terms & Conditions\n\n" +
                "1. Bằng cách tạo tài khoản, bạn đồng ý tuân thủ các điều khoản dịch vụ.\n" +
                "2. Thông tin cá nhân của bạn được bảo mật.\n" +
                "3. Nghiêm cấm sử dụng nền tảng vào mục đích vi phạm pháp luật.\n" +
                "4. Seoul Stay có quyền khóa tài khoản vi phạm điều khoản.",
                "Terms & Conditions",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            cbAgree.Enabled=true;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            // Cảnh báo nếu username đã tồn tại (không block, chỉ highlight)
            string username = txtUsername.Text.Trim();
            if (username.Length < 4) return;

            if (_bus.CheckUsername(username))
            {
                lblUsernameHint.Text = "Username đã tồn tại";
                lblUsernameHint.ForeColor = System.Drawing.Color.OrangeRed;
            }
            else
            {
                lblUsernameHint.Text = "Username hợp lệ";
                lblUsernameHint.ForeColor = System.Drawing.Color.Green;
            }
        }
        private void lblUsernameHint_TextChanged(object sender, EventArgs e)
        {
            lblUsernameHint.Text = "";
        }
        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            if (txtRePassword.Text.Length == 0)
            {
                lblPasswordHint.Text = "";
                return;
            }

            if (txtPassword.Text == txtRePassword.Text)
            {
                lblPasswordHint.Text = "Mật khẩu khớp";
                lblPasswordHint.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblPasswordHint.Text = "Mật khẩu chưa khớp";
                lblPasswordHint.ForeColor = System.Drawing.Color.OrangeRed;
            }
        }
    }
}
