using DAL;
using DTO;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Items
    {
        private readonly DAL_Items _dal = new DAL_Items();
        public List<DTO_ItemsView> GetData()
        {
            return _dal.GetItems();
        }
        public bool Add(ET_Items i)
        {
            var item = new Item()
            {
                ItemTypeID = i.ItemTypeID,
                AreaID = i.AreaID,
                Title = i.Title,
                Capacity = i.Capacity,
                NumberOfBeds = i.NumberOfBeds,
                NumberOfBedrooms = i.NumberOfBedrooms,
                NumberOfBathrooms = i.NumberOfBathrooms,
                ExactAddress = i.ExactAddress,
                ApproximateAddress = i.ApproximateAddress,
                Description = i.Description,
                HostRules = i.HostRules,
                MinimumNights = i.MinimumNights,
                MaximumNights = i.MaximumNights
            };
            return _dal.Add(item);
        }
    }
}
