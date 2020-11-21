using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private string name;
        private Dictionary<string, ParkingTicket> providedParkingTickets = new Dictionary<string, ParkingTicket>();
        public ParkingBoy(string inputName)
        {
            this.name = inputName;
        }

        public ParkingTicket Park(Car car, ParkingLot parkingLot)
        {
            ParkingTicket parkingTicket = parkingLot.Park(car);
            UpdateProvidedParkingTicket(parkingTicket);
            return parkingTicket;
        }

        public Car Fetch(ParkingTicket parkingTicket)
        {
            return null;
        }

        private void UpdateProvidedParkingTicket(ParkingTicket parkingTicket)
        {
            this.providedParkingTickets.TryAdd(parkingTicket.GetParkingTime(), parkingTicket);
        }
    }
}
