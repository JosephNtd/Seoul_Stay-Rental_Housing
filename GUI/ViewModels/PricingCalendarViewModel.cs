using BUS;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DangNhap_Form.ViewModels
{
    public class PricingCalendarViewModel
    {
        private readonly BUS_ItemPrices _busPrices = new BUS_ItemPrices();
        private readonly BUS_CancellationPolicy _busPolicy = new BUS_CancellationPolicy();
        public long ItemId { get; }
        public DateTime CurrentMonth { get; set; }

        public List<ET_ItemPrices> MonthPrices { get; private set; }
        public List<ET_CancellationPolicies> Policies { get; private set; }
        public HashSet<DateTime> BlockedDates { get; private set; }  // availability = false
        public HashSet<DateTime> BookedDates { get; private set; }   // ngày có booking không hủy

        public HashSet<DateTime> SelectedDates { get; } = new HashSet<DateTime>();

        public event Action DataChanged;  // báo UI rebuild lịch

        public PricingCalendarViewModel(long itemId)
        {
            ItemId = itemId;
            CurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        }

        public void LoadData()
        {
            var start = CurrentMonth;
            var end = CurrentMonth.AddMonths(1).AddDays(-1);

            MonthPrices = _busPrices.GetPrices(ItemId)
                                    .Where(p => p.Date >= start && p.Date <= end)
                                    .ToList();
            Policies = _busPolicy.GetAll();

            BlockedDates = new HashSet<DateTime>(_busPrices.GetUnavailableDates(ItemId, start, end));
            BookedDates = new HashSet<DateTime>(_busPrices.GetBookedDates(ItemId, start, end));

            SelectedDates.Clear();
            DataChanged?.Invoke();
        }
        public void SetAvailabilityForSelected(bool isAvailable)
        {
            foreach (var date in SelectedDates)
                _busPrices.SetAvailability(ItemId, date, isAvailable);
            // Sau khi thay đổi availability, reload lại dữ liệu để cập nhật blocked dates
            LoadData();
        }
        public void UpdateSelectedDates(decimal price, long policyId)
        {
            foreach (var date in SelectedDates)
                _busPrices.SetPrice(ItemId, date, price, policyId);

            LoadData();  // refresh sau lưu
        }

        public void ChangeMonth(int delta)
        {
            CurrentMonth = CurrentMonth.AddMonths(delta);
            LoadData();
        }
        public bool UpdateSelectedDates(decimal? price, long policyId, out string errorMsg, out int updatedCount)
        {
            errorMsg = null;
            updatedCount = 0;
            var dates = SelectedDates.ToList();

            // Validate
            if (!_busPrices.ValidatePriceUpdate(ItemId, dates, price, policyId, out errorMsg))
                return false;

            foreach (var date in dates)
            {
                if (price.HasValue)
                {
                    // Có giá mới → ghi cả giá và policy
                    _busPrices.SetPrice(ItemId, date, price.Value, policyId);
                    updatedCount++;
                }
                else
                {
                    // Chỉ đổi policy: tìm giá hiện có trong tháng
                    var existing = MonthPrices.FirstOrDefault(p => p.Date == date);
                    if (existing != null)
                    {
                        _busPrices.SetPrice(ItemId, date, existing.Price, policyId);
                        updatedCount++;
                    }
                    // Nếu ngày đó chưa có giá thì bỏ qua (không thể gán policy mà không có giá)
                }
            }

            if (updatedCount == 0)
            {
                errorMsg = "None of the selected dates have an existing price to update policy.";
                return false;
            }

            LoadData(); // reload lại dữ liệu trong tháng, cập nhật MonthPrices
            return true;
        }
    }
}