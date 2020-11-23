using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ParkingLot
{
    public class ParkingLot
    {
        public ParkingLot(string lotName)
        {
            LotName = lotName;
        }

        public string LotName { get; }
        public int Capacity => 10;
    }
}
