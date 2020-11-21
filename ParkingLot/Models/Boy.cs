using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Models
{
    public class Boy
    {
        private ParkingLot parkingLot;
        public Boy()
        {
            parkingLot = new ParkingLot();
        }

        public string ParkCar(Car car)
        {
            var ticket = parkingLot.AddCarGetTicket(car);

            return ticket;
        }

        public Car FetchCar(string ticket)
        {
            var car = parkingLot.GetCarGivenTicket(ticket);

            return car ?? new Car("Unrecognized parking ticket");
        }

        public int GetCarsCount()
        {
            return parkingLot.LoadCars().Count;
        }
    }
}
