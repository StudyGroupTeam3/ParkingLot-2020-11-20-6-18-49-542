using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public override string Park(Car car, List<CarLot<string, Car>> parkinglots, out string message)
        {
            var lotIndex = SmartFindLotIndex(parkinglots);

            if (parkinglots[lotIndex].Count < parkinglots[lotIndex].Capacity && IsCarNotParked(car, parkinglots))
            {
                ParkIntoPosition(car, parkinglots, lotIndex);

                message = "Your car is parked successfully";
                return $"SuperPark: {car.PlateNumber}";
            }

            message = "Not enough position.";
            return null;
        }

        private int SmartFindLotIndex(List<CarLot<string, Car>> parkinglots)
        {
            int lotIndex = 0;
            int minimumLoad = 1000;

            for (int index = 0; index < parkinglots.Count; index++)
            {
                if (parkinglots[index].Count < minimumLoad)
                {
                    lotIndex = index;
                    minimumLoad = parkinglots[index].Count;
                }
            }

            return lotIndex;
        }
    }
}
