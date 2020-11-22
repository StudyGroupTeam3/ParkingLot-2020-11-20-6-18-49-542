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

        public string ParkingCar(string car)
        {
            if (carAndTicketInformation.Count < capacity)
            {
                ParkingLots parkingLot = new ParkingLots("1");
                List<string> tickets = parkingLot.GetTickets();
                string ticket = tickets[carAndTicketInformation.Count];
                carAndTicketInformation.Add(ticket, car);
                return ticket;
            }

            if (carAndTicketInformation.Count >= capacity && carAndTicketInformation.Count < 2 * capacity)
            {
                ParkingLots parkingLot = new ParkingLots("2");
                List<string> tickets = parkingLot.GetTickets();
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
