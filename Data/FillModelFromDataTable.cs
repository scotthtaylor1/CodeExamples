﻿//using SRDATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data
{
    public class Location
    {
        static IDictionary<string, string> SQLPV = new Dictionary<string, string>();

        readonly int locationID;
        readonly string locationName;
        readonly string parentLocationID;
        readonly string parentLocationName;
        readonly string systemName;
        readonly string fullAddress;
        readonly int doorCount;
        readonly bool deleted;

        public int LocationID { get { return locationID; } }
        public string LocationName { get { return locationName; } }
        public string ParentLocationID { get { return parentLocationID; } }
        public string ParentLocationName { get { return parentLocationName; } }
        public string SystemName { get { return systemName; } }
        public string FullAddress { get { return fullAddress; } }
        public int DoorCount { get { return doorCount; } }
        public bool Deleted { get { return deleted; } }

        public Location(int locationID, string locationName, string parentLocationID, string parentLocationName, string systemName, string fullAddress, int doorCount, bool deleted)
        {
            this.locationID = locationID;
            this.locationName = locationName;
            this.parentLocationID = parentLocationID;
            this.parentLocationName = parentLocationName;
            this.systemName = systemName;
            this.fullAddress = fullAddress;
            this.doorCount = doorCount;
            this.deleted = deleted;
        }

        Location() { }
        public static List<Location> GetAllLocations(int customerID, int userID)
        {
            List<Location> locations = new List<Location>();

            SQLPV.Clear();
            SQLPV.Add("CustomerID", customerID.ToString());  //TODO - build customer selection ddl to set this.
            SQLPV.Add("UserID", userID.ToString());
            DataTable dt = new DataTable();
            //Helpers.DataTableFiller("SecurityRecords", "loc_viewAllLocationsNEW", dt, SQLPV); //From SRData

            locations = (from DataRow dr in dt.Rows
                         select new Location(
                             locationID: Convert.ToInt32(dr["LocationID"]),
                             locationName: dr["LocationName"].ToString(),
                             parentLocationID: dr["parentLocationID"].ToString(),
                             parentLocationName: dr["parentLocationName"].ToString(),
                             systemName: dr["SystemName"].ToString(),
                             fullAddress: dr["FullAddress"].ToString(),
                             doorCount: Convert.ToInt32(dr["DoorCount"]),
                             deleted: Convert.ToBoolean(dr["deleted"])
                             )
                         ).ToList();

            return locations;
        }
    }
}
