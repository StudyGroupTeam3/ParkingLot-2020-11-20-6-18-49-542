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
            ParkingTicket parkingTicket = null;
            if (ParkingLotHasPosition(parkingLot))
            {
                if (parkingLot.Park(car))
                {
                    parkingTicket = GenerateParkingTicket(car);
                    UpdateProvidedParkingTicket(parkingTicket);
                }
            }

            return parkingTicket;
        }

        public Car Fetch(ParkingTicket parkingTicket)
        {
            return null;
        }

        private bool ParkingLotHasPosition(ParkingLot parkingLot)
        {
            return parkingLot.HasPosition();
        }

        private ParkingTicket GenerateParkingTicket(Car car)
        {
            return new ParkingTicket(car.GetPlateNumber());
        }

        private void UpdateProvidedParkingTicket(ParkingTicket parkingTicket)
        {
            this.providedParkingTickets.TryAdd(parkingTicket.GetParkingTime(), parkingTicket);
        }
    }
}
