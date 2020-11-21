using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public string Park(Car car, Dictionary<string, Car> parkinglot)
        {
            if (parkinglot.Count < 10 && !parkinglot.ContainsKey(car.PlateNumber))
            {
                try
                {
                    parkinglot.Add(car.PlateNumber, car);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return $"SuperPark: {car.PlateNumber}";
            }

            return null;
        }

        public Car Fetch(string ticket, Dictionary<string, Car> parkinglot)
        {
            var plateNumber = ticket.Split(" ")[1];
            if (parkinglot.ContainsKey(plateNumber))
            {
                var car = parkinglot[plateNumber];
                parkinglot.Remove(plateNumber);
                return car;
            }

            return null;
        }

        public Car Fetch(string ticket, Dictionary<string, Car> parkinglot, out string message)
        {
            var plateNumber = ticket.Split(" ")[1];
            if (parkinglot.ContainsKey(plateNumber))
            {
                var car = parkinglot[plateNumber];
                parkinglot.Remove(plateNumber);
                message = "Your car is parked successfully";
                return car;
            }

            message = "Unrecognized parking ticket.";
            return null;
        }

        public Car Fetch(Dictionary<string, Car> parkinglot)
        {
            return null;
        }

        public Car Fetch(Dictionary<string, Car> parkinglot, out string message)
        {
            message = "Please provide your parking ticket.";
            return null;
        }
    }
}
