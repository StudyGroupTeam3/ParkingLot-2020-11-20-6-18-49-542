using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private int capacity = 10;
        private Dictionary<string, string> carAndTicketInformation = new Dictionary<string, string>();

        public List<string> GetTickets(string parkingLotName)
        {
            List<string> tickets = new List<string>();
            for (int i = 0; i < capacity; i++)
            {
                tickets.Add($"ticket-{parkingLotName}-{i + 1}");
            }

            return tickets;
        }

        public string ParkingCar(string car)
        {
            if (carAndTicketInformation.Count < capacity)
            {
                List<string> tickets = GetTickets("1");
                string ticket = tickets[carAndTicketInformation.Count];
                carAndTicketInformation.Add(ticket, car);
                return ticket;
            }

            if (carAndTicketInformation.Count >= capacity && carAndTicketInformation.Count < 2 * capacity)
            {
                List<string> tickets = GetTickets("2");
                string ticket = tickets[carAndTicketInformation.Count - capacity];
                carAndTicketInformation.Add(ticket, car);
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
            carAndTicketInformation.Remove(ticket);
            //tickets.Add(ticket);
            return fecthedCar;
        }
    }
}
