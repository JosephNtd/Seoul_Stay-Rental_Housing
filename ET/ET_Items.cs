using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_Items
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public long UserID { get; set; }
        public long ItemTypeID { get; set; }
        public long AreaID { get; set; }
        public string Title { get; set; }
        public int Capacity { get; set; }
        public int NumberOfBeds { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public string ExactAddress { get; set; }
        public string ApproximateAddress { get; set; }
        public string Description { get; set; }
        public string HostRules { get; set; }
        public int MinimumNights { get; set; }
        public int MaximumNights { get; set; }

        public ET_Items() { }

        public ET_Items(long iD, Guid gUID, long userID, long itemTypeID, long areaID, string title, int capacity, int numberOfBeds, int numberOfBedrooms, int numberOfBathrooms, string exactAddress, string approximateAddress, string description, string hostRules, int minimumNights, int maximumNights)
        {
            ID = iD;
            GUID = gUID;
            UserID = userID;
            ItemTypeID = itemTypeID;
            AreaID = areaID;
            Title = title;
            Capacity = capacity;
            NumberOfBeds = numberOfBeds;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            ExactAddress = exactAddress;
            ApproximateAddress = approximateAddress;
            Description = description;
            HostRules = hostRules;
            MinimumNights = minimumNights;
            MaximumNights = maximumNights;
        }
    }
}
