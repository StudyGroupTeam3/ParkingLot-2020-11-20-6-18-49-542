using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Models
{
    public class ParkingLot
    {
        private readonly int capacity;
        private List<CarParked> cars = new List<CarParked>();
        private int lotNumber;
        private int parkingNumber = 1;

        public ParkingLot(int lotNumber, int capacity)
        {
            this.lotNumber = lotNumber;
            this.capacity = capacity;
        }

        public int Capacity => capacity;
        public int LotNumber => lotNumber;
        public int CarsCount => cars.Count;

        public string AddCarGetTicket(Car car)
        {
            var ticket = $"{lotNumber.ToString().PadLeft(2, '0')}{parkingNumber.ToString().PadLeft(3, '0')}";
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
