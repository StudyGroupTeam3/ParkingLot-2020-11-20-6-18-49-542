using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;
using Xunit;

namespace ParkingLotTest
{
    public class Story3Test
    {
        [Fact]
        public void AC1and2_Should_return_10cars_from_Lot1_1car_from_Lot2()
        {
            // given
            var boy = new Boy(1, new List<Parkinglot>()
            {
                new Parkinglot(1, 10),
                new Parkinglot(2, 10),
            });
            var car = new Car("BMW");
            var count = 0;

            // when
            while (count < 11)
            {
                boy.ParkCar(car);
                count++;
            }

            var expectedCarsCountFromLot1 = 10;
            var actualCarsCountFromLot1 = boy.ParkingLots[0].CarsCount;

            var expectedCarsCountFromLot2 = 1;
            var actualCarsCountFromLot2 = boy.ParkingLots[1].CarsCount;

            // then
            Assert.Equal(expectedCarsCountFromLot1, actualCarsCountFromLot1);
            Assert.Equal(expectedCarsCountFromLot2, actualCarsCountFromLot2);
        }
    }
}
