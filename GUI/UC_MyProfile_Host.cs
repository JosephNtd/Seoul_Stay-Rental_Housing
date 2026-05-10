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
using static DevExpress.XtraEditors.Mask.Design.MaskSettingsForm.DesignInfo.MaskManagerInfo;

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
            
        }

        private void UC_MyProfile_Host_Load(object sender, EventArgs e)
        {
            LoadGender();
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
            cbGender.EditValue = profile.Gender;
            txtEmail.Text = profile.Email;
            txtLanguages.Text = "English, Korean"; // nếu có field, chưa có trong DB thì để mặc định
            deBirthday.EditValue = profile.BirthDate?.ToString("MMMM dd, yyyy") ?? "";
            txtCountry.Text = profile.Country ?? "";

            // --- Bank Accounts ---
            LoadBankAccounts();
            SetupBankTileView();
        }

        private void LoadGender()
        {
            var genders = new[]
            {
                new { Id = (byte)1, Name = "Male" },
                new { Id = (byte)2, Name = "Female" },
                new { Id = (byte)3, Name = "Other" }
            };

            cbGender.Properties.DataSource = genders;
            cbGender.Properties.DisplayMember = "Name";
            cbGender.Properties.ValueMember = "Id";

            cbGender.Properties.NullText = "-- Select Gender --";

            cbGender.Properties.Columns.Clear();

            cbGender.Properties.Columns.Add(
                new LookUpColumnInfo("Name", "Gender")
            );

            cbGender.Properties.ShowHeader = false;
        }
        private void LoadBankAccounts()
        {
            var data = _busHost.GetBankAccounts(_userId);

            data.Add(new ET_HostBankAccount
            {
                IsAddCard = true
            });

            gcBankAccounts.DataSource = data;

            tvBankAccounts.PopulateColumns();

            tvBankAccounts.RefreshData();
        }
        private void SetupBankTileView()
        {
            gcBankAccounts.Dock = DockStyle.Fill;

            tvBankAccounts.OptionsTiles.RowCount = 0;

            tvBankAccounts.Columns.Clear();

            tvBankAccounts.Columns.AddVisible("BankName");
            tvBankAccounts.Columns.AddVisible("MaskedAccountNumber");
            tvBankAccounts.Columns.AddVisible("AccountHolder");
            tvBankAccounts.Columns.AddVisible("IsPrimary");
            tvBankAccounts.Columns.AddVisible("IsVerified");

            tvBankAccounts.OptionsTiles.ItemSize =
                new Size(380, 400);

            tvBankAccounts.OptionsTiles.Padding =
                new Padding(20);

            tvBankAccounts.OptionsTiles.IndentBetweenItems = 30;

            tvBankAccounts.OptionsTiles.RowCount = 0;

            tvBankAccounts.OptionsTiles.LayoutMode =
                DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.Default;

            tvBankAccounts.OptionsTiles.ScrollMode = TileControlScrollMode.TouchScrollBar;

            tvBankAccounts.OptionsTiles.RowCount = 0;

            tvBankAccounts.OptionsTiles.Orientation =
                Orientation.Vertical;
        }


        private void OpenBankDialog(ET_HostBankAccount existing = null, bool isInternational = false)
        {
            dlgBankAccount dlg = new dlgBankAccount(_userId, existing, isInternational);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadBankAccounts(); // refresh list
            }
        }
        private void OpenDelete(ET_HostBankAccount item)
        {
            var result = MessageBox.Show(
                "Are you sure you want to delete this account?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.Yes)
            {
                if (_busHost.DeleteBankAccount(item.ID))
                {
                    LoadBankAccounts();
                }
                else
                    MessageBox.Show("aaa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ========== Event handlers ==========
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            OpenBankDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to update new infomation?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.No)
                return;

            string fullName = txtFullname.Text.ToString();
            string email = txtEmail.Text.ToString();
            string phoneNumber = txtPhone.Text.ToString();
            byte gender = (byte)cbGender.EditValue;
            DateTime birthDate = deBirthday.DateTime;
            string country = txtCountry.Text.ToString();
            string businessLiscense = txtBusinessLicense.Text.ToString();
            string taxCode = txtTaxCode.Text.ToString();

            ET_Host data = new ET_Host(_userId, fullName, email, phoneNumber, gender, birthDate, country, businessLiscense, taxCode);
            if (_busHost.UpdateHostProfile(data))
            {
                LoadBankAccounts();
            }
            else
                XtraMessageBox.Show("Some error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tvBankAccounts_HtmlElementMouseClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewHtmlElementMouseEventArgs e)
        {
            var item = tvBankAccounts.GetRow(e.RowHandle) as ET_HostBankAccount;
            if (item == null) return;

            if (e.ElementId == "editBtn")
            {
                OpenBankDialog(item);
            }
            else if (e.ElementId == "deleteBtn")
            {
                OpenDelete(item);
            }
            else if(e.ElementId == "addBtn")
            {
                OpenBankDialog(null, true);
                return;
            }
        }

        
    }
}