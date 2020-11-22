using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Models
{
    public class Manager
    {
        private List<Boy> managementList = new List<Boy>();
        public List<Boy> ManagementList => managementList;

        public void AddBoy(Boy boy)
        {
            managementList.Add(boy);
        }
    }
}
