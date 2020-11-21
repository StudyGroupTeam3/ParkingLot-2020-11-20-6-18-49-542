using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private string name;
        private Dictionary<string, ParkingTicket> providedParkingTickets = new Dictionary<string, ParkingTicket>();
        private List<ParkingLot> workedParkingLots = new List<ParkingLot>();
        public ParkingBoy(string inputName, ParkingLot parkingLot)
        {
            this.name = inputName;
            workedParkingLots.Add(parkingLot);
        }

        public ParkingTicket Park(Car car)
        {
            if (car == null)
            {
                return null;
            }

            ParkingTicket parkingTicket = workedParkingLots[0].Park(car);
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
