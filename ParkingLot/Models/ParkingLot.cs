using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Models
{
    public class ParkingLot
    {
        private List<CarParked> cars = new List<CarParked>();
        private int capacity = 10;

        public List<CarParked> LoadCars()
        {
            var carsList = cars;

            return carsList;
        }

        public string AddCarGetTicket(Car car)
        {
            if (car == null)
            {
                return "wrong car";
            }

            var newId = cars.Count + 1;
            if (newId < this.capacity)
            {
                var newTicket = newId.ToString().PadLeft(3, '0');
                cars.Add(new CarParked(newTicket, car));

                return newTicket;
            }

            return "Not enough position";
        }

        public Car GetCarGivenTicket(string ticket)
        {
            var carFetched = cars.FirstOrDefault(car => car.Ticket == ticket)?.Car;
            cars.Remove(cars.FirstOrDefault(car => car.Ticket == ticket));

            return carFetched;
        }
    }
}
