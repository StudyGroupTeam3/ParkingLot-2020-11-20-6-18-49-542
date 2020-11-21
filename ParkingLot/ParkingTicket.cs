using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingTicket
    {
        private string parkingTime = default(DateTime).ToShortTimeString();
        private bool isUsed = false;
        private string carPlateNumber;

        public ParkingTicket(string parkedCarPlateNumber)
        {
            this.carPlateNumber = parkedCarPlateNumber;
        }

        public void UseTicket()
        {
            this.isUsed = true;
        }
    }
}
