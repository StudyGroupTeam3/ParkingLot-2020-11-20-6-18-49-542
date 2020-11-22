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
        public void Story5_AC1and2_Should_return_1car_from_Lot1_10cars_from_Lot2()
        {
            // given
            var superBoy = new SuperBoy(new List<Parkinglot>()
            {
                new Parkinglot(1, 10),
                new Parkinglot(2, 100),
            });
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
