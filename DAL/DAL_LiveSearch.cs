using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_LiveSearch
    {
        Seoul_StayDataContext db =
            new Seoul_StayDataContext();

        public List<DTO_ItemCard> SearchItems(
            string keyword,
            decimal minPrice,
            decimal maxPrice,
            int guests,
            string sortBy)
        {
            keyword = keyword?.ToLower().Trim();

            var query =
                from i in db.Items

                join a in db.Areas
                on i.AreaID equals a.ID

                join t in db.ItemTypes
                on i.ItemTypeID equals t.ID

                where i.IsActive == true

                select new DTO_ItemCard
                {
                    ID = i.ID,

                    Title = i.Title,

                    ApproximateAddress =
                        a.Name + ", " + i.ApproximateAddress,

                    Type = t.Name,

                    Capacity = i.Capacity,

                    NumberOfBeds = i.NumberOfBeds,

                    NumberOfBathrooms = i.NumberOfBathrooms,

                    Status = "Active",

                    MinPrice =
                        db.ItemPrices
                        .Where(p => p.ItemID == i.ID)
                        .Min(p => (decimal?)p.Price),

                    ThumbnailPath =
                        db.ItemPictures
                        .Where(pic => pic.ItemID == i.ID)
                        .OrderBy(pic => pic.DisplayOrder)
                        .Select(pic => pic.PictureFileName)
                        .FirstOrDefault()
                };

            // keyword
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x =>
                    x.Title.ToLower().Contains(keyword)
                    || x.ApproximateAddress.ToLower().Contains(keyword)
                    || x.Type.ToLower().Contains(keyword));
            }

            // guests
            query = query.Where(x =>
                x.Capacity >= guests);

            // price
            query = query.Where(x =>
                x.MinPrice >= minPrice
                && x.MinPrice <= maxPrice);

            // sort
            switch (sortBy)
            {
                case "Price Low → High":
                    query = query.OrderBy(x => x.MinPrice);
                    break;

                case "Price High → Low":
                    query = query.OrderByDescending(x => x.MinPrice);
                    break;

                default:
                    query = query.OrderByDescending(x => x.ID);
                    break;
            }

            return query.ToList();
        }
    }
}