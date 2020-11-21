using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private readonly ParkingLot parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public ParkingTicket ParCar(ICar car)
        {
            uint carId = this.parkingLot.CarId;
            uint parkingLotId = this.parkingLot.ParkingLotId;
            this.parkingLot.AddCar(car);
            return new ParkingTicket(parkingLotId, carId);
        }
    }
}
