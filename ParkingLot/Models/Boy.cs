using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Models
{
    public class Boy
    {
        public string ParkCar(Car car)
        {
            return $"Brand: {car.Brand}\nTime: {DateTime.Now}";
        }

        public string FetchCar(string ticket)
        {
            return "BWM";
        }
    }
}
