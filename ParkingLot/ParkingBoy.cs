﻿using System;
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

        public ParkingTicket ParkCar(ICar car)
        {
            uint carId = this.parkingLot.CarId;
            uint parkingLotId = this.parkingLot.ParkingLotId;
            this.parkingLot.AddCar(car);
            return new ParkingTicket(parkingLotId, carId);
        }

        public ICar FetchCar(ParkingTicket parkingTicket)
        {
            if (parkingTicket is null)
            {
                return null;
            }

            if (!this.parkingLot.IsCarIdProvided(parkingTicket.CarId))
            {
                return null;
            }

            return this.parkingLot.GetCar(parkingTicket.CarId);
        }
    }
}
