using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private string name;

        public ParkingBoy(string inputName)
        {
            this.name = inputName;
        }

        public ParkingTicket Park(Car car, ParkingLot parkingLot)
        {
            if (ParkingLotHasNoPosition(parkingLot))
            {
                return GenerateParkingTicket(car);
            }

            return null;
        }

        public Car Fetch(ParkingTicket parkingTicket)
        {
            return null;
        }

        private bool ParkingLotHasNoPosition(ParkingLot parkingLot)
        {
            return parkingLot.HasPosition();
        }

        private ParkingTicket GenerateParkingTicket(Car car)
        {
            return new ParkingTicket(car.GetPlateNumber());
        }
    }
}
