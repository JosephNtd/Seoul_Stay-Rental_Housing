using BUS;
using DTO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using ET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace DangNhap_Form
{
    public partial class Form_AddEditListing : Form
    {
        BUS_Amenity _amenity;
        BUS_Attraction _attraction;
        BUS_Items _items;
        BindingList<DTO_Amenities> _amenityData;
        BindingList<DTO_Attraction_Distance> _attractionData;
        long _hostUserId;
        bool _allowTabChange;

        public ET_Items _et { get; set; }
        public bool Mode { get; set; }

        public Form_AddEditListing(ET_Items et, bool mode)
        {
            InitializeComponent();
            InitializeServices();
            _et = et;
            Mode = mode;
            _hostUserId = et != null && et.HostUserID > 0 ? et.HostUserID : et?.UserID ?? 0;
        }

        public Form_AddEditListing(long hostUserId, bool mode)
        {
            InitializeComponent();
            InitializeServices();
            _hostUserId = hostUserId;
            Mode = mode;
        }

        public Form_AddEditListing(bool mode) : this(0, mode)
        {
        }

        private void InitializeServices()
        {
            _amenity = new BUS_Amenity();
            _attraction = new BUS_Attraction();
            _items = new BUS_Items();
            tabControl.SelectedPageChanging += tabControl_SelectedPageChanging;
            tabControl.SelectedPageChanged += tabControl_SelectedPageChanged;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Mode)
            {
                SaveListing();
            }
            else
            {
                Close();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            SaveListing();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var index = tabControl.SelectedTabPageIndex;

            if (index == 0 && !ValidateListingDetails())
            {
                return;
            }

            if (index == 1 && !ValidateAmenities())
            {
                return;
            }

            MoveToTab(Math.Min(index + 1, tabControl.TabPages.Count - 1));
        }

        private void gcAmenity_Load(object sender, EventArgs e)
        {
            ConfigureAmenityGrid();
        }

        private void gcAttraction_Load(object sender, EventArgs e)
        {
            ConfigureAttractionGrid();
        }

        private void SummaryFooter(GridView gridView)
        {
            if (gridView.Columns.Count == 0)
            {
                return;
            }

            var column = gridView.Columns["Name"] ?? gridView.Columns["Attraction"];
            if (column == null)
            {
                column = gridView.VisibleColumns.Count > 0 ? gridView.VisibleColumns[0] : gridView.Columns[0];
            }
            column.Summary.Clear();
            column.Summary.Add(
                DevExpress.Data.SummaryItemType.Count,
                column.FieldName,
                "{0} items found."
            );
        }

        private void Form_AddEditListing_Load(object sender, EventArgs e)
        {
            PrepareControls();
            LoadData();
            LoadListing();
            ConfigureMode();
            UpdateNavigationButtons();
        }

        private void LoadData()
        {
            cbType.Properties.DataSource = _items.GetItemTypes();
            cbType.Properties.DisplayMember = "Name";
            cbType.Properties.ValueMember = "ID";

            cbType.Properties.PopulateColumns();
            if (cbType.Properties.Columns["ID"] != null)
            {
                cbType.Properties.Columns["ID"].Visible = false;
            }
            if (cbType.Properties.Columns["GUID"] != null)
            {
                cbType.Properties.Columns["GUID"].Visible = false;
            }

            cbType.Properties.NullText = "-- Select type --";
            cbType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cbType.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
        }

        private void PrepareControls()
        {
            numCapacity.Minimum = 0;
            numBed.Minimum = 0;
            numBedroom.Minimum = 0;
            numBathroom.Minimum = 0;
            numTimeMinimum.Minimum = 0;
            numTimeMaximum.Minimum = 0;

            numCapacity.Maximum = 10000;
            numBed.Maximum = 10000;
            numBedroom.Maximum = 10000;
            numBathroom.Maximum = 10000;
            numTimeMinimum.Maximum = 10000;
            numTimeMaximum.Maximum = 10000;

            if (!Mode)
            {
                numCapacity.Value = 1;
                numBed.Value = 1;
                numBedroom.Value = 1;
                numBathroom.Value = 1;
                numTimeMinimum.Value = 1;
                numTimeMaximum.Value = 365;
            }
        }

        private void LoadListing()
        {
            long? itemId = Mode && _et != null ? (long?)_et.ID : null;

            _amenityData = new BindingList<DTO_Amenities>(_amenity.GetData(itemId));
            _attractionData = new BindingList<DTO_Attraction_Distance>(_attraction.GetData(itemId));
            gcAmenity.DataSource = _amenityData;
            gcAttraction.DataSource = _attractionData;
            ConfigureAmenityGrid();
            ConfigureAttractionGrid();

            if (!Mode || _et == null)
            {
                return;
            }

            cbType.EditValue = _et.ItemTypeID;
            txtTitle.Text = _et.Title;
            numCapacity.Value = _et.Capacity;
            numBed.Value = _et.NumberOfBeds;
            numBathroom.Value = _et.NumberOfBathrooms;
            numBedroom.Value = _et.NumberOfBedrooms;
            txtExactAddress.Text = _et.ExactAddress;
            txtApproxAdress.Text = _et.ApproximateAddress;
            txtDescription.Text = _et.Description;
            txtHostRule.Text = _et.HostRules;
            numTimeMaximum.Value = _et.MaximumNights;
            numTimeMinimum.Value = _et.MinimumNights;
        }

        private void ConfigureMode()
        {
            Text = Mode && _et != null ? $"Edit Listing - {_et.Title}" : "Add Listing";

            if (!Mode)
            {
                tabControl.SelectedTabPageIndex = 0;
            }
        }

        private void ConfigureAmenityGrid()
        {
            if (gvAmenity.Columns.Count == 0)
            {
                gvAmenity.PopulateColumns();
            }

            if (gvAmenity.Columns.Count == 0)
            {
                return;
            }

            SummaryFooter(gvAmenity);
            gvAmenity.OptionsBehavior.Editable = true;
            gvAmenity.OptionsBehavior.ReadOnly = false;

            if (gvAmenity.Columns["ID"] != null)
            {
                gvAmenity.Columns["ID"].Visible = false;
            }

            if (gvAmenity.Columns["Name"] != null)
            {
                gvAmenity.Columns["Name"].OptionsColumn.AllowEdit = false;
                gvAmenity.Columns["Name"].OptionsColumn.ReadOnly = true;
            }

            if (gvAmenity.Columns["IsSelected"] != null)
            {
                gvAmenity.Columns["IsSelected"].Caption = "Available";
                gvAmenity.Columns["IsSelected"].ColumnEdit = repositoryItemCheckEdit1;
                gvAmenity.Columns["IsSelected"].OptionsColumn.AllowEdit = true;
                gvAmenity.Columns["IsSelected"].OptionsColumn.ReadOnly = false;
                gvAmenity.Columns["IsSelected"].VisibleIndex = 0;
            }

            gvAmenity.BestFitColumns();
        }

        private void ConfigureAttractionGrid()
        {
            if (gvAttraction.Columns.Count == 0)
            {
                gvAttraction.PopulateColumns();
            }

            if (gvAttraction.Columns.Count == 0)
            {
                return;
            }

            SummaryFooter(gvAttraction);
            gvAttraction.OptionsBehavior.Editable = true;
            gvAttraction.OptionsBehavior.ReadOnly = false;

            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvAttraction.Columns)
            {
                col.OptionsColumn.AllowEdit = false;
            }

            if (gvAttraction.Columns["AttractionID"] != null)
            {
                gvAttraction.Columns["AttractionID"].Visible = false;
            }

            SetEditableAttractionColumn("Distance", "Distance (km)");
            SetEditableAttractionColumn("OnFoot", "On Foot (minutes)");
            SetEditableAttractionColumn("ByCar", "By Car (minutes)");
            gvAttraction.BestFitColumns();
        }

        private void SetEditableAttractionColumn(string fieldName, string caption)
        {
            var column = gvAttraction.Columns[fieldName];
            if (column == null)
            {
                return;
            }

            column.Caption = caption;
            column.OptionsColumn.AllowEdit = true;
            column.OptionsColumn.ReadOnly = false;
        }

        private void tabControl_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (!Mode && !_allowTabChange && e.Page != tabControl.SelectedTabPage)
            {
                e.Cancel = true;
            }
        }

        private void tabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            UpdateNavigationButtons();
        }

        private void MoveToTab(int index)
        {
            _allowTabChange = true;
            tabControl.SelectedTabPageIndex = index;
            _allowTabChange = false;
            UpdateNavigationButtons();
        }

        private void UpdateNavigationButtons()
        {
            if (Mode)
            {
                btnClose.Visible = true;
                btnCancel.Visible = false;
                btnNext.Visible = false;
                btnFinish.Visible = false;
                return;
            }

            var index = tabControl.SelectedTabPageIndex;
            btnClose.Visible = false;
            btnCancel.Visible = index < 2;
            btnNext.Visible = index < 2;
            btnFinish.Visible = index == 2;
        }

        private bool SaveListing()
        {
            CommitGridEditors();

            if (!ValidateListingDetails() || !ValidateAmenities() || !ValidateAttractions())
            {
                return false;
            }

            var item = BuildItemFromForm();
            var amenityIds = GetSelectedAmenityIds();
            var attractions = _attractionData?.ToList() ?? new List<DTO_Attraction_Distance>();
            var success = Mode
                ? _items.Update(item, amenityIds, attractions)
                : _items.Add(item, amenityIds, attractions);

            if (!success)
            {
                MessageBox.Show(_items.LastError ?? "Unable to save listing.",
                    "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _et = item;
            DialogResult = DialogResult.OK;
            Close();
            return true;
        }

        private ET_Items BuildItemFromForm()
        {
            var hostUserId = _hostUserId > 0 ? _hostUserId : _et?.UserID ?? 0;

            return new ET_Items
            {
                ID = _et?.ID ?? 0,
                GUID = _et?.GUID ?? Guid.Empty,
                UserID = hostUserId,
                HostUserID = hostUserId,
                ItemTypeID = Convert.ToInt64(cbType.EditValue),
                AreaID = _items.GetAreaIdByApproximateAddress(txtApproxAdress.Text.Trim()),
                Title = txtTitle.Text.Trim(),
                Capacity = Convert.ToInt32(numCapacity.Value),
                NumberOfBeds = Convert.ToInt32(numBed.Value),
                NumberOfBedrooms = Convert.ToInt32(numBedroom.Value),
                NumberOfBathrooms = Convert.ToInt32(numBathroom.Value),
                ExactAddress = txtExactAddress.Text.Trim(),
                ApproximateAddress = txtApproxAdress.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                HostRules = txtHostRule.Text.Trim(),
                MinimumNights = Convert.ToInt32(numTimeMinimum.Value),
                MaximumNights = Convert.ToInt32(numTimeMaximum.Value)
            };
        }

        private List<long> GetSelectedAmenityIds()
        {
            CommitGridEditors();
            return (_amenityData ?? new BindingList<DTO_Amenities>())
                .Where(x => x.IsSelected)
                .Select(x => x.ID)
                .ToList();
        }

        private bool ValidateListingDetails()
        {
            if (!Mode && _hostUserId <= 0)
            {
                return ShowValidation("Cannot identify the current owner for this listing.");
            }

            if (cbType.EditValue == null)
            {
                return ShowValidation("Please select a listing type.", cbType);
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                return ShowValidation("Please enter the listing title.", txtTitle);
            }

            if (numCapacity.Value <= 0 || numBed.Value <= 0 || numBedroom.Value <= 0 || numBathroom.Value <= 0)
            {
                return ShowValidation("Capacity, beds, bedrooms and bathrooms must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(txtApproxAdress.Text))
            {
                return ShowValidation("Please enter the approximate address.", txtApproxAdress);
            }

            if (_items.GetAreaIdByApproximateAddress(txtApproxAdress.Text.Trim()) <= 0)
            {
                return ShowValidation("Approximate Address must match an existing area.", txtApproxAdress);
            }

            if (string.IsNullOrWhiteSpace(txtExactAddress.Text))
            {
                return ShowValidation("Please enter the exact address.", txtExactAddress);
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                return ShowValidation("Please enter the description.", txtDescription);
            }

            if (string.IsNullOrWhiteSpace(txtHostRule.Text))
            {
                return ShowValidation("Please enter the host rules.", txtHostRule);
            }

            if (numTimeMinimum.Value <= 0 || numTimeMinimum.Value > numTimeMaximum.Value)
            {
                return ShowValidation("Minimum nights must be greater than zero and less than or equal to maximum nights.");
            }

            return true;
        }

        private bool ValidateAmenities()
        {
            CommitGridEditors();
            return true;
        }

        private bool ValidateAttractions()
        {
            CommitGridEditors();

            var attractions = _attractionData ?? new BindingList<DTO_Attraction_Distance>();

            foreach (var attraction in attractions)
            {
                if (attraction.Distance.HasValue && attraction.Distance.Value <= 0)
                {
                    return ShowValidation("Distance must be greater than zero.");
                }

                if ((attraction.OnFoot.HasValue || attraction.ByCar.HasValue) && !attraction.Distance.HasValue)
                {
                    return ShowValidation("Please enter distance before entering travel time.");
                }

                if (attraction.OnFoot.HasValue && attraction.OnFoot.Value < 0)
                {
                    return ShowValidation("On foot duration cannot be negative.");
                }

                if (attraction.ByCar.HasValue && attraction.ByCar.Value < 0)
                {
                    return ShowValidation("By car duration cannot be negative.");
                }
            }

            if (!Mode && attractions.Count(x => x.Distance.HasValue) < 2)
            {
                return ShowValidation("Please enter the distance for at least two attractions.");
            }

            return true;
        }

        private void CommitGridEditors()
        {
            gvAmenity.CloseEditor();
            gvAmenity.UpdateCurrentRow();
            gvAttraction.CloseEditor();
            gvAttraction.UpdateCurrentRow();
        }

        private bool ShowValidation(string message, Control control = null)
        {
            MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control?.Focus();
            return false;
        }
    }
}
