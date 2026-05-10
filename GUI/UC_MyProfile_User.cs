using BUS;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Tile;
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

namespace DangNhap_Form
{
    public partial class UC_MyProfile_User : UserControl
    {
        private readonly long _userID;
        private readonly BUS_Guest _busGuest = new BUS_Guest();
        public UC_MyProfile_User(long userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void UC_MyProfile_User_Load(object sender, EventArgs e)
        {
            LoadGender();

            LoadProfile();

            SetupRecentStayTileView();

            LoadRecentStays();
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
        private void LoadProfile()
        {
            var profile = _busGuest.GetGuestProfile(_userID);
            if (profile == null)
            {
                XtraMessageBox.Show("Guest profile not found.", "Error");
                return;
            }

            // Header
            lblGuestName.Text = profile.FullName;
            if (!string.IsNullOrEmpty(profile.ProfilePicture))
                picAvatar.LoadAsync(profile.ProfilePicture);
            // else: giữ ảnh mặc định

            // Personal Info
            txtFullname.Text = profile.FullName;
            txtEmail.Text = profile.Email;
            txtPhone.Text = profile.PhoneNumber ?? "";
            cbGender.EditValue = profile.Gender;
            deBirthday.Text = profile.BirthDate?.ToString("MMMM dd, yyyy") ?? "";
            txtCountry.Text = profile.Country ?? "";
            txtLanguages.Text = profile.PreferredLanguage ?? "English";

            // Identity (Guest)
            txtLoyaltyPoint.Text = profile.LoyaltyPoints.ToString(); // Đã đổi tên label thành "Loyalty Points"
            txtPreferlanguage.Text = profile.PreferredLanguage;
            // National ID
            txtNationalID.Text = profile.NationalID ?? "";
            // Verification status
            lblVerificationID.Text = profile.NationalIDVerified ? "VERIFIED" : "PENDING";
            lblVerificationID.ForeColor = profile.NationalIDVerified ? System.Drawing.Color.Green : System.Drawing.Color.OrangeRed;

            
        }
        private void LoadRecentStays()
        {
            gcRecentStays.DataSource =
                _busGuest.GetRecentStays(_userID);
        }
        private void SetupRecentStayTileView()
        {
            tvRecentStays.OptionsTiles.RowCount = 1;

            tvRecentStays.OptionsTiles.ItemSize =
                new Size(350, 320);

            tvRecentStays.OptionsTiles.Padding =
                new Padding(18);

            tvRecentStays.OptionsTiles.IndentBetweenItems = 18;

            tvRecentStays.OptionsTiles.Orientation =
                Orientation.Horizontal;

            tvRecentStays.OptionsTiles.ScrollMode =
                TileControlScrollMode.TouchScrollBar;

            tvRecentStays.OptionsTiles.StretchItems = false;

            tvRecentStays.OptionsBehavior.AllowSmoothScrolling = true;

            tvRecentStays.FocusBorderColor = Color.Transparent;

            // tvRecentStays.OptionsSelection.EnableAppearanceFocusedCell = false;

            tvRecentStays.Appearance.ItemFocused.BackColor = Color.Transparent;

            tvRecentStays.Appearance.ItemNormal.BorderColor = Color.Transparent;
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
            int loyaltyPoints = int.Parse(txtLoyaltyPoint.Text.ToString());
            string preferLanguage = txtPreferlanguage.Text.ToString();
            string nationalID = txtNationalID.Text.ToString();

            ET_Guest data = new ET_Guest(_userID, fullName, email, phoneNumber, gender, birthDate, country, loyaltyPoints, preferLanguage, nationalID);
            if (_busGuest.UpdateGuestProfile(data))
            {
                
            }
            else
                XtraMessageBox.Show("Some error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tvRecentStays_HtmlElementMouseClick(object sender, TileViewHtmlElementMouseEventArgs e)
        {
            var row = tvRecentStays.GetRow(e.RowHandle) as DTO_RecentStay;

            if (row == null) return;

            // ADD CARD

            if (row.IsAddCard)
            {
                XtraMessageBox.Show(
                    "Open booking screen here");

                return;
            }

            // NORMAL CARD

            XtraMessageBox.Show(
                $"Booking ID: {row.BookingID}");
        }
    }
}
