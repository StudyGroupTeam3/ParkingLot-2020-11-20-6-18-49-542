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
            if (parkingTicket != null)
            {
                UpdateProvidedParkingTicket(parkingTicket);
            }

            return parkingTicket;
        }

        public Car Fetch(ParkingTicket parkingTicket, ParkingLot parkingLot)
        {
            Car fetchedCar = null;
            var a = parkingTicket.GetIsUsed();
            if (IsProvidedParkingTicket(parkingTicket) && !parkingTicket.GetIsUsed())
            {
                fetchedCar = parkingLot.Fetch(parkingTicket);
                if (fetchedCar != null)
                {
                    parkingTicket.UseTicket();
                }
            }

            return fetchedCar;
        }

        private void UpdateProvidedParkingTicket(ParkingTicket parkingTicket)
        {
            this.providedParkingTickets.TryAdd(parkingTicket.GetParkingTime(), parkingTicket);
        }

        private bool IsProvidedParkingTicket(ParkingTicket parkingTicket)
        {
            return this.providedParkingTickets.ContainsKey(parkingTicket.GetParkingTime());
        }
    }
}
