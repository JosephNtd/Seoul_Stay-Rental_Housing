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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Management));
            this.areasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seoul_StayDataSet = new DangNhap_Form.Seoul_StayDataSet();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnLogout = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tbManager = new DevExpress.XtraTab.XtraTabPage();
            this.gcManager = new DevExpress.XtraGrid.GridControl();
            this.tvManager = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
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
            this.tbManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
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
            this.tcMain.SelectedTabPage = this.tbManager;
            this.tcMain.Size = new System.Drawing.Size(696, 274);
            this.tcMain.TabIndex = 4;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tbManager});
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
            this.gcManager.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcManager.Font = new System.Drawing.Font("IcoMoon-Free", 12F);
            this.gcManager.Location = new System.Drawing.Point(0, 62);
            this.gcManager.MainView = this.tvManager;
            this.gcManager.Name = "gcManager";
            this.gcManager.Size = new System.Drawing.Size(694, 187);
            this.gcManager.TabIndex = 2;
            this.gcManager.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tvManager});
            // 
            // tvManager
            // 
            this.tvManager.ActiveFilterEnabled = false;
            this.tvManager.Appearance.ItemHovered.BackColor = System.Drawing.Color.LightCoral;
            this.tvManager.Appearance.ItemHovered.Options.UseBackColor = true;
            this.tvManager.Appearance.ItemNormal.BackColor = System.Drawing.Color.White;
            this.tvManager.Appearance.ItemNormal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tvManager.Appearance.ItemNormal.Options.UseBackColor = true;
            this.tvManager.Appearance.ItemNormal.Options.UseBorderColor = true;
            this.tvManager.GridControl = this.gcManager;
            this.tvManager.Name = "tvManager";
            this.tvManager.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.tvManager.OptionsEditForm.PopupEditFormWidth = 1200;
            this.tvManager.OptionsTiles.AllowItemHover = true;
            this.tvManager.OptionsTiles.HighlightFocusedTileStyle = DevExpress.XtraGrid.Views.Tile.HighlightFocusedTileStyle.None;
            this.tvManager.OptionsTiles.IndentBetweenItems = 40;
            this.tvManager.OptionsTiles.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tvManager.TileHtmlTemplate.Styles = resources.GetString("tvManager.TileHtmlTemplate.Styles");
            this.tvManager.TileHtmlTemplate.Template = resources.GetString("tvManager.TileHtmlTemplate.Template");
            this.tvManager.HtmlElementMouseClick += new DevExpress.XtraGrid.Views.Tile.TileViewHtmlElementMouseEventHandler(this.tvManager_HtmlElementMouseClick);
            this.tvManager.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tvManager_MouseMove);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(694, 62);
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
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
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
            this.edit.Size = new System.Drawing.Size(134, 22);
            this.edit.Text = "Edit Listing";
            // 
            // edit_price
            // 
            this.edit_price.Name = "edit_price";
            this.edit_price.Size = new System.Drawing.Size(134, 22);
            this.edit_price.Text = "Edit Price";
            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(134, 22);
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
            this.tbManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
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
        private DevExpress.XtraTab.XtraTabPage tbManager;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl gcManager;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private Seoul_StayDataSet seoul_StayDataSet;
        private System.Windows.Forms.BindingSource areasBindingSource;
        private Seoul_StayDataSetTableAdapters.AreasTableAdapter areasTableAdapter;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem edit;
        private System.Windows.Forms.ToolStripMenuItem edit_price;
        private System.Windows.Forms.ToolStripMenuItem delete;
        private DevExpress.XtraGrid.Views.Tile.TileView tvManager;
    }
}