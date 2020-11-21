using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public string Park(Car car, Dictionary<string, Car> parkinglot)
        {
            return $"SuperPark: {car.PlateNumber}";
        }

        public Car Fetch(string ticket, Dictionary<string, Car> parkinglot)
        {
            var car = new Car("RJ_36528");
            return car;
        }
    }
}
