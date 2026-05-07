namespace DangNhap_Form
{
    partial class Form_AddEditListing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabItenDetail = new DevExpress.XtraTab.XtraTabPage();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.cbType = new DevExpress.XtraEditors.LookUpEdit();
            this.numTimeMaximum = new System.Windows.Forms.NumericUpDown();
            this.numTimeMinimum = new System.Windows.Forms.NumericUpDown();
            this.numBathroom = new System.Windows.Forms.NumericUpDown();
            this.numBedroom = new System.Windows.Forms.NumericUpDown();
            this.numBed = new System.Windows.Forms.NumericUpDown();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.txtHostRule = new DevExpress.XtraEditors.TextEdit();
            this.txtExactAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tabAmenity = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.gcAmenity = new DevExpress.XtraGrid.GridControl();
            this.gvAmenity = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tabDistance = new DevExpress.XtraTab.XtraTabPage();
            this.gcAttraction = new DevExpress.XtraGrid.GridControl();
            this.gvAttraction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.panelBtnControl = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnFinish = new DevExpress.XtraEditors.SimpleButton();
            this.cbApproxAdress = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabItenDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeMaximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeMinimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBathroom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBedroom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHostRule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExactAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            this.tabAmenity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAmenity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAmenity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.tabDistance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAttraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBtnControl)).BeginInit();
            this.panelBtnControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbApproxAdress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.tabItenDetail;
            this.tabControl.Size = new System.Drawing.Size(829, 456);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabItenDetail,
            this.tabAmenity,
            this.tabDistance});
            // 
            // tabItenDetail
            // 
            this.tabItenDetail.Controls.Add(this.cbApproxAdress);
            this.tabItenDetail.Controls.Add(this.txtDescription);
            this.tabItenDetail.Controls.Add(this.cbType);
            this.tabItenDetail.Controls.Add(this.numTimeMaximum);
            this.tabItenDetail.Controls.Add(this.numTimeMinimum);
            this.tabItenDetail.Controls.Add(this.numBathroom);
            this.tabItenDetail.Controls.Add(this.numBedroom);
            this.tabItenDetail.Controls.Add(this.numBed);
            this.tabItenDetail.Controls.Add(this.numCapacity);
            this.tabItenDetail.Controls.Add(this.txtHostRule);
            this.tabItenDetail.Controls.Add(this.txtExactAddress);
            this.tabItenDetail.Controls.Add(this.txtTitle);
            this.tabItenDetail.Controls.Add(this.labelControl7);
            this.tabItenDetail.Controls.Add(this.labelControl6);
            this.tabItenDetail.Controls.Add(this.labelControl5);
            this.tabItenDetail.Controls.Add(this.labelControl4);
            this.tabItenDetail.Controls.Add(this.labelControl3);
            this.tabItenDetail.Controls.Add(this.labelControl13);
            this.tabItenDetail.Controls.Add(this.labelControl12);
            this.tabItenDetail.Controls.Add(this.labelControl11);
            this.tabItenDetail.Controls.Add(this.labelControl10);
            this.tabItenDetail.Controls.Add(this.labelControl9);
            this.tabItenDetail.Controls.Add(this.labelControl8);
            this.tabItenDetail.Controls.Add(this.labelControl2);
            this.tabItenDetail.Controls.Add(this.labelControl1);
            this.tabItenDetail.Name = "tabItenDetail";
            this.tabItenDetail.Size = new System.Drawing.Size(827, 431);
            this.tabItenDetail.Text = "Listing Details";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(217, 184);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(583, 26);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Text = "";
            // 
            // cbType
            // 
            this.cbType.Location = new System.Drawing.Point(106, 23);
            this.cbType.Name = "cbType";
            this.cbType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.Properties.Appearance.Options.UseFont = true;
            this.cbType.Properties.AutoHeight = false;
            this.cbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbType.Size = new System.Drawing.Size(312, 26);
            this.cbType.TabIndex = 4;
            // 
            // numTimeMaximum
            // 
            this.numTimeMaximum.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTimeMaximum.Location = new System.Drawing.Point(492, 297);
            this.numTimeMaximum.Name = "numTimeMaximum";
            this.numTimeMaximum.Size = new System.Drawing.Size(53, 27);
            this.numTimeMaximum.TabIndex = 3;
            // 
            // numTimeMinimum
            // 
            this.numTimeMinimum.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTimeMinimum.Location = new System.Drawing.Point(340, 297);
            this.numTimeMinimum.Name = "numTimeMinimum";
            this.numTimeMinimum.Size = new System.Drawing.Size(53, 27);
            this.numTimeMinimum.TabIndex = 3;
            // 
            // numBathroom
            // 
            this.numBathroom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBathroom.Location = new System.Drawing.Point(747, 61);
            this.numBathroom.Name = "numBathroom";
            this.numBathroom.Size = new System.Drawing.Size(53, 27);
            this.numBathroom.TabIndex = 3;
            // 
            // numBedroom
            // 
            this.numBedroom.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBedroom.Location = new System.Drawing.Point(519, 61);
            this.numBedroom.Name = "numBedroom";
            this.numBedroom.Size = new System.Drawing.Size(53, 27);
            this.numBedroom.TabIndex = 3;
            // 
            // numBed
            // 
            this.numBed.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBed.Location = new System.Drawing.Point(296, 61);
            this.numBed.Name = "numBed";
            this.numBed.Size = new System.Drawing.Size(53, 27);
            this.numBed.TabIndex = 3;
            this.numBed.ValueChanged += new System.EventHandler(this.numBed_ValueChanged);
            // 
            // numCapacity
            // 
            this.numCapacity.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCapacity.Location = new System.Drawing.Point(106, 61);
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(53, 27);
            this.numCapacity.TabIndex = 3;
            // 
            // txtHostRule
            // 
            this.txtHostRule.Location = new System.Drawing.Point(219, 257);
            this.txtHostRule.Name = "txtHostRule";
            this.txtHostRule.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHostRule.Properties.Appearance.Options.UseFont = true;
            this.txtHostRule.Size = new System.Drawing.Size(583, 26);
            this.txtHostRule.TabIndex = 2;
            // 
            // txtExactAddress
            // 
            this.txtExactAddress.EditValue = "";
            this.txtExactAddress.Location = new System.Drawing.Point(217, 144);
            this.txtExactAddress.Name = "txtExactAddress";
            this.txtExactAddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExactAddress.Properties.Appearance.Options.UseFont = true;
            this.txtExactAddress.Size = new System.Drawing.Size(583, 26);
            this.txtExactAddress.TabIndex = 2;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(488, 23);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Properties.Appearance.Options.UseFont = true;
            this.txtTitle.Properties.AutoHeight = false;
            this.txtTitle.Size = new System.Drawing.Size(312, 26);
            this.txtTitle.TabIndex = 2;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(39, 300);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(186, 19);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Reservation Time(Nights):";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(39, 260);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(81, 19);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Host Rules:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(37, 184);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(85, 19);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Description:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(37, 148);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(105, 19);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Exact Address:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(37, 105);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(159, 19);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Approximate Address:";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(416, 300);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(75, 19);
            this.labelControl13.TabIndex = 0;
            this.labelControl13.Text = "Maximum:";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(264, 300);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(72, 19);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "Minimum:";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(431, 27);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(37, 19);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "Title:";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(355, 65);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(158, 19);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Number of Bedrooms:";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(170, 65);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(120, 19);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Number of Beds:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(578, 65);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(163, 19);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Number of Bathrooms:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(37, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 19);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Capacity:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(37, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Type:";
            // 
            // tabAmenity
            // 
            this.tabAmenity.Controls.Add(this.panelControl2);
            this.tabAmenity.Controls.Add(this.gcAmenity);
            this.tabAmenity.Name = "tabAmenity";
            this.tabAmenity.Size = new System.Drawing.Size(827, 431);
            this.tabAmenity.Text = "Amenities";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl15);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(827, 32);
            this.panelControl2.TabIndex = 1;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(23, 9);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(211, 18);
            this.labelControl15.TabIndex = 0;
            this.labelControl15.Text = "Choose Available Amenities:";
            // 
            // gcAmenity
            // 
            this.gcAmenity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcAmenity.Location = new System.Drawing.Point(0, 33);
            this.gcAmenity.MainView = this.gvAmenity;
            this.gcAmenity.Name = "gcAmenity";
            this.gcAmenity.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcAmenity.Size = new System.Drawing.Size(828, 325);
            this.gcAmenity.TabIndex = 0;
            this.gcAmenity.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAmenity});
            this.gcAmenity.Load += new System.EventHandler(this.gcAmenity_Load);
            // 
            // gvAmenity
            // 
            this.gvAmenity.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAmenity.Appearance.FooterPanel.Options.UseFont = true;
            this.gvAmenity.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAmenity.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAmenity.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAmenity.Appearance.Row.Options.UseFont = true;
            this.gvAmenity.GridControl = this.gcAmenity;
            this.gvAmenity.Name = "gvAmenity";
            this.gvAmenity.OptionsFind.AlwaysVisible = true;
            this.gvAmenity.OptionsFind.FindDelay = 200;
            this.gvAmenity.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gvAmenity.OptionsView.ShowFooter = true;
            this.gvAmenity.RowHeight = 44;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // tabDistance
            // 
            this.tabDistance.Controls.Add(this.gcAttraction);
            this.tabDistance.Controls.Add(this.panelControl1);
            this.tabDistance.Name = "tabDistance";
            this.tabDistance.Size = new System.Drawing.Size(827, 431);
            this.tabDistance.Text = "Distance to Attraction";
            // 
            // gcAttraction
            // 
            this.gcAttraction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcAttraction.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcAttraction.Location = new System.Drawing.Point(0, 44);
            this.gcAttraction.MainView = this.gvAttraction;
            this.gcAttraction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcAttraction.Name = "gcAttraction";
            this.gcAttraction.Size = new System.Drawing.Size(828, 315);
            this.gcAttraction.TabIndex = 1;
            this.gcAttraction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAttraction});
            this.gcAttraction.Load += new System.EventHandler(this.gcAttraction_Load);
            // 
            // gvAttraction
            // 
            this.gvAttraction.ActiveFilterEnabled = false;
            this.gvAttraction.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAttraction.Appearance.FooterPanel.Options.UseFont = true;
            this.gvAttraction.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAttraction.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAttraction.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAttraction.Appearance.Row.Options.UseFont = true;
            this.gvAttraction.DetailHeight = 227;
            this.gvAttraction.GridControl = this.gcAttraction;
            this.gvAttraction.Name = "gvAttraction";
            this.gvAttraction.OptionsBehavior.ReadOnly = true;
            this.gvAttraction.OptionsEditForm.PopupEditFormWidth = 533;
            this.gvAttraction.OptionsFind.AlwaysVisible = true;
            this.gvAttraction.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gvAttraction.OptionsView.ShowFooter = true;
            this.gvAttraction.RowHeight = 29;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl14);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(827, 40);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl14.Location = new System.Drawing.Point(2, 2);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(649, 18);
            this.labelControl14.TabIndex = 0;
            this.labelControl14.Text = "Specify the distance from each close byb attraction and the time it takes to get " +
    "to them:";
            // 
            // panelBtnControl
            // 
            this.panelBtnControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBtnControl.Controls.Add(this.btnClose);
            this.panelBtnControl.Controls.Add(this.btnNext);
            this.panelBtnControl.Controls.Add(this.btnCancel);
            this.panelBtnControl.Controls.Add(this.btnFinish);
            this.panelBtnControl.Location = new System.Drawing.Point(0, 387);
            this.panelBtnControl.Name = "panelBtnControl";
            this.panelBtnControl.Size = new System.Drawing.Size(829, 69);
            this.panelBtnControl.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(452, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNext
            // 
            this.btnNext.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Location = new System.Drawing.Point(623, 21);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(537, 21);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Appearance.Options.UseFont = true;
            this.btnFinish.Location = new System.Drawing.Point(708, 21);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(80, 23);
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "Finish";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // cbApproxAdress
            // 
            this.cbApproxAdress.Location = new System.Drawing.Point(217, 101);
            this.cbApproxAdress.Name = "cbApproxAdress";
            this.cbApproxAdress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApproxAdress.Properties.Appearance.Options.UseFont = true;
            this.cbApproxAdress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbApproxAdress.Size = new System.Drawing.Size(583, 26);
            this.cbApproxAdress.TabIndex = 7;
            // 
            // Form_AddEditListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 456);
            this.ControlBox = false;
            this.Controls.Add(this.panelBtnControl);
            this.Controls.Add(this.tabControl);
            this.Name = "Form_AddEditListing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seoul Stay - Add / Edit Listing";
            this.Load += new System.EventHandler(this.Form_AddEditListing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabItenDetail.ResumeLayout(false);
            this.tabItenDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeMaximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeMinimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBathroom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBedroom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHostRule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExactAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            this.tabAmenity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAmenity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAmenity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.tabDistance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAttraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBtnControl)).EndInit();
            this.panelBtnControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbApproxAdress.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabItenDetail;
        private DevExpress.XtraTab.XtraTabPage tabAmenity;
        private DevExpress.XtraTab.XtraTabPage tabDistance;
        private DevExpress.XtraEditors.PanelControl panelBtnControl;
        private DevExpress.XtraEditors.TextEdit txtHostRule;
        private DevExpress.XtraEditors.TextEdit txtExactAddress;
        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnFinish;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.NumericUpDown numTimeMaximum;
        private System.Windows.Forms.NumericUpDown numTimeMinimum;
        private System.Windows.Forms.NumericUpDown numBathroom;
        private System.Windows.Forms.NumericUpDown numBedroom;
        private System.Windows.Forms.NumericUpDown numBed;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraGrid.GridControl gcAmenity;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAmenity;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.GridControl gcAttraction;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAttraction;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LookUpEdit cbType;
        private System.Windows.Forms.RichTextBox txtDescription;
        private DevExpress.XtraEditors.LookUpEdit cbApproxAdress;
    }
}