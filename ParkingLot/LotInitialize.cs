using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class LotInitialize
    {
        public static Dictionary<string, Car> FillLotWithCars(int carNumber)
        {
            var parkinglotInitilizer = new LotInitialize();
            var cars = parkinglotInitilizer.GenerateCars(carNumber);
            var parkingLot = new Dictionary<string, Car>();

            foreach (var car in cars)
            {
                parkingLot.Add(car.PlateNumber, car);
            }

            return parkingLot;
        }

        private string GeneratePlateNumber()
        {
            Random rnd = new Random();
            var platenumber = rnd.Next(1000, 9999);
            return $"CityCode_{platenumber}";
        }

        private List<Car> GenerateCars(int carNumber)
        {
            var cars = new List<Car>();
            int loopIndex = 0;
            while (loopIndex < carNumber)
            {
                cars.Add(new Car(GeneratePlateNumber()));
                loopIndex += 1;
            }

            return cars;
        }
    }
}
