using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ItemPrices
    {
        DAL_ItemPrices _dal = new DAL_ItemPrices();
        public List<ET_ItemPrices> GetPrices(long itemId) => _dal.GetPrices(itemId);
        public bool SetPrice(long itemId, DateTime date, decimal price, long policyId)
            => _dal.SetPrice(itemId, date, price, policyId);
        public bool DeletePrice(long itemId, DateTime date) => _dal.DeletePrice(itemId, date);
        public List<CancellationPolicy> GetPolicies() => _dal.GetPolicies();
        public bool ToggleAvailability(long itemId, DateTime date, bool isAvailable)
        {
            return _dal.ToggleAvailability(itemId, date, isAvailable);
        }
        public List<DateTime> GetUnavailableDates(long itemId, DateTime from, DateTime to)
            => _dal.GetUnavailableDates(itemId, from, to);
        public List<DateTime> GetBookedDates(long itemId, DateTime from, DateTime to)
            => _dal.GetBookedDates(itemId, from, to);
        public bool SetAvailability(long itemId, DateTime date, bool isAvailable)
            => _dal.SetAvailability(itemId, date, isAvailable);
    }
}
