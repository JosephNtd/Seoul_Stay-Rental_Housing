namespace DangNhap_Form
{
    partial class UC_AreaManagement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions4 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            this.repoBtnActions = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.StayCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AreaName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.cboSort = new DevExpress.XtraEditors.ComboBoxEdit();
            this.AreaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAmenities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Actions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAmenities = new DevExpress.XtraGrid.GridControl();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.pnlFilter = new DevExpress.XtraEditors.PanelControl();
            this.lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnInvite = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.pnlCardStats = new DevExpress.XtraEditors.PanelControl();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAmenities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAmenities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCardStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // repoBtnActions
            // 
            this.repoBtnActions.AutoHeight = false;
            editorButtonImageOptions3.Image = global::DangNhap_Form.Properties.Resources._006_pencil;
            serializableAppearanceObject9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serializableAppearanceObject9.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            serializableAppearanceObject9.Options.UseFont = true;
            serializableAppearanceObject9.Options.UseForeColor = true;
            editorButtonImageOptions4.Image = global::DangNhap_Form.Properties.Resources.bin;
            serializableAppearanceObject13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serializableAppearanceObject13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            serializableAppearanceObject13.Options.UseFont = true;
            serializableAppearanceObject13.Options.UseForeColor = true;
            this.repoBtnActions.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Edit", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", "edit", null, DevExpress.Utils.ToolTipAnchor.Default),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Delete", -1, true, true, false, editorButtonImageOptions4, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, serializableAppearanceObject14, serializableAppearanceObject15, serializableAppearanceObject16, "", "delete", null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repoBtnActions.Name = "repoBtnActions";
            this.repoBtnActions.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Active",
            "Locked"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // StayCount
            // 
            this.StayCount.Caption = "Stay Count";
            this.StayCount.FieldName = "StayCount";
            this.StayCount.Name = "StayCount";
            this.StayCount.Visible = true;
            this.StayCount.VisibleIndex = 1;
            // 
            // AreaName
            // 
            this.AreaName.Caption = "District Name";
            this.AreaName.FieldName = "AreaName";
            this.AreaName.Name = "AreaName";
            this.AreaName.Visible = true;
            this.AreaName.VisibleIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Appearance.Options.UseBackColor = true;
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.Location = new System.Drawing.Point(974, 19);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(173, 40);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cboSort
            // 
            this.cboSort.EditValue = "---Sort By---";
            this.cboSort.Location = new System.Drawing.Point(523, 19);
            this.cboSort.Name = "cboSort";
            this.cboSort.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSort.Properties.Appearance.Options.UseFont = true;
            this.cboSort.Properties.AutoHeight = false;
            this.cboSort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cboSort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSort.Properties.NullText = "---Select Role---";
            this.cboSort.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboSort.Size = new System.Drawing.Size(218, 40);
            this.cboSort.TabIndex = 1;
            // 
            // AreaID
            // 
            this.AreaID.Caption = "AreaID";
            this.AreaID.FieldName = "AreaID";
            this.AreaID.Name = "AreaID";
            // 
            // gvAmenities
            // 
            this.gvAmenities.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(224)))));
            this.gvAmenities.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAmenities.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(94)))), ((int)(((byte)(83)))));
            this.gvAmenities.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvAmenities.Appearance.FooterPanel.Options.UseFont = true;
            this.gvAmenities.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvAmenities.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(224)))));
            this.gvAmenities.Appearance.HeaderPanel.Font = new System.Drawing.Font("Open Sans SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAmenities.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(94)))), ((int)(((byte)(83)))));
            this.gvAmenities.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvAmenities.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAmenities.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvAmenities.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(242)))), ((int)(((byte)(235)))));
            this.gvAmenities.Appearance.OddRow.Options.UseBackColor = true;
            this.gvAmenities.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gvAmenities.Appearance.Row.BorderColor = System.Drawing.Color.Transparent;
            this.gvAmenities.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAmenities.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(27)))), ((int)(((byte)(23)))));
            this.gvAmenities.Appearance.Row.Options.UseBackColor = true;
            this.gvAmenities.Appearance.Row.Options.UseBorderColor = true;
            this.gvAmenities.Appearance.Row.Options.UseFont = true;
            this.gvAmenities.Appearance.Row.Options.UseForeColor = true;
            this.gvAmenities.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvAmenities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AreaID,
            this.AreaName,
            this.StayCount,
            this.Actions});
            this.gvAmenities.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvAmenities.GridControl = this.gcAmenities;
            this.gvAmenities.Name = "gvAmenities";
            this.gvAmenities.OptionsPrint.EnableAppearanceOddRow = true;
            this.gvAmenities.OptionsView.EnableAppearanceOddRow = true;
            this.gvAmenities.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gvAmenities.OptionsView.ShowFooter = true;
            this.gvAmenities.OptionsView.ShowGroupPanel = false;
            this.gvAmenities.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvAmenities.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvAmenities.RowHeight = 64;
            // 
            // Actions
            // 
            this.Actions.Caption = "Actions";
            this.Actions.ColumnEdit = this.repoBtnActions;
            this.Actions.FieldName = "Actions";
            this.Actions.Name = "Actions";
            this.Actions.Visible = true;
            this.Actions.VisibleIndex = 2;
            // 
            // gcAmenities
            // 
            this.gcAmenities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAmenities.Location = new System.Drawing.Point(0, 200);
            this.gcAmenities.MainView = this.gvAmenities;
            this.gcAmenities.Name = "gcAmenities";
            this.gcAmenities.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repoBtnActions});
            this.gcAmenities.Size = new System.Drawing.Size(1289, 432);
            this.gcAmenities.TabIndex = 7;
            this.gcAmenities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAmenities});
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(23, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.AutoHeight = false;
            this.txtSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSearch.Properties.ContextImageOptions.Image = global::DangNhap_Form.Properties.Resources.search;
            this.txtSearch.Properties.NullText = "Search by name, email or role...";
            this.txtSearch.Properties.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.txtSearch.Size = new System.Drawing.Size(453, 40);
            this.txtSearch.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(242)))), ((int)(((byte)(235)))));
            this.pnlFilter.Appearance.Options.UseBackColor = true;
            this.pnlFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlFilter.Controls.Add(this.btnReset);
            this.pnlFilter.Controls.Add(this.cboSort);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 120);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1289, 80);
            this.pnlFilter.TabIndex = 5;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(94)))), ((int)(((byte)(83)))));
            this.lblSubtitle.Appearance.Options.UseFont = true;
            this.lblSubtitle.Appearance.Options.UseForeColor = true;
            this.lblSubtitle.Location = new System.Drawing.Point(47, 69);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(750, 28);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Create, edit, and organize the residential districts of Seoul for stay listings.";
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(84)))), ((int)(((byte)(85)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(47, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(512, 68);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Area Management";
            // 
            // btnInvite
            // 
            this.btnInvite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvite.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.btnInvite.Appearance.Font = new System.Drawing.Font("Open Sans SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvite.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnInvite.Appearance.Options.UseBackColor = true;
            this.btnInvite.Appearance.Options.UseFont = true;
            this.btnInvite.Appearance.Options.UseForeColor = true;
            this.btnInvite.ImageOptions.Image = global::DangNhap_Form.Properties.Resources._267_plus;
            this.btnInvite.Location = new System.Drawing.Point(908, 39);
            this.btnInvite.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(179, 33);
            this.btnInvite.TabIndex = 1;
            this.btnInvite.Text = "Add New Area";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(236)))), ((int)(((byte)(218)))));
            this.btnExport.Appearance.Font = new System.Drawing.Font("Open Sans SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(108)))), ((int)(((byte)(94)))));
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.ImageOptions.Image = global::DangNhap_Form.Properties.Resources.downloads;
            this.btnExport.Location = new System.Drawing.Point(744, 39);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(144, 33);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export CSV";
            // 
            // pnlCardStats
            // 
            this.pnlCardStats.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCardStats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCardStats.Location = new System.Drawing.Point(0, 632);
            this.pnlCardStats.Name = "pnlCardStats";
            this.pnlCardStats.Size = new System.Drawing.Size(1289, 111);
            this.pnlCardStats.TabIndex = 6;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnInvite);
            this.pnlHeader.Controls.Add(this.btnExport);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(24);
            this.pnlHeader.Size = new System.Drawing.Size(1289, 120);
            this.pnlHeader.TabIndex = 4;
            // 
            // UC_AreaManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcAmenities);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlCardStats);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UC_AreaManagement";
            this.Size = new System.Drawing.Size(1289, 743);
            this.Load += new System.EventHandler(this.UC_AreaManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAmenities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAmenities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCardStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnActions;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn StayCount;
        private DevExpress.XtraGrid.Columns.GridColumn AreaName;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.ComboBoxEdit cboSort;
        private DevExpress.XtraGrid.Columns.GridColumn AreaID;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAmenities;
        private DevExpress.XtraGrid.Columns.GridColumn Actions;
        private DevExpress.XtraGrid.GridControl gcAmenities;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraEditors.PanelControl pnlFilter;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnInvite;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.PanelControl pnlCardStats;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
    }
}
