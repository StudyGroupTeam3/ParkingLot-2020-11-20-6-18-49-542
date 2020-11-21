using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<string> tickets = new List<string>()
        {
            "ticket-1-1", "ticket-1-2", "ticket-1-3", "ticket-1-4", "ticket-1-5",
            "ticket-1-6", "ticket-1-7", "ticket-1-8", "ticket-1-9", "ticket-1-10",
        };

        private List<string> ticketsUsed = new List<string>();

        private Dictionary<string, string> carAndTicketInformation = new Dictionary<string, string>();

        public bool HasPosition()
        {
            return carAndTicketInformation.Keys.Count < 10;
        }

        public string ParkingCar(string car)
        {
            if (HasPosition())
            {
                string ticket = tickets[0];
                carAndTicketInformation.Add(ticket, car);
                tickets.Remove(ticket);
                return ticket;
            }

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
            ticketsUsed.Add(ticket);
            carAndTicketInformation.Remove(ticket);
            //tickets.Add(ticket);
            return fecthedCar;
        }
    }
}
