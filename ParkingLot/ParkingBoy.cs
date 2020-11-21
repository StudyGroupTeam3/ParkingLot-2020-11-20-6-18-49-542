using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private string car;
        private string ticket;
        private List<string> tickets = new List<string>()
        {
            "ticket-1-1", "ticket-1-2", "ticket-1-3", "ticket-1-4", "ticket-1-5",
            "ticket-1-6", "ticket-1-7", "ticket-1-8", "ticket-1-9", "ticket-1-10",
        };

        public string ParkingCar(string car)
        {
            this.car = car;
            return tickets[0];
        }

        public string FetchCar(string ticket)
        {
            string carTicket = ParkingCar(car);
            if (ticket != carTicket || ticket == null)
            {
                return "No car fetched";
            }

            return car;
        }
    }
}
