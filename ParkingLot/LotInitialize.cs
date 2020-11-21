using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class LotInitialize
    {
        public static Dictionary<string, Car> FillLotWithSomeCars()
        {
            var cars = new List<Car>()
            {
                new Car("RJ_12784"),
                new Car("RJ_34543"),
                new Car("RJ_12446"),
            };
            var parkingLot = new Dictionary<string, Car>();

            foreach (var car in cars)
            {
                parkingLot.Add(car.PlateNumber, car);
            }

            return parkingLot;
        }

        public static Dictionary<string, Car> FillLotWithTenCars()
        {
            var cars = new List<Car>()
            {
                new Car("RJ_12335"),
                new Car("RJ_65421"),
                new Car("RJ_45675"),
                new Car("RJ_15456"),
                new Car("RJ_45731"),
                new Car("RJ_45372"),
                new Car("RJ_45326"),
                new Car("RJ_78341"),
                new Car("RJ_45387"),
                new Car("RJ_78635"),
            };
            var parkingLot = new Dictionary<string, Car>();

            foreach (var car in cars)
            {
                parkingLot.Add(car.PlateNumber, car);
            }

            return parkingLot;
        }
    }
}
