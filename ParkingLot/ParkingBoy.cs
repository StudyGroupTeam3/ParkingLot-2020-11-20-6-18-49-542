using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public string Park(Car car, Dictionary<string, Car> parkinglot)
        {
            parkinglot.Add(car.PlateNumber, car);
            return $"SuperPark: {car.PlateNumber}";
        }

        public Car Fetch(string ticket, Dictionary<string, Car> parkinglot)
        {
            var plateNumber = ticket.Split(" ")[1];
            if (parkinglot.ContainsKey(plateNumber))
            {
                var car = parkinglot[plateNumber];
                return car;
            }

            return null;
        }
    }
}
