using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Printer
    {
        public void PrintWrongParkingTicketErrorMessage()
        {
            Console.WriteLine("Unrecognized parking ticket");
        }

        public void PrintMissingParkingTicketErrorMessage()
        {
            Console.WriteLine("Please provide your parking ticket");
        }

        public void PrintNoEnoughPositionInParkingLotErrorMessage()
        {
            Console.WriteLine("Not enough position");
        }
    }
}
