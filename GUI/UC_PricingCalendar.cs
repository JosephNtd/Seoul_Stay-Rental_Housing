using BUS;
using DangNhap_Form.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DangNhap_Form
{
    public partial class UC_PricingCalendar : XtraUserControl
    {
        private readonly PricingCalendarViewModel _vm;
        private TableLayoutPanel _tblCalendar;

        private Dictionary<DateTime, LabelControl> _dayLabels = new Dictionary<DateTime, LabelControl>();
        private Dictionary<DateTime, ET_ItemPrices> _priceDict = new Dictionary<DateTime, ET_ItemPrices>();

        private bool _isDragging;
        private bool _selectMode;

        private ToolTip _toolTip = new ToolTip();

        public event EventHandler BackRequested;

        public UC_PricingCalendar(long itemId)
        {
            InitializeComponent();
            _vm = new PricingCalendarViewModel(itemId);

            btnPrev.Click += (s, e) => _vm.ChangeMonth(-1);
            btnNext.Click += (s, e) => _vm.ChangeMonth(1);
            btnUpdate.Click += BtnUpdate_Click;
            btnBlock.Click += BtnBlock_Click;
            btnAvailable.Click += BtnAvailable_Click;

            _vm.DataChanged += OnDataChanged;

            btnBack.Click += (s, e) => BackRequested?.Invoke(this, EventArgs.Empty);

            _tblCalendar = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };
            pnlCalendar.Controls.Add(_tblCalendar);

            _vm.LoadData();
        }

        private void OnDataChanged()
        {
            lblMonthYear.Text = _vm.CurrentMonth.ToString("MMMM yyyy");
            LoadPolicies();

            _priceDict = _vm.MonthPrices.ToDictionary(p => p.Date, p => p);

            BuildCalendar();
        }

        private void BuildCalendar()
        {
            _tblCalendar.Controls.Clear();
            _dayLabels.Clear();

            DateTime first = _vm.CurrentMonth;
            int days = DateTime.DaysInMonth(first.Year, first.Month);
            int startDow = (int)first.DayOfWeek;
            startDow = startDow == 0 ? 7 : startDow;          // Monday=1..Sunday=7

            int rowsNeeded = (int)Math.Ceiling((double)(startDow - 1 + days) / 7);

            _tblCalendar.ColumnCount = 7;
            _tblCalendar.RowCount = rowsNeeded + 1;           // +1 cho header

            // Xoá sạch và thêm lại RowStyles sau khi đã xác định RowCount
            _tblCalendar.RowStyles.Clear();
            for (int i = 0; i < _tblCalendar.RowCount; i++)
            {
                _tblCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / _tblCalendar.RowCount));
            }
            _tblCalendar.ColumnStyles.Clear();
            for (int i = 0; i < _tblCalendar.ColumnCount; i++)
            {
                _tblCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / _tblCalendar.ColumnCount));
            }

            // Header
            string[] dayNames = { "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN" };
            foreach (var dayName in dayNames)
            {
                _tblCalendar.Controls.Add(new LabelControl
                {
                    Text = dayName,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Appearance = { TextOptions = { HAlignment = DevExpress.Utils.HorzAlignment.Center } }
                });
            }

            int currentDay = 1;
            for (int r = 1; r <= rowsNeeded; r++)
            {
                for (int c = 0; c < 7; c++)
                {
                    int idx = (r - 1) * 7 + c;
                    if (idx >= startDow - 1 && currentDay <= days)
                    {
                        DateTime date = new DateTime(first.Year, first.Month, currentDay);
                        ET_ItemPrices price = null;
                        _priceDict.TryGetValue(date, out price);

                        string text = $"{currentDay}\n${price?.Price ?? 240}";

                        var lbl = new LabelControl
                        {
                            Text = text,
                            Tag = date,
                            Dock = DockStyle.Fill,
                            AutoSizeMode = LabelAutoSizeMode.None,
                            Appearance = { TextOptions = { HAlignment = DevExpress.Utils.HorzAlignment.Center } }
                        };

                        string status = _vm.BookedDates.Contains(date) ? "Booked"
                                      : _vm.BlockedDates.Contains(date) ? "Blocked"
                                      : "Available";
                        _toolTip.SetToolTip(lbl, $"Price: ${price?.Price ?? 240}\nStatus: {status}");

                        lbl.MouseDown += DayLabel_MouseDown;
                        lbl.MouseEnter += DayLabel_MouseEnter;
                        lbl.MouseUp += DayLabel_MouseUp;

                        ApplyColor(lbl, date, c >= 5);
                        _tblCalendar.Controls.Add(lbl, c, r);
                        _dayLabels[date] = lbl;
                        currentDay++;
                    }
                    else
                    {
                        _tblCalendar.Controls.Add(new LabelControl(), c, r);
                    }
                }
            }
        }

        private void ApplyColor(LabelControl lbl, DateTime date, bool isWeekend)
        {
            Color back = Color.Transparent;
            Color fore = Color.Black;

            if (_vm.SelectedDates.Contains(date))
            {
                back = Color.LightSkyBlue;
            }
            else if (_vm.BookedDates.Contains(date))
            {
                back = Color.Orange;
                fore = Color.White;
            }
            else if (_vm.BlockedDates.Contains(date))
            {
                back = Color.LightGray;
                fore = Color.DarkRed;
            }
            else if (isWeekend)
            {
                back = Color.FromArgb(255, 240, 240);
            }

            lbl.Appearance.BackColor = back;
            lbl.Appearance.ForeColor = fore;
        }

        // ================= DRAG =================
        private void DayLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var lbl = sender as LabelControl;
            if (lbl?.Tag is DateTime date)
            {
                if (_vm.BookedDates.Contains(date)) return;

                _isDragging = true;

                bool selected = _vm.SelectedDates.Contains(date);
                _selectMode = !selected;

                ToggleDate(date, _selectMode);
                UpdateQuickEdit();
            }
        }

        private void DayLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!_isDragging) return;

            var lbl = sender as LabelControl;
            if (lbl?.Tag is DateTime date)
            {
                if (_vm.BookedDates.Contains(date)) return;

                bool selected = _vm.SelectedDates.Contains(date);

                if (_selectMode && !selected) ToggleDate(date, true);
                else if (!_selectMode && selected) ToggleDate(date, false);
            }
        }

        private void DayLabel_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
            UpdateQuickEdit();
        }

        private void ToggleDate(DateTime date, bool add)
        {
            if (add) _vm.SelectedDates.Add(date);
            else _vm.SelectedDates.Remove(date);

            if (_dayLabels.TryGetValue(date, out var lbl))
            {
                ApplyColor(lbl, date, date.DayOfWeek >= DayOfWeek.Saturday);
            }
        }

        private void UpdateQuickEdit()
        {
            if (_vm.SelectedDates.Count == 0)
            {
                lblSelectedRange.Text = "None";
                txtPrice.Text = "";
                cbCancellationPolicy.EditValue = null;   // không có ngày chọn → để trống
                return;
            }

            var sorted = _vm.SelectedDates.OrderBy(d => d).ToList();
            lblSelectedRange.Text = $"{sorted.First():MMM dd} - {sorted.Last():MMM dd}";

            // ------------------ GIÁ ------------------
            decimal? firstPrice = null;
            bool samePrice = true;
            foreach (var date in sorted)
            {
                if (_priceDict.TryGetValue(date, out var p))
                {
                    if (firstPrice == null) firstPrice = p.Price;
                    else if (p.Price != firstPrice) { samePrice = false; break; }
                }
                else { samePrice = false; break; }
            }
            txtPrice.EditValue = (samePrice && firstPrice.HasValue) ? (object)firstPrice.Value : "";

            // ------------------ POLICY ------------------
            long? firstPolicyId = null;
            bool samePolicy = true;
            foreach (var date in sorted)
            {
                if (_priceDict.TryGetValue(date, out var p))
                {
                    if (firstPolicyId == null) firstPolicyId = p.CancellationPolicyID;
                    else if (p.CancellationPolicyID != firstPolicyId) { samePolicy = false; break; }
                }
                else { samePolicy = false; break; }
            }
            cbCancellationPolicy.EditValue = (samePolicy && firstPolicyId.HasValue) ? (object)firstPolicyId.Value : null;
        }

        // ================= ACTION =================

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_vm.SelectedDates.Count == 0) return;

            if (cbCancellationPolicy.EditValue == null)
            {
                XtraMessageBox.Show("Please select a cancellation policy.", "Validation");
                return;
            }

            long policyId = Convert.ToInt64(cbCancellationPolicy.EditValue);
            decimal? price = null;

            string priceText = txtPrice.Text.Trim();
            if (!string.IsNullOrEmpty(priceText))
            {
                if (!decimal.TryParse(priceText, out decimal parsedPrice))
                {
                    XtraMessageBox.Show("Please enter a valid numeric price.", "Validation");
                    return;
                }
                price = parsedPrice;
            }

            if (!_vm.UpdateSelectedDates(price, policyId, out string errorMsg, out int updatedCount))
            {
                XtraMessageBox.Show(errorMsg, "Business Rule Violation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = price.HasValue
                ? $"Prices and policy updated for {updatedCount} date(s)."
                : $"Policy updated for {updatedCount} date(s) (prices unchanged).";

            XtraMessageBox.Show(message, "Success");
        }

        private void BtnBlock_Click(object sender, EventArgs e)
        {
            _vm.SetAvailabilityForSelected(false);
        }

        private void BtnAvailable_Click(object sender, EventArgs e)
        {
            _vm.SetAvailabilityForSelected(true);
        }
        private void LoadPolicies()
        {
            cbCancellationPolicy.Properties.DataSource = _vm.Policies;
            cbCancellationPolicy.Properties.DisplayMember = "Name";
            cbCancellationPolicy.Properties.ValueMember = "ID";

            cbCancellationPolicy.Properties.Columns.Clear();
            cbCancellationPolicy.Properties.Columns.Add(
                new LookUpColumnInfo("Name", "Policy")
            );


            if (_vm.Policies.Any())
                cbCancellationPolicy.EditValue = _vm.Policies.First().ID;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}