using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingLots
    {
        private string parkingLotName;
        private int capacity = 10;
        public ParkingLots(string parkingLotName)
        {
            this.parkingLotName = parkingLotName;
        }

        public List<string> GetTickets()
        {
            List<string> tickets = new List<string>();
            for (int i = 0; i < capacity; i++)
            {
                tickets.Add($"ticket-{parkingLotName}-{i + 1}");
            }

            return tickets;
        }
    }
}
