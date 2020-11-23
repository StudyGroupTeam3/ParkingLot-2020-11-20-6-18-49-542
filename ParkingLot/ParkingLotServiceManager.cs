using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingLotServiceManager : ParkingBoy
    {
        private List<ParkingBoy> managedParkingBoys = new List<ParkingBoy>();
        public ParkingLotServiceManager(string inputName, ParkingLot parkingLot1, ParkingLot parkingLot2) : base(inputName, parkingLot1, parkingLot2)
        {
        }

        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            managedParkingBoys.Add(parkingBoy);
        }

        public void RemoveParkingBoy(ParkingBoy parkingBoy)
        {
            if (parkingBoy != null)
            {
                managedParkingBoys.Remove(parkingBoy);
            }
        }

        public void GetParkingBoyToPark(Car car)
        {
            managedParkingBoys[0].Park(car);
        }

        public void GetParkingBoyToFetch(ParkingTicket parkingTicket)
        {
            managedParkingBoys[0].Fetch(parkingTicket);
        }
    }
}
