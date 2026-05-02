namespace DangNhap_Form
{
    partial class UC_Management
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView2 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            this.areasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seoul_StayDataSet = new DangNhap_Form.Seoul_StayDataSet();
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
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.areasTableAdapter = new DangNhap_Form.Seoul_StayDataSetTableAdapters.AreasTableAdapter();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.edit = new System.Windows.Forms.ToolStripMenuItem();
            this.edit_price = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.areasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoul_StayDataSet)).BeginInit();
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
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // areasBindingSource
            // 
            this.areasBindingSource.DataMember = "Areas";
            this.areasBindingSource.DataSource = this.seoul_StayDataSet;
            // 
            // seoul_StayDataSet
            // 
            this.seoul_StayDataSet.DataSetName = "Seoul_StayDataSet";
            this.seoul_StayDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureEdit1.EditValue = global::DangNhap_Form.Properties.Resources.WSC2022SE_TP09_Logo_actual_en;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(732, 115);
            this.pictureEdit1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLogout.Appearance.Font = new System.Drawing.Font("IcoMoon-Free", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Appearance.Options.UseFont = true;
            this.btnLogout.ImageOptions.Image = global::DangNhap_Form.Properties.Resources.images;
            this.btnLogout.Location = new System.Drawing.Point(443, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(116, 41);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Log out";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExit.Appearance.Font = new System.Drawing.Font("IcoMoon-Free", 11F, System.Drawing.FontStyle.Bold);
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Location = new System.Drawing.Point(576, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(116, 41);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Location = new System.Drawing.Point(18, 174);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpTraveler;
            this.tcMain.Size = new System.Drawing.Size(696, 274);
            this.tcMain.TabIndex = 4;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpTraveler,
            this.tbManager,
            this.xtraTabPage1});
            // 
            // tpTraveler
            // 
            this.tpTraveler.Controls.Add(this.panelControl2);
            this.tpTraveler.Controls.Add(this.gcTraveler);
            this.tpTraveler.Name = "tpTraveler";
            this.tpTraveler.Size = new System.Drawing.Size(694, 249);
            this.tpTraveler.Text = "I\'m Traveler";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.search);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(694, 58);
            this.panelControl2.TabIndex = 2;
            // 
            // search
            // 
            this.search.Client = this.gcTraveler;
            this.search.Location = new System.Drawing.Point(8, 22);
            this.search.Name = "search";
            this.search.Properties.Client = this.gcTraveler;
            this.search.Properties.NullValuePrompt = "Search destination or Listing Title or Attraction";
            this.search.Properties.ShowClearButton = false;
            this.search.Properties.ShowSearchButton = false;
            this.search.Size = new System.Drawing.Size(704, 20);
            this.search.TabIndex = 0;
            // 
            // gcTraveler
            // 
            this.gcTraveler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTraveler.Location = new System.Drawing.Point(0, 0);
            this.gcTraveler.MainView = this.gvTraveler;
            this.gcTraveler.Name = "gcTraveler";
            this.gcTraveler.Size = new System.Drawing.Size(694, 249);
            this.gcTraveler.TabIndex = 1;
            this.gcTraveler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTraveler});
            // 
            // gvTraveler
            // 
            this.gvTraveler.Appearance.HeaderPanel.Font = new System.Drawing.Font("IcoMoon-Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTraveler.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvTraveler.Appearance.Row.Font = new System.Drawing.Font("IcoMoon-Free", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTraveler.Appearance.Row.Options.UseFont = true;
            this.gvTraveler.GridControl = this.gcTraveler;
            this.gvTraveler.Name = "gvTraveler";
            this.gvTraveler.OptionsBehavior.Editable = false;
            this.gvTraveler.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTraveler.OptionsView.ShowAutoFilterRow = true;
            this.gvTraveler.OptionsView.ShowFooter = true;
            this.gvTraveler.RowHeight = 30;
            // 
            // tbManager
            // 
            this.tbManager.Controls.Add(this.gcManager);
            this.tbManager.Controls.Add(this.panelControl3);
            this.tbManager.Name = "tbManager";
            this.tbManager.Size = new System.Drawing.Size(694, 249);
            this.tbManager.Text = "I\'m Owner/ Manager";
            // 
            // gcManager
            // 
            this.gcManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcManager.Font = new System.Drawing.Font("IcoMoon-Free", 12F);
            this.gcManager.Location = new System.Drawing.Point(0, 85);
            this.gcManager.MainView = this.gvManager;
            this.gcManager.Name = "gcManager";
            this.gcManager.Size = new System.Drawing.Size(694, 164);
            this.gcManager.TabIndex = 2;
            this.gcManager.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvManager});
            // 
            // gvManager
            // 
            this.gvManager.Appearance.Row.Font = new System.Drawing.Font("IcoMoon-Free", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvManager.Appearance.Row.Options.UseFont = true;
            this.gvManager.GridControl = this.gcManager;
            this.gvManager.Name = "gvManager";
            this.gvManager.OptionsBehavior.Editable = false;
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
            this.panelControl3.Size = new System.Drawing.Size(694, 85);
            this.panelControl3.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("IcoMoon-Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = global::DangNhap_Form.Properties.Resources._267_plus;
            this.btnAdd.Location = new System.Drawing.Point(33, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(137, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Listing";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.chartControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(694, 249);
            this.xtraTabPage1.Text = "Report";
            // 
            // chartControl1
            // 
            this.chartControl1.DataSource = this.seoul_StayDataSet.Areas;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram2;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            series2.DataSource = this.areasBindingSource;
            series2.Name = "Series 1";
            series2.SeriesID = 0;
            sideBySideBarSeriesView2.ColorEach = true;
            series2.View = sideBySideBarSeriesView2;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControl1.Size = new System.Drawing.Size(694, 249);
            this.chartControl1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnLogout);
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 115);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(732, 60);
            this.panelControl1.TabIndex = 3;
            // 
            // areasTableAdapter
            // 
            this.areasTableAdapter.ClearBeforeFill = true;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edit,
            this.edit_price,
            this.delete});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(135, 70);
            // 
            // edit
            // 
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(180, 22);
            this.edit.Text = "Edit Listing";
            // 
            // edit_price
            // 
            this.edit_price.Name = "edit_price";
            this.edit_price.Size = new System.Drawing.Size(180, 22);
            this.edit_price.Text = "Edit Price";
            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(180, 22);
            this.delete.Text = "Delete Item";
            // 
            // UC_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.Name = "UC_Management";
            this.Size = new System.Drawing.Size(732, 458);
            this.Load += new System.EventHandler(this.UC_Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.areasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seoul_StayDataSet)).EndInit();
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
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        // Khai báo biến (các control)
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
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private Seoul_StayDataSet seoul_StayDataSet;
        private System.Windows.Forms.BindingSource areasBindingSource;
        private Seoul_StayDataSetTableAdapters.AreasTableAdapter areasTableAdapter;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem edit;
        private System.Windows.Forms.ToolStripMenuItem edit_price;
        private System.Windows.Forms.ToolStripMenuItem delete;
    }
}