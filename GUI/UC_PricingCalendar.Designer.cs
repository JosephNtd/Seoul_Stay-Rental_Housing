namespace DangNhap_Form
{
    partial class UC_PricingCalendar
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
            this.pnlMonthNav = new DevExpress.XtraEditors.PanelControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.lblMonthYear = new DevExpress.XtraEditors.LabelControl();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.pnlCalendar = new DevExpress.XtraEditors.PanelControl();
            this.pnlQuickEdit = new DevExpress.XtraEditors.PanelControl();
            this.btnAvailable = new DevExpress.XtraEditors.SimpleButton();
            this.btnBlock = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.cbCancellationPolicy = new DevExpress.XtraEditors.LookUpEdit();
            this.radioSeason = new DevExpress.XtraEditors.RadioGroup();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.lblPolicy = new DevExpress.XtraEditors.LabelControl();
            this.lblSeason = new DevExpress.XtraEditors.LabelControl();
            this.lblNightlyRate = new DevExpress.XtraEditors.LabelControl();
            this.lblSelectedRange = new DevExpress.XtraEditors.LabelControl();
            this.label = new DevExpress.XtraEditors.LabelControl();
            this.lblQuickEdit = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMonthNav)).BeginInit();
            this.pnlMonthNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQuickEdit)).BeginInit();
            this.pnlQuickEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCancellationPolicy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioSeason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMonthNav
            // 
            this.pnlMonthNav.Controls.Add(this.btnBack);
            this.pnlMonthNav.Controls.Add(this.lblMonthYear);
            this.pnlMonthNav.Controls.Add(this.btnNext);
            this.pnlMonthNav.Controls.Add(this.btnPrev);
            this.pnlMonthNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMonthNav.Location = new System.Drawing.Point(0, 0);
            this.pnlMonthNav.Name = "pnlMonthNav";
            this.pnlMonthNav.Size = new System.Drawing.Size(833, 165);
            this.pnlMonthNav.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(705, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(108, 32);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "← Back to Listings";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.Location = new System.Drawing.Point(108, 89);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(70, 13);
            this.lblMonthYear.TabIndex = 1;
            this.lblMonthYear.Text = "October 2024.";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(197, 84);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">";
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(27, 84);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<";
            // 
            // pnlCalendar
            // 
            this.pnlCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCalendar.Location = new System.Drawing.Point(0, 165);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Size = new System.Drawing.Size(581, 405);
            this.pnlCalendar.TabIndex = 1;
            // 
            // pnlQuickEdit
            // 
            this.pnlQuickEdit.Controls.Add(this.btnAvailable);
            this.pnlQuickEdit.Controls.Add(this.btnBlock);
            this.pnlQuickEdit.Controls.Add(this.btnUpdate);
            this.pnlQuickEdit.Controls.Add(this.cbCancellationPolicy);
            this.pnlQuickEdit.Controls.Add(this.radioSeason);
            this.pnlQuickEdit.Controls.Add(this.txtPrice);
            this.pnlQuickEdit.Controls.Add(this.lblPolicy);
            this.pnlQuickEdit.Controls.Add(this.lblSeason);
            this.pnlQuickEdit.Controls.Add(this.lblNightlyRate);
            this.pnlQuickEdit.Controls.Add(this.lblSelectedRange);
            this.pnlQuickEdit.Controls.Add(this.label);
            this.pnlQuickEdit.Controls.Add(this.lblQuickEdit);
            this.pnlQuickEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlQuickEdit.Location = new System.Drawing.Point(581, 165);
            this.pnlQuickEdit.Name = "pnlQuickEdit";
            this.pnlQuickEdit.Size = new System.Drawing.Size(252, 405);
            this.pnlQuickEdit.TabIndex = 2;
            // 
            // btnAvailable
            // 
            this.btnAvailable.Location = new System.Drawing.Point(135, 371);
            this.btnAvailable.Name = "btnAvailable";
            this.btnAvailable.Size = new System.Drawing.Size(97, 31);
            this.btnAvailable.TabIndex = 5;
            this.btnAvailable.Text = "Available";
            // 
            // btnBlock
            // 
            this.btnBlock.Location = new System.Drawing.Point(6, 371);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(97, 31);
            this.btnBlock.TabIndex = 5;
            this.btnBlock.Text = "Block";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(83, 331);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(97, 31);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update Pricing";
            // 
            // cbCancellationPolicy
            // 
            this.cbCancellationPolicy.Location = new System.Drawing.Point(32, 296);
            this.cbCancellationPolicy.Name = "cbCancellationPolicy";
            this.cbCancellationPolicy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCancellationPolicy.Size = new System.Drawing.Size(200, 20);
            this.cbCancellationPolicy.TabIndex = 4;
            // 
            // radioSeason
            // 
            this.radioSeason.EditValue = true;
            this.radioSeason.Location = new System.Drawing.Point(32, 206);
            this.radioSeason.Name = "radioSeason";
            this.radioSeason.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.radioSeason.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Peak"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Off-Peak")});
            this.radioSeason.Size = new System.Drawing.Size(200, 34);
            this.radioSeason.TabIndex = 3;
            // 
            // txtPrice
            // 
            this.txtPrice.EditValue = "";
            this.txtPrice.Location = new System.Drawing.Point(32, 161);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtPrice.Properties.MaxLength = 12;
            this.txtPrice.Size = new System.Drawing.Size(200, 20);
            this.txtPrice.TabIndex = 2;
            // 
            // lblPolicy
            // 
            this.lblPolicy.Location = new System.Drawing.Point(32, 261);
            this.lblPolicy.Name = "lblPolicy";
            this.lblPolicy.Size = new System.Drawing.Size(88, 13);
            this.lblPolicy.TabIndex = 1;
            this.lblPolicy.Text = "Cancellation Policy";
            // 
            // lblSeason
            // 
            this.lblSeason.Location = new System.Drawing.Point(32, 187);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(77, 13);
            this.lblSeason.TabIndex = 1;
            this.lblSeason.Text = "Seasonal Pricing";
            // 
            // lblNightlyRate
            // 
            this.lblNightlyRate.Location = new System.Drawing.Point(32, 142);
            this.lblNightlyRate.Name = "lblNightlyRate";
            this.lblNightlyRate.Size = new System.Drawing.Size(59, 13);
            this.lblNightlyRate.TabIndex = 1;
            this.lblNightlyRate.Text = "Nightly Rate";
            // 
            // lblSelectedRange
            // 
            this.lblSelectedRange.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblSelectedRange.Location = new System.Drawing.Point(32, 107);
            this.lblSelectedRange.Name = "lblSelectedRange";
            this.lblSelectedRange.Size = new System.Drawing.Size(97, 15);
            this.lblSelectedRange.TabIndex = 1;
            this.lblSelectedRange.Text = "Oct 4 – Oct 6, 2024";
            // 
            // label
            // 
            this.label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.label.Location = new System.Drawing.Point(32, 75);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(77, 15);
            this.label.TabIndex = 1;
            this.label.Text = "Selected Range";
            // 
            // lblQuickEdit
            // 
            this.lblQuickEdit.Location = new System.Drawing.Point(32, 23);
            this.lblQuickEdit.Name = "lblQuickEdit";
            this.lblQuickEdit.Size = new System.Drawing.Size(47, 13);
            this.lblQuickEdit.TabIndex = 0;
            this.lblQuickEdit.Text = "Quick Edit";
            // 
            // UC_PricingCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCalendar);
            this.Controls.Add(this.pnlQuickEdit);
            this.Controls.Add(this.pnlMonthNav);
            this.Name = "UC_PricingCalendar";
            this.Size = new System.Drawing.Size(833, 570);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMonthNav)).EndInit();
            this.pnlMonthNav.ResumeLayout(false);
            this.pnlMonthNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQuickEdit)).EndInit();
            this.pnlQuickEdit.ResumeLayout(false);
            this.pnlQuickEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCancellationPolicy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioSeason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMonthNav;
        private DevExpress.XtraEditors.LabelControl lblMonthYear;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.PanelControl pnlCalendar;
        private DevExpress.XtraEditors.PanelControl pnlQuickEdit;
        private DevExpress.XtraEditors.LabelControl lblNightlyRate;
        private DevExpress.XtraEditors.LabelControl label;
        private DevExpress.XtraEditors.LabelControl lblQuickEdit;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.RadioGroup radioSeason;
        private DevExpress.XtraEditors.LabelControl lblSeason;
        private DevExpress.XtraEditors.LabelControl lblSelectedRange;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.LookUpEdit cbCancellationPolicy;
        private DevExpress.XtraEditors.LabelControl lblPolicy;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.SimpleButton btnAvailable;
        private DevExpress.XtraEditors.SimpleButton btnBlock;
    }
}
