namespace DangNhap_Form
{
    partial class Form_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Management));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnLogout = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpTraveler = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.search = new DevExpress.XtraEditors.SearchControl();
            this.gcTraveler = new DevExpress.XtraGrid.GridControl();
            this.gvTraveler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tbManager = new DevExpress.XtraTab.XtraTabPage();
            this.gcManager = new DevExpress.XtraGrid.GridControl();
            this.gvManager = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpTraveler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.search.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTraveler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTraveler)).BeginInit();
            this.tbManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureEdit1.EditValue = global::DangNhap_Form.Properties.Resources.WSC2022SE_TP09_Logo_actual_en;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(800, 79);
            this.pictureEdit1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLogout.Appearance.Font = new System.Drawing.Font("IcoMoon-Free", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Appearance.Options.UseFont = true;
            this.btnLogout.Location = new System.Drawing.Point(600, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(85, 28);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Log out";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExit.Appearance.Font = new System.Drawing.Font("IcoMoon-Free", 11F, System.Drawing.FontStyle.Bold);
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Location = new System.Drawing.Point(703, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 28);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tcMain.Appearance.Options.UseBackColor = true;
            this.tcMain.AppearancePage.Header.Font = new System.Drawing.Font("IcoMoon-Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.AppearancePage.Header.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.tcMain.AppearancePage.Header.Options.UseFont = true;
            this.tcMain.Location = new System.Drawing.Point(12, 119);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpTraveler;
            this.tcMain.Size = new System.Drawing.Size(776, 319);
            this.tcMain.TabIndex = 2;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpTraveler,
            this.tbManager});
            // 
            // tpTraveler
            // 
            this.tpTraveler.Appearance.PageClient.BackColor = System.Drawing.Color.Silver;
            this.tpTraveler.Appearance.PageClient.Options.UseBackColor = true;
            this.tpTraveler.Controls.Add(this.panelControl2);
            this.tpTraveler.Controls.Add(this.gcTraveler);
            this.tpTraveler.Name = "tpTraveler";
            this.tpTraveler.Size = new System.Drawing.Size(774, 291);
            this.tpTraveler.Text = "I\'m Traveler";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.search);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(774, 40);
            this.panelControl2.TabIndex = 2;
            // 
            // search
            // 
            this.search.AllowDrop = true;
            this.search.Client = this.gcTraveler;
            this.search.Location = new System.Drawing.Point(5, 15);
            this.search.Name = "search";
            this.search.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.search.Properties.Client = this.gcTraveler;
            this.search.Properties.FindDelay = 200;
            this.search.Properties.NullValuePrompt = "Search destination or Listing Title or Attraction";
            this.search.Size = new System.Drawing.Size(469, 20);
            this.search.TabIndex = 0;
            // 
            // gcTraveler
            // 
            this.gcTraveler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTraveler.Location = new System.Drawing.Point(0, 0);
            this.gcTraveler.MainView = this.gvTraveler;
            this.gcTraveler.Name = "gcTraveler";
            this.gcTraveler.Size = new System.Drawing.Size(774, 291);
            this.gcTraveler.TabIndex = 1;
            this.gcTraveler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTraveler});
            this.gcTraveler.Load += new System.EventHandler(this.gcTraveler_Load);
            // 
            // gvTraveler
            // 
            this.gvTraveler.Appearance.Empty.Options.UseFont = true;
            this.gvTraveler.Appearance.EvenRow.BackColor = System.Drawing.Color.Transparent;
            this.gvTraveler.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTraveler.Appearance.FooterPanel.Font = new System.Drawing.Font("IcoMoon-Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTraveler.Appearance.FooterPanel.Options.UseFont = true;
            this.gvTraveler.Appearance.GroupPanel.Font = new System.Drawing.Font("IcoMoon-Free", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTraveler.Appearance.GroupPanel.Options.UseFont = true;
            this.gvTraveler.Appearance.HeaderPanel.Font = new System.Drawing.Font("IcoMoon-Free", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTraveler.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvTraveler.Appearance.Row.Font = new System.Drawing.Font("IcoMoon-Free", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTraveler.Appearance.Row.Options.UseFont = true;
            this.gvTraveler.GridControl = this.gcTraveler;
            this.gvTraveler.Name = "gvTraveler";
            this.gvTraveler.OptionsBehavior.Editable = false;
            this.gvTraveler.OptionsFind.AlwaysVisible = true;
            this.gvTraveler.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gvTraveler.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTraveler.OptionsView.EnableAppearanceOddRow = true;
            this.gvTraveler.OptionsView.ShowAutoFilterRow = true;
            this.gvTraveler.OptionsView.ShowFooter = true;
            this.gvTraveler.RowHeight = 30;
            // 
            // tbManager
            // 
            this.tbManager.Appearance.PageClient.BackColor = System.Drawing.Color.DimGray;
            this.tbManager.Appearance.PageClient.Options.UseBackColor = true;
            this.tbManager.Controls.Add(this.gcManager);
            this.tbManager.Controls.Add(this.panelControl3);
            this.tbManager.Name = "tbManager";
            this.tbManager.Size = new System.Drawing.Size(774, 291);
            this.tbManager.Text = "I\'m Owner/ Manager";
            // 
            // gcManager
            // 
            this.gcManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcManager.Location = new System.Drawing.Point(0, 58);
            this.gcManager.MainView = this.gvManager;
            this.gcManager.Name = "gcManager";
            this.gcManager.Size = new System.Drawing.Size(774, 233);
            this.gcManager.TabIndex = 2;
            this.gcManager.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvManager});
            this.gcManager.Load += new System.EventHandler(this.gcManager_Load);
            // 
            // gvManager
            // 
            this.gvManager.Appearance.Empty.Font = new System.Drawing.Font("IcoMoon-Free", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvManager.Appearance.Empty.Options.UseFont = true;
            this.gvManager.Appearance.Empty.Options.UseTextOptions = true;
            this.gvManager.Appearance.FooterPanel.Font = new System.Drawing.Font("IcoMoon-Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvManager.Appearance.FooterPanel.Options.UseFont = true;
            this.gvManager.Appearance.HeaderPanel.Font = new System.Drawing.Font("IcoMoon-Free", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvManager.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvManager.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvManager.Appearance.Row.Font = new System.Drawing.Font("IcoMoon-Free", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvManager.Appearance.Row.Options.UseFont = true;
            this.gvManager.Appearance.Row.Options.UseTextOptions = true;
            this.gvManager.GridControl = this.gcManager;
            this.gvManager.Name = "gvManager";
            this.gvManager.OptionsBehavior.Editable = false;
            this.gvManager.OptionsFind.AlwaysVisible = true;
            this.gvManager.OptionsFind.FindDelay = 200;
            this.gvManager.OptionsView.EnableAppearanceEvenRow = true;
            this.gvManager.OptionsView.ShowAutoFilterRow = true;
            this.gvManager.OptionsView.ShowFooter = true;
            this.gvManager.RowHeight = 30;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(774, 58);
            this.panelControl3.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("IcoMoon-Free", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = global::DangNhap_Form.Properties.Resources._267_plus;
            this.btnAdd.Location = new System.Drawing.Point(22, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(128, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Listing";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnLogout);
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 79);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 41);
            this.panelControl1.TabIndex = 3;
            // 
            // Form_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.pictureEdit1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("Form_Management.IconOptions.Icon")));
            this.IconOptions.Image = global::DangNhap_Form.Properties.Resources.WSC2022SE_TP09_Logo_actual_en2;
            this.Name = "Form_Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seoul Stay_Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpTraveler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.search.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTraveler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTraveler)).EndInit();
            this.tbManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnLogout;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpTraveler;
        private DevExpress.XtraTab.XtraTabPage tbManager;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SearchControl search;
        private DevExpress.XtraGrid.GridControl gcTraveler;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTraveler;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl gcManager;
        private DevExpress.XtraGrid.Views.Grid.GridView gvManager;
        private DevExpress.XtraEditors.PanelControl panelControl3;
    }
}