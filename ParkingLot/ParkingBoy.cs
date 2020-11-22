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
            if (car is null)
            {
                return null;
            }

            if (this.parkingLot.HasCar(car))
            {
                return null;
            }

            if (!this.parkingLot.HasPosition())
            {
                return null;
            }

            uint carId = this.parkingLot.CarId;
            uint parkingLotId = this.parkingLot.ParkingLotId;
            this.parkingLot.AddCar(car);
            return new ParkingTicket(parkingLotId, carId);
        }

        public ICar FetchCar(ParkingTicket parkingTicket, out string errorMessage)
        {
            if (parkingTicket is null)
            {
                errorMessage = "Please provide your parking ticket.";
                return null;
            }

            if (!this.parkingLot.IsCarIdProvided(parkingTicket.CarId))
            {
                errorMessage = "Unrecognized parking ticket.";
                return null;
            }

            if (!this.parkingLot.HasCarId(parkingTicket.CarId))
            {
                errorMessage = "Unrecognized parking ticket.";
                return null;
            }

            errorMessage = null;
            return this.parkingLot.GetCar(parkingTicket.CarId);
        }
    }
}
