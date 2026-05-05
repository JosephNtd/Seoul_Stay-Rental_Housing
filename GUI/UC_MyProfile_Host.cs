using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class UC_MyProfile_Host : UserControl
    {
        private readonly long _userId;
        private readonly BUS_Host _busHost = new BUS_Host();
        private List<ET_HostBankAccount> _bankAccounts;

        public UC_MyProfile_Host(long userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadData();
        }
        private void LoadData()
        {
            var profile = _busHost.GetHostProfile(_userId);
            if (profile == null)
            {
                XtraMessageBox.Show("Host profile not found.", "Error");
                return;
            }

            // --- Header ---
            lblHostName.Text = profile.FullName;
            // Ảnh đại diện: nếu có ProfilePicture thì load
            if (!string.IsNullOrEmpty(profile.ProfilePicture))
                picAvatar.LoadAsync(profile.ProfilePicture);
            else
                picAvatar.Image = Properties.Resources.plus; // thêm ảnh mặc định

            // Rating
            ratingStars.Rating = (decimal)(profile.Rating ?? 0);
            lblRatingText.Text = $"{profile.Rating:F1} stars · {profile.TotalReviews} Reviews";

            // Superhost
            lblSuperhost.Visible = (profile.Rating >= 4.8m && profile.TotalReviews >= 50);

            // --- Identity ---
            txtBusinessLicense.Text = profile.BusinessLicense ?? "Not provided";
            txtTaxCode.Text = profile.TaxCode ?? "Not provided";
            bool verified = profile.IsVerified;
            imgVerified.Visible = verified;
            lblVerificationStatus.Text = verified ? "VERIFIED" : "PENDING";
            lblVerificationStatus.ForeColor = verified ? Color.FromArgb(0, 192, 0) : Color.OrangeRed;

            // --- Personal ---
            txtFullname.Text = profile.FullName;
            txtPhone.Text = profile.PhoneNumber ?? "";
            txtGender.Text = profile.Gender == 1 ? "Male" : profile.Gender == 2 ? "Female" : "Other";
            txtEmail.Text = profile.Email;
            txtLanguages.Text = "English, Korean"; // nếu có field, chưa có trong DB thì để mặc định
            txtBirthday.Text = profile.BirthDate?.ToString("MMMM dd, yyyy") ?? "";
            txtCountry.Text = profile.Country ?? "";

            // --- Bank Accounts ---
            LoadBankAccounts();
        }
        private void LoadBankAccounts()
        {
            _bankAccounts = _busHost.GetBankAccounts(_userId);
            pnlAccountList.Controls.Clear();

            if (_bankAccounts.Count == 0)
            {
                // Hiển thị thông báo nếu chưa có tài khoản
                pnlAccountList.Controls.Add(new LabelControl
                {
                    Text = "No bank accounts added yet.",
                    Location = new Point(3, 3),
                    AutoSize = true
                });
            }
            else
            {
                foreach (var acc in _bankAccounts)
                {
                    var card = CreateBankAccountCard(acc);
                    pnlAccountList.Controls.Add(card);
                }
            }

            // Thêm card "Link International Account" 
            var linkCard = CreateLinkInternationalCard();
            pnlAccountList.Controls.Add(linkCard);
        }
        private PanelControl CreateBankAccountCard(ET_HostBankAccount account)
        {
            // Card có chiều cao cố định, rộng theo panel
            PanelControl card = new PanelControl
            {
                Height = 80,
                Width = pnlAccountList.Width - 10,
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple,
                Margin = new Padding(3),
                Tag = account
            };

            // Tiêu đề: Tên ngân hàng
            LabelControl lblBank = new LabelControl
            {
                Text = account.BankName,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 10)
            };

            // Tài khoản ẩn (mask)
            LabelControl lblNumber = new LabelControl
            {
                Text = MaskAccountNumber(account.AccountNumber),
                Location = new Point(10, 30)
            };

            // Chủ tài khoản
            LabelControl lblHolder = new LabelControl
            {
                Text = account.AccountHolder,
                Location = new Point(10, 50)
            };

            // Icon verified (nếu có)
            PictureEdit verifiedIcon = new PictureEdit
            {
                Image = account.IsVerified ? Properties.Resources.verified : Properties.Resources.declined,
                //SizeMode = PictureSizeMode.Zoom,
                Width = 16,
                Height = 16,
                Location = new Point(card.Width - 100, 10)
            };
            verifiedIcon.Properties.SizeMode = PictureSizeMode.Zoom;
            // Nút Edit
            SimpleButton btnEdit = new SimpleButton
            {
                Text = "Edit",
                Location = new Point(card.Width - 120, 40),
                Width = 50,
                Tag = account
            };
            btnEdit.Click += (s, e) =>
            {
                var acc = (s as SimpleButton).Tag as ET_HostBankAccount;
                OpenBankDialog(acc);
            };

            // Nút Delete
            SimpleButton btnDelete = new SimpleButton
            {
                Text = "Delete",
                Location = new Point(card.Width - 60, 40),
                Width = 50,
                Tag = account,
                Appearance = { ForeColor = Color.Red }
            };
            btnDelete.Click += (s, e) =>
            {
                var acc = (s as SimpleButton).Tag as ET_HostBankAccount;
                if (MessageBox.Show("Remove this bank account?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _busHost.DeleteBankAccount(acc.ID);
                    LoadBankAccounts();
                }
            };

            card.Controls.Add(lblBank);
            card.Controls.Add(lblNumber);
            card.Controls.Add(lblHolder);
            card.Controls.Add(verifiedIcon);
            card.Controls.Add(btnEdit);
            card.Controls.Add(btnDelete);

            return card;
        }

        private string MaskAccountNumber(string fullNumber)
        {
            if (string.IsNullOrEmpty(fullNumber) || fullNumber.Length <= 4)
                return "****";
            return new string('*', fullNumber.Length - 4) + fullNumber.Substring(fullNumber.Length - 4);
        }

        private PanelControl CreateLinkInternationalCard()
        {
            PanelControl card = new PanelControl
            {
                Height = 80,
                Width = pnlAccountList.Width - 10,
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple,
                Margin = new Padding(3),
                Appearance = { BackColor = Color.FromArgb(240, 246, 255) },
                Cursor = Cursors.Hand
            };

            PictureEdit icon = new PictureEdit
            {
                Image = Properties.Resources.plus, // cần thêm ảnh này hoặc dùng ảnh khác
                // SizeMode = PictureSizeMode.Zoom,
                Width = 32,
                Height = 32,
                Location = new Point(10, (card.Height - 32) / 2)
            };
            icon.Properties.SizeMode = PictureSizeMode.Zoom;

            LabelControl lblTitle = new LabelControl
            {
                Text = "Link International Account",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(50, 10)
            };

            LabelControl lblDesc = new LabelControl
            {
                Text = "Connect your global bank account for international transfers.",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(50, 30)
            };

            // Click vào bất kỳ đâu cũng mở dialog
            card.Click += (s, e) => OpenBankDialog(null, true);
            icon.Click += (s, e) => OpenBankDialog(null, true);
            lblTitle.Click += (s, e) => OpenBankDialog(null, true);
            lblDesc.Click += (s, e) => OpenBankDialog(null, true);

            card.Controls.Add(icon);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblDesc);
            return card;
        }

        private void OpenBankDialog(ET_HostBankAccount existing = null, bool isInternational = false)
        {
            dlgBankAccount dlg = new dlgBankAccount(_userId, existing, isInternational);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadBankAccounts(); // refresh list
            }
        }

        // ========== Event handlers ==========
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            OpenBankDialog(null);
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            // Sau này sẽ mở form chỉnh sửa hồ sơ
            XtraMessageBox.Show("Edit Profile feature will be implemented soon.", "Info");
        }

        private void btnViewListing_Click(object sender, EventArgs e)
        {
            // Quay lại danh sách của host (sẽ được xử lý bởi form cha)
            OnBackToManagerRequested();
        }

        // Sự kiện để form cha bắt và chuyển về UC_Management
        public event EventHandler BackToManagerRequested;
        protected virtual void OnBackToManagerRequested()
        {
            BackToManagerRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
