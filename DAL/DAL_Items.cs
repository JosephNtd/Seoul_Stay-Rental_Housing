using DTO;
using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL
{
    public class DAL_Items
    {
        Seoul_StayDataContext db = new Seoul_StayDataContext();

        public string LastError { get; private set; }

        public List<DTO_ItemsView> GetItems(long? userId = null)
        {
            using (var context = new Seoul_StayDataContext())
            {
                var query = from i in context.Items
                            join a in context.Areas on i.AreaID equals a.ID
                            join t in context.ItemTypes on i.ItemTypeID equals t.ID
                            where i.IsActive
                            select new { Item = i, Area = a, Type = t };

                if (userId.HasValue)
                {
                    query = query.Where(x => x.Item.HostUserID == userId.Value);
                }

                return query
                    .Select(x => new DTO_ItemsView
                    {
                        ID = x.Item.ID,
                        Title = x.Item.Title,
                        Capacity = x.Item.Capacity,
                        Area = x.Area.Name,
                        Type = x.Type.Name
                    })
                    .ToList();
            }
        }

        public bool Add(Item i)
        {
            try
            {
                if (i.GUID == Guid.Empty)
                {
                    i.GUID = Guid.NewGuid();
                }

                if (i.CreatedDate == DateTime.MinValue)
                {
                    i.CreatedDate = DateTime.Now;
                }

                i.IsActive = true;
                db.Items.InsertOnSubmit(i);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return false;
            }
        }

        public bool Add(ET_Items item, IEnumerable<long> amenityIds, IEnumerable<DTO_Attraction_Distance> attractions)
        {
            LastError = null;

            try
            {
                using (var context = new Seoul_StayDataContext())
                {
                    OpenConnection(context);

                    using (var transaction = context.Connection.BeginTransaction())
                    {
                        context.Transaction = transaction;

                        var newItem = CreateItemEntity(context, item);
                        context.Items.InsertOnSubmit(newItem);
                        context.SubmitChanges();

                        ReplaceItemAmenities(context, newItem.ID, amenityIds);
                        ReplaceItemAttractions(context, newItem.ID, attractions);
                        context.SubmitChanges();

                        transaction.Commit();
                        item.ID = newItem.ID;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return false;
            }
        }

        public bool Update(ET_Items item, IEnumerable<long> amenityIds, IEnumerable<DTO_Attraction_Distance> attractions)
        {
            LastError = null;

            try
            {
                using (var context = new Seoul_StayDataContext())
                {
                    OpenConnection(context);

                    using (var transaction = context.Connection.BeginTransaction())
                    {
                        context.Transaction = transaction;

                        var current = context.Items.FirstOrDefault(x => x.ID == item.ID);
                        if (current == null)
                        {
                            LastError = "Item not found.";
                            return false;
                        }

                        // 1. Update main info
                        UpdateItemEntity(context, current, item);

                        // 2. Update amenities
                        ReplaceItemAmenities(context, current.ID, amenityIds);

                        // 3. Update attractions
                        ReplaceItemAttractions(context, current.ID, attractions);

                        context.SubmitChanges();

                        transaction.Commit();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return false;
            }
        }

        public ET_Items GetEditItem(long id)
        {
            using (var context = new Seoul_StayDataContext())
            {
                var i = context.Items.FirstOrDefault(x => x.ID == id);
                if (i == null) return null;

                return new ET_Items
                {
                    ID = i.ID,
                    GUID = i.GUID,
                    UserID = i.HostUserID,
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
                    MaximumNights = i.MaximumNights
                };
            }
        }

        public long GetAreaIdByApproximateAddress(string approximateAddress)
        {
            using (var context = new Seoul_StayDataContext())
            {
                return ResolveAreaId(context, approximateAddress, 0);
            }
        }

        public List<ET_Amenities> GetEditItemAmenities(long id)
        {
            using (var context = new Seoul_StayDataContext())
            {
                var data = from ia in context.ItemAmenities
                           join a in context.Amenities on ia.AmenityID equals a.ID
                           where ia.ItemID == id
                           select new ET_Amenities
                           {
                               ID = a.ID,
                               Name = a.Name
                           };
                return data.ToList();
            }
        }

        private static void OpenConnection(Seoul_StayDataContext context)
        {
            if (context.Connection.State != ConnectionState.Open)
            {
                context.Connection.Open();
            }
        }

        private static Item CreateItemEntity(Seoul_StayDataContext context, ET_Items source)
        {
            var item = new Item();
            UpdateItemEntity(context, item, source);
            item.GUID = Guid.NewGuid();
            item.HostUserID = source.HostUserID > 0 ? source.HostUserID : source.UserID;
            item.CreatedDate = DateTime.Now;
            item.IsActive = true;
            return item;
        }

        private static void UpdateItemEntity(Seoul_StayDataContext context, Item target, ET_Items source)
        {
            var areaId = ResolveAreaId(context, source.ApproximateAddress, source.AreaID);
            if (areaId <= 0)
            {
                throw new InvalidOperationException("Approximate Address must match an existing area.");
            }

            target.ItemTypeID = source.ItemTypeID;
            target.AreaID = areaId;
            target.Title = source.Title;
            target.Capacity = source.Capacity;
            target.NumberOfBeds = source.NumberOfBeds;
            target.NumberOfBedrooms = source.NumberOfBedrooms;
            target.NumberOfBathrooms = source.NumberOfBathrooms;
            target.ExactAddress = source.ExactAddress;
            target.ApproximateAddress = source.ApproximateAddress;
            target.Description = source.Description;
            target.HostRules = source.HostRules;
            target.MinimumNights = source.MinimumNights;
            target.MaximumNights = source.MaximumNights;
        }

        private static long ResolveAreaId(Seoul_StayDataContext context, string approximateAddress, long fallbackAreaId)
        {
            var value = (approximateAddress ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(value))
            {
                return fallbackAreaId;
            }

            var areas = context.Areas.ToList();
            var exact = areas.FirstOrDefault(a =>
                string.Equals(a.Name, value, StringComparison.OrdinalIgnoreCase));

            if (exact != null)
            {
                return exact.ID;
            }

            var contains = areas.FirstOrDefault(a =>
                value.IndexOf(a.Name, StringComparison.OrdinalIgnoreCase) >= 0 ||
                a.Name.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0);

            return contains != null ? contains.ID : fallbackAreaId;
        }

        private static void ReplaceItemAmenities(Seoul_StayDataContext context, long itemId, IEnumerable<long> amenityIds)
        {
            var newIds = (amenityIds ?? Enumerable.Empty<long>()).Distinct().ToList();

            var current = context.ItemAmenities
                                 .Where(x => x.ItemID == itemId)
                                 .ToList();

            var currentIds = current.Select(x => x.AmenityID).ToList();

            // Xóa những cái không còn
            var toRemove = current.Where(x => !newIds.Contains(x.AmenityID));
            context.ItemAmenities.DeleteAllOnSubmit(toRemove);

            // Thêm cái mới
            var toAdd = newIds.Where(id => !currentIds.Contains(id));
            foreach (var id in toAdd)
            {
                context.ItemAmenities.InsertOnSubmit(new ItemAmenity
                {
                    GUID = Guid.NewGuid(),
                    ItemID = itemId,
                    AmenityID = id
                });
            }
        }

        private static void ReplaceItemAttractions(Seoul_StayDataContext context, long itemId, IEnumerable<DTO_Attraction_Distance> attractions)
        {
            var newList = (attractions ?? Enumerable.Empty<DTO_Attraction_Distance>())
        .Where(x => x.AttractionID > 0 && x.Distance.HasValue)
        .GroupBy(x => x.AttractionID)
        .Select(g => g.First())
        .ToList();

            var current = context.ItemAttractions
                                 .Where(x => x.ItemID == itemId)
                                 .ToList();

            var currentIds = current.Select(x => x.AttractionID).ToList();
            var newIds = newList.Select(x => x.AttractionID).ToList();

            // Xóa cái không còn
            var toRemove = current.Where(x => !newIds.Contains(x.AttractionID));
            context.ItemAttractions.DeleteAllOnSubmit(toRemove);

            // Update cái có sẵn
            foreach (var exist in current.Where(x => newIds.Contains(x.AttractionID)))
            {
                var newData = newList.First(x => x.AttractionID == exist.AttractionID);

                exist.Distance = newData.Distance;
                exist.DurationOnFoot = ToNullableInt(newData.OnFoot);
                exist.DurationByCar = ToNullableInt(newData.ByCar);
            }

            // Thêm cái mới
            var toAdd = newList.Where(x => !currentIds.Contains(x.AttractionID));
            foreach (var a in toAdd)
            {
                context.ItemAttractions.InsertOnSubmit(new ItemAttraction
                {
                    GUID = Guid.NewGuid(),
                    ItemID = itemId,
                    AttractionID = a.AttractionID,
                    Distance = a.Distance,
                    DurationOnFoot = ToNullableInt(a.OnFoot),
                    DurationByCar = ToNullableInt(a.ByCar)
                });
            }
        }

        private static int? ToNullableInt(long? value)
        {
            return value.HasValue ? (int?)Convert.ToInt32(value.Value) : null;
        }
    }
}
