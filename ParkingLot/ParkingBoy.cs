using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private int capacity = 10;
        private int maxParkingLots = 2;
        private Dictionary<string, string> carAndTicketInformation = new Dictionary<string, string>();

        public string ParkingCar(string car)
        {
            for (int i = 0; i < maxParkingLots; i++)
            {
                if (carAndTicketInformation.Count >= i * capacity && carAndTicketInformation.Count < (i + 1) * capacity)
                {
                    ParkingLots parkingLot = new ParkingLots($"{i + 1}");
                    List<string> tickets = parkingLot.GetTickets();
                    string ticket = tickets[carAndTicketInformation.Count - i * capacity];
                    carAndTicketInformation.Add(ticket, car);
                    return ticket;
                }
            }

            /*
            if (carAndTicketInformation.Count < maxParkingLots * capacity)
            {
                List<ParkingLots> parkingLotses = new List<ParkingLots>();
                List<string> tickets = new List<string>();
                for (int i = 0; i < maxParkingLots; i++)
                {
                    ParkingLots parkingLot = new ParkingLots($"{i} + 1");
                    for (int j = 0; j < capacity; j++)
                    {
                        tickets.Add(parkingLot.GetTickets()[j]);
                    }

                    parkingLotses.Add(parkingLot);
                }

                string ticket = tickets[carAndTicketInformation.Count];
                carAndTicketInformation.Add(ticket, car);
                return ticket;
            }
            */
            return "Not enough position.";
        }

        public string FetchCar(string ticket)
        {
            if (string.IsNullOrEmpty(ticket))
            {
                return "Please provide your parking ticket.";
            }

            if (!carAndTicketInformation.ContainsKey(ticket))
            {
                return "Unrecognized parking ticket.";
            }

            string fecthedCar = carAndTicketInformation[ticket];
            carAndTicketInformation.Remove(ticket);
            return fecthedCar;
        }
    }
}
