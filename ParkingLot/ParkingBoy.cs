using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private int parkingCapacity = 10;
        private int indexOfPlateNumber = 1;
        public string Park(Car car, List<Dictionary<string, Car>> parkinglots)
        {
            var lotIndex = FindLotIndex(parkinglots);

            if (parkinglots[lotIndex].Count < parkingCapacity && !parkinglots[lotIndex].ContainsKey(car.PlateNumber))
            {
                try
                {
                    parkinglots[lotIndex].Add(car.PlateNumber, car);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return $"SuperPark: {car.PlateNumber}";
            }

            return null;
        }

        public string Park(Car car, List<Dictionary<string, Car>> parkinglots, out string message)
        {
            var lotIndex = FindLotIndex(parkinglots);

            if (parkinglots[lotIndex].Count < parkingCapacity && !parkinglots[lotIndex].ContainsKey(car.PlateNumber))
            {
                try
                {
                    parkinglots[lotIndex].Add(car.PlateNumber, car);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                message = "Your car is parked successfully";
                return $"SuperPark: {car.PlateNumber}";
            }

            message = "Not enough position.";
            return null;
        }

        public Car Fetch(string ticket, List<Dictionary<string, Car>> parkinglot)
        {
            var plateNumber = ticket.Split(" ")[indexOfPlateNumber];
            if (parkinglot[0].ContainsKey(plateNumber))
            {
                var car = parkinglot[0][plateNumber];
                parkinglot[0].Remove(plateNumber);
                return car;
            }

            return null;
        }

        public Car Fetch(string ticket, List<Dictionary<string, Car>> parkinglot, out string message)
        {
            var plateNumber = ticket.Split(" ")[indexOfPlateNumber];
            if (parkinglot[0].ContainsKey(plateNumber))
            {
                var car = parkinglot[0][plateNumber];
                parkinglot[0].Remove(plateNumber);
                message = "Here is your car";
                return car;
            }

            message = "Unrecognized parking ticket.";
            return null;
        }

        public Car Fetch(List<Dictionary<string, Car>> parkinglot)
        {
            return null;
        }

        public Car Fetch(List<Dictionary<string, Car>> parkinglot, out string message)
        {
            message = "Please provide your parking ticket.";
            return null;
        }

        private int FindLotIndex(List<Dictionary<string, Car>> parkinglots)
        {
            int lotIndex = 0;

            while (parkinglots[lotIndex].Count == parkingCapacity)
            {
                if (lotIndex == parkinglots.Count - 1)
                {
                    break;
                }

                lotIndex += 1;
            }

            return lotIndex;
        }
    }
}
