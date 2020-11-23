using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Car
    {
        public Car(string carId)
        {
            this.CarId = carId;
        }

        public string CarId { get; }
    }
}
