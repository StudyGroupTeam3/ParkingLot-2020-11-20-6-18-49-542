using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        protected int IndexOfPlateNumber => 1;

        public virtual string Park(Car car, List<CarLot<string, Car>> parkinglots)
        {
            var lotIndex = FindLotIndex(parkinglots);

            if (parkinglots[lotIndex].Count < parkinglots[lotIndex].Capacity && IsCarNotParked(car, parkinglots))
            {
                ParkIntoPosition(car, parkinglots, lotIndex);

                return $"SuperPark: {car.PlateNumber}";
            }

            return null;
        }

        public virtual string Park(Car car, List<CarLot<string, Car>> parkinglots, out string message)
        {
            var lotIndex = FindLotIndex(parkinglots);

            if (parkinglots[lotIndex].Count < parkinglots[lotIndex].Capacity && IsCarNotParked(car, parkinglots))
            {
                ParkIntoPosition(car, parkinglots, lotIndex);

                message = "Your car is parked successfully";
                return $"SuperPark: {car.PlateNumber}";
            }

            message = "Not enough position.";
            return null;
        }

        public Car Fetch(string ticket, List<CarLot<string, Car>> parkinglots)
        {
            var plateNumber = ticket.Split(" ")[IndexOfPlateNumber];
            var targetParkinglot = parkinglots.Where(lot => lot.ContainsKey(plateNumber)).ToList();
            if (targetParkinglot.Count == 0)
            {
                return null;
            }

            var car = targetParkinglot[0][plateNumber];
            targetParkinglot[0].Remove(plateNumber);
            return car;
        }

        public Car Fetch(string ticket, List<CarLot<string, Car>> parkinglots, out string message)
        {
            var plateNumber = ticket.Split(" ")[IndexOfPlateNumber];
            var targetParkinglot = parkinglots.Where(lot => lot.ContainsKey(plateNumber)).ToList();
            if (targetParkinglot.Count == 0)
            {
                message = "Unrecognized parking ticket.";
                return null;
            }

            var car = targetParkinglot[0][plateNumber];
            targetParkinglot[0].Remove(plateNumber);
            message = "Here is your car";
            return car;
        }

        public Car Fetch(List<CarLot<string, Car>> parkinglot)
        {
            return null;
        }

        public Car Fetch(List<CarLot<string, Car>> parkinglot, out string message)
        {
            message = "Please provide your parking ticket.";
            return null;
        }

        protected bool IsCarNotParked(Car car, List<CarLot<string, Car>> parkinglots)
        {
            foreach (var lot in parkinglots)
            {
                if (lot.ContainsKey(car.PlateNumber))
                {
                    return false;
                }
            }

            return true;
        }

        protected void ParkIntoPosition(Car car, List<CarLot<string, Car>> parkinglots, int lotIndex)
        {
            try
            {
                parkinglots[lotIndex].Add(car.PlateNumber, car);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private int FindLotIndex(List<CarLot<string, Car>> parkinglots)
        {
            int lotIndex = 0;

            while (parkinglots[lotIndex].Count == parkinglots[lotIndex].Capacity)
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
