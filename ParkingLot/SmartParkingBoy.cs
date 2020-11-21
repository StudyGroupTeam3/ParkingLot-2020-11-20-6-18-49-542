using System;
using System.Collections;
using System.Collections.Generic;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(string inputName, ParkingLot parkingLot1, ParkingLot parkingLot2) : base(inputName,
            parkingLot1, parkingLot2)
        {
        }

        public ParkingTicket Park(Car car)
        {
            if (car == null)
            {
                return null;
            }

            ManagedParkingLots.Sort((x, y) => y.GetCapacity() - y.GetCars().Count - (x.GetCapacity() - x.GetCars().Count));
            ParkingTicket parkingTicket = ManagedParkingLots[0].Park(car);
            if (parkingTicket != null)
            {
                UpdateProvidedParkingTicket(parkingTicket);
            }

            return parkingTicket;
        }
    }
}
