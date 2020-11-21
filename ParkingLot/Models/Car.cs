using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ParkingLot.Models
{
    public class Car
    {
        public Car(string brand)
        {
            Brand = brand;
        }

        public string Brand { get; }
    }

    public class CarParked
    {
        public CarParked(string ticket, Car car)
        {
            Ticket = ticket;
            Car = car;
        }

        public Car Car { get; }
        public string Ticket { get; }
    }
}
