using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingTicket
    {
        public ParkingTicket(uint parkingLotId, uint carId)
        {
            this.ParkingLotId = parkingLotId;
            this.CarId = carId;
        }

        public uint ParkingLotId { get; }

        public uint CarId { get; }
    }
}
