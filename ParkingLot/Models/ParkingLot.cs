using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Models
{
    public class ParkingLot
    {
        private List<CarParked> cars = new List<CarParked>();

        public List<CarParked> LoadCars()
        {
            var carsList = cars;

            return carsList;
        }

        public string AddCarGetTicket(Car car)
        {
            var newId = cars.Count + 1;
            var newTicket = newId.ToString().PadLeft(3, '0');
            cars.Add(new CarParked(newTicket, car));

            return newTicket;
        }

        public Car GetCarGivenTicket(string ticket)
        {
            var carFetched = cars.FirstOrDefault(car => car.Ticket == ticket)?.Car;

            return carFetched;
        }
    }
}
