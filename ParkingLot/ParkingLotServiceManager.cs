using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingLotServiceManager : ParkingBoy
    {
        private List<ParkingBoy> managementList = new List<ParkingBoy>();
        public ParkingLotServiceManager(List<ParkingLot> parkingLotList, List<ParkingBoy> managementList) : base(parkingLotList)
        {
            this.managementList = managementList;
        }

        public void AddParkingBoy(ParkingBoy parkingBoy = null)
        {
            if (!(parkingBoy is null))
            {
                this.managementList.Add(parkingBoy);
            }
        }

        public ParkingBoy SpecifyParkingBoy()
        {
            return this.managementList[0];
        }
    }
}
