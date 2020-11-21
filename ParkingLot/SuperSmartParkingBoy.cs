using System;
using System.Collections;
using System.Collections.Generic;

namespace ParkingLot
{
    public class SuperSmartParkingBoy : ParkingBoy
    {
        public SuperSmartParkingBoy(string inputName, ParkingLot parkingLot1, ParkingLot parkingLot2) : base(inputName, parkingLot1, parkingLot2)
        {
        }

        public new ParkingTicket Park(Car car)
        {
            Printer printer = new Printer();
            if (car == null)
            {
                printer.PrintNullCarErrorMessage();
                return null;
            }

            ManagedParkingLots.Sort((x, y) => ((y.GetCapacity() - y.GetCars().Count) / y.GetCapacity()) - ((x.GetCapacity() - x.GetCars().Count) / x.GetCapacity()));
            ParkingTicket parkingTicket = ManagedParkingLots[0].Park(car);
            if (parkingTicket != null)
            {
                UpdateProvidedParkingTicket(parkingTicket);
            }

            return parkingTicket;
        }
    }
}
