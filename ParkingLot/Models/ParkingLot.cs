using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Models
{
    public class Parkinglot
    {
        private readonly int capacity;
        private List<CarParked> cars = new List<CarParked>();
        private int parkingNumber = 1;

        public Parkinglot(int capacity)
        {
            this.capacity = capacity;
        }

        public string LotNumber { get; set; }
        public int Capacity => capacity;
        public int CarsCount => cars.Count;
        public double AvailablePosition => capacity - cars.Count;
        public double AvailablePositionRate => AvailablePosition / capacity;
        public string ParkingNumber => parkingNumber.ToString().PadLeft(3, '0');

        public string AddCarGetTicket(Car car)
        {
            var ticket = $"{LotNumber}{ParkingNumber}";
            cars.Add(new CarParked(ticket, car));
            parkingNumber++;

            return ticket;
        }

        public Car GetCarGivenTicket(string ticket)
        {
            var carFetched = cars.FirstOrDefault(car => car.Ticket == ticket);
            cars.Remove(carFetched);

            return carFetched?.Car;
        }
    }
}
