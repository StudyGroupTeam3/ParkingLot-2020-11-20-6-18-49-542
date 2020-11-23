using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private string name;
        private string manager = string.Empty;
        private Dictionary<string, ParkingTicket> providedParkingTickets = new Dictionary<string, ParkingTicket>();
        public ParkingBoy(string inputName, ParkingLot parkingLot1, ParkingLot parkingLot2)
        {
            this.name = inputName;
            ManagedParkingLots.Add(parkingLot1);
            ManagedParkingLots.Add(parkingLot2);
        }

        public List<ParkingLot> ManagedParkingLots { get; private set; } = new List<ParkingLot>();

        public ParkingTicket Park(Car car)
        {
            Printer printer = new Printer();
            if (car == null)
            {
                printer.PrintNullCarErrorMessage();
                return null;
            }

            ParkingTicket parkingTicket = null;
            foreach (var parkingLot in ManagedParkingLots)
            {
                parkingTicket = parkingLot.Park(car);
                if (parkingTicket == null)
                {
                    continue;
                }

                UpdateProvidedParkingTicket(parkingTicket);
                break;
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

            UpdateProvidedParkingTicket(parkingTicket);
            return fetchedCar;
        }

        public void SetManager(string assignedManager)
        {
            this.manager = assignedManager;
        }

        public string GetManager()
        {
            return this.manager;
        }

        public void SetParkingLots(List<ParkingLot> assignedParkingLotsparkingLots)
        {
            this.ManagedParkingLots = assignedParkingLotsparkingLots;
        }

        protected void UpdateProvidedParkingTicket(ParkingTicket parkingTicket)
        {
            this.providedParkingTickets.TryAdd(parkingTicket.GetParkingTime(), parkingTicket);
        }

        private bool IsProvidedParkingTicket(ParkingTicket parkingTicket)
        {
            return this.providedParkingTickets.ContainsKey(parkingTicket.GetParkingTime());
        }
    }
}
