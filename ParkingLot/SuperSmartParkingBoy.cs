using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class SuperSmartParkingBoy : ParkingBoy
    {
        public SuperSmartParkingBoy(string name) : base(name)
        {
        }

        public override string Park(Car car, List<CarLot<string, Car>> parkinglots, out string message)
        {
            var lotIndex = SuperSmartFindLotIndex(parkinglots);

            if (parkinglots[lotIndex].Count < parkinglots[lotIndex].Capacity && IsCarNotParked(car, parkinglots))
            {
                ParkIntoPosition(car, parkinglots, lotIndex);

                message = "Your car is parked successfully";
                return $"SuperPark: {car.PlateNumber}";
            }

            message = "Not enough position.";
            return null;
        }

        private int SuperSmartFindLotIndex(List<CarLot<string, Car>> parkinglots)
        {
            int lotIndex = 0;
            double minimumLoadRate = 1;

            for (int index = 0; index < parkinglots.Count; index++)
            {
                if (parkinglots[index].LoadRate < minimumLoadRate)
                {
                    lotIndex = index;
                    minimumLoadRate = parkinglots[index].LoadRate;
                }
            }

            return lotIndex;
        }
    }
}
