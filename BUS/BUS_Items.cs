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
        private readonly DAL_Items _dal_items = new DAL_Items();
        private readonly DAL_ItemType _dal_item_type = new DAL_ItemType();

        public string LastError => _dal_items.LastError;

        public List<ET_ItemTypes> GetItemTypes()
        {
            return _dal_item_type.GetData();
        }
        public List<DTO_ItemsView> GetData(long? userId = null)
        {
            return _dal_items.GetItems(userId);
        }
        public List<DTO_ItemCard> GetItemCards(long? hostUserId = null)
        {
            return _dal_items.GetItemCards(hostUserId);
        }
        public bool Add(ET_Items i)
        {
            var item = new Item()
            {
                HostUserID = i.HostUserID,
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
                MaximumNights = i.MaximumNights,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            return _dal_items.Add(item);
        }

        public bool Add(ET_Items item, IEnumerable<long> amenityIds, IEnumerable<DTO_Attraction_Distance> attractions)
        {
            return _dal_items.Add(item, amenityIds, attractions);
        }

        public bool Update(ET_Items item, IEnumerable<long> amenityIds, IEnumerable<DTO_Attraction_Distance> attractions)
        {
            return _dal_items.Update(item, amenityIds, attractions);
        }

        public ET_Items GetEditItems(long id)
        {
            return _dal_items.GetEditItem(id);
        }

        public long GetAreaIdByApproximateAddress(string approximateAddress)
        {
            return _dal_items.GetAreaIdByApproximateAddress(approximateAddress);
        }
        public bool Delete(long id)
        {
            return _dal_items.Delete(id);
        }
    }
}
