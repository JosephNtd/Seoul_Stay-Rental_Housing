using BUS;
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
    public partial class dlgBankAccount : Form
    {
        private readonly long _hostUserId;
        private ET_HostBankAccount _existingAccount;
        private readonly bool _isInternational;
        private readonly BUS_Host _bus = new BUS_Host();
        public dlgBankAccount(long hostUserId, ET_HostBankAccount existing = null, bool isInternational = false)
        {
            InitializeComponent();
            _hostUserId = hostUserId;
            _existingAccount = existing;
            _isInternational = isInternational;

            if (isInternational)
                this.Text = "Link International Account";

            // Cấu hình comboBoxEdit1 (Bank Name) cho phép nhập tự do
            comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // (Có thể thêm danh sách ngân hàng mẫu nếu muốn)

            if (existing != null)
            {
                // Đổ dữ liệu hiện có
                comboBoxEdit1.Text = existing.BankName;
                txtAccountNumber.Text = existing.AccountNumber;
                txtAccountHolder.Text = existing.AccountHolder;
                chkIsPrimary.Checked = existing.IsPrimary;
            }
        }

        private void dlgBankAccount_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string bankName = comboBoxEdit1.Text.Trim();
            string accountNumber = txtAccountNumber.Text.Trim();
            string accountHolder = txtAccountHolder.Text.Trim();

            if (string.IsNullOrWhiteSpace(bankName) ||
                string.IsNullOrWhiteSpace(accountNumber) ||
                string.IsNullOrWhiteSpace(accountHolder))
            {
                XtraMessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo hoặc cập nhật đối tượng
            if (_existingAccount == null)
                _existingAccount = new ET_HostBankAccount();

            _existingAccount.HostUserID = _hostUserId;
            _existingAccount.BankName = bankName;
            _existingAccount.AccountNumber = accountNumber;
            _existingAccount.AccountHolder = accountHolder;
            _existingAccount.IsPrimary = chkIsPrimary.Checked;
            // IsVerified mặc định false (sẽ được admin xác minh sau)
            if (_existingAccount.ID == 0)
            {
                _existingAccount.GUID = Guid.NewGuid();
                _existingAccount.CreatedDate = DateTime.Now;
                _existingAccount.IsActive = true;
                _existingAccount.IsVerified = false;
            }

            try
            {
                _bus.SaveBankAccount(_existingAccount);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Save failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
