using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;
using Xunit;

namespace ParkingLotTest
{
    public class Story5Test
    {
        [Fact]
        public void AC1and2_Should_return_1car_from_Lot1_10cars_from_Lot2()
        {
            // given
            var manager = new Manager();
            manager.AddParkingLot(new Parkinglot(10));
            manager.AddParkingLot(new Parkinglot(100));
            var superBoy = new SuperBoy(1);
            manager.AddBoy(superBoy);
            manager.DistributeParkingLots(superBoy, manager.ParkingLots[0]);
            manager.DistributeParkingLots(superBoy, manager.ParkingLots[1]);

            var car = new Car("BMW");
            var count = 0;

            // when
            while (count < 11)
            {
                superBoy.ParkCar(car);
                count++;
            }

            var expectedCarsCountFromLot1 = 1;
            var actualCarsCountFromLot1 = superBoy.ParkingLots[0].CarsCount;

            var expectedCarsCountFromLot2 = 10;
            var actualCarsCountFromLot2 = superBoy.ParkingLots[1].CarsCount;

            // then
            Assert.Equal(expectedCarsCountFromLot1, actualCarsCountFromLot1);
            Assert.Equal(expectedCarsCountFromLot2, actualCarsCountFromLot2);
        }
    }
}
