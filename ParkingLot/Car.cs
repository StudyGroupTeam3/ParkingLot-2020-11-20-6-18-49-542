using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Car
    {
        public Car(string plateNumber)
        {
            PlateNumber = plateNumber;
        }

        public string PlateNumber { get; }
    }
}
