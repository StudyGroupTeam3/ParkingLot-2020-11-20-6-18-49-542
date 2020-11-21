using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<string> ticketNumber = new List<string>()
        {
            "1-1", "1-2", "1-3", "1-4", "1-5", "1-6", "1-7", "1-8", "1-9", "1-10"
        };

        public void ParkingCars()
        {
        }

        public string GiveTickets()
        {
            return ticketNumber[0];
        }
    }
}
