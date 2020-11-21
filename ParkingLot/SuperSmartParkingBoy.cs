using System;
using System.Collections;
using System.Collections.Generic;

namespace ParkingLot
{
    public class SuperSmartParkingBoy
    {
        private string name;
        private Dictionary<string, ParkingTicket> providedParkingTickets = new Dictionary<string, ParkingTicket>();
        private List<ParkingLot> managedParkingLots = new List<ParkingLot>();
        public SuperSmartParkingBoy(string inputName, ParkingLot parkingLot1, ParkingLot parkingLot2)
        {
            this.name = inputName;
            managedParkingLots.Add(parkingLot1);
            managedParkingLots.Add(parkingLot2);
        }

        public ParkingTicket Park(Car car)
        {
            if (car == null)
            {
                return null;
            }

            managedParkingLots.Sort((x, y) => ((y.GetCapacity() - y.GetCars().Count) / y.GetCapacity()) - ((x.GetCapacity() - x.GetCars().Count) / x.GetCapacity()));
            ParkingTicket parkingTicket = managedParkingLots[0].Park(car);
            if (parkingTicket != null)
            {
                UpdateProvidedParkingTicket(parkingTicket);
            }

            return parkingTicket;
        }

        public Car Fetch(ParkingTicket parkingTicket)
        {
            Printer printer = new Printer();
            if (parkingTicket == null)
            {
                printer.PrintMissingParkingTicketErrorMessage();
                return null;
            }

            if (!IsProvidedParkingTicket(parkingTicket) || parkingTicket.GetIsUsed())
            {
                printer.PrintWrongParkingTicketErrorMessage();
                return null;
            }

            Car fetchedCar = parkingTicket.GetParkingLot().Fetch(parkingTicket);
            if (fetchedCar != null)
            {
                parkingTicket.UseTicket();
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
