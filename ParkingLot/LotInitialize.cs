using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class LotInitialize
    {
        public static CarLot<string, Car> FillLotWithCars(int carNumber)
        {
            var parkingLot = new CarLot<string, Car>();
            int loopIndex = 0;
            while (loopIndex < carNumber)
            {
                var parkedCar = new Car(GeneratePlateNumber());
                parkingLot.Add(parkedCar.PlateNumber, parkedCar);
                loopIndex += 1;
            }

            return parkingLot;
        }

        private static string GeneratePlateNumber()
        {
            Random rnd = new Random();
            var platenumber = rnd.Next(1000, 9999);
            return $"CityCode_{platenumber}";
        }
    }
}
