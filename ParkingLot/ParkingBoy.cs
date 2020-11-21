using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private string name;
        private Dictionary<string, ParkingTicket> providedParkingTickets = new Dictionary<string, ParkingTicket>();
        private List<ParkingLot> managedParkingLots = new List<ParkingLot>();
        public ParkingBoy(string inputName, ParkingLot parkingLot1, ParkingLot parkingLot2)
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
