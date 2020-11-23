using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public delegate void FailOperation(string errorMessage);

    public class ParkingLotServiceManager : ParkingBoy
    {
        private readonly List<ParkingBoy> managementList = new List<ParkingBoy>();
        private string errorMessage = string.Empty;
        public ParkingLotServiceManager(List<ParkingLot> parkingLotList, List<ParkingBoy> managementList) : base(parkingLotList)
        {
            this.managementList = managementList;
        }

        public string ErrorMessage => this.errorMessage;

        public void AddParkingBoy(ParkingBoy parkingBoy = null)
        {
            if (!(parkingBoy is null))
            {
                this.managementList.Add(parkingBoy);
            }
        }

        public ParkingBoy SpecifyParkingBoy()
        {
            var specifiedParkingBoy = this.managementList[0];
            specifiedParkingBoy.FailOperation = ParkingBoyFailOperation;
            return specifiedParkingBoy;
        }

        private void ParkingBoyFailOperation(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }
    }
}
