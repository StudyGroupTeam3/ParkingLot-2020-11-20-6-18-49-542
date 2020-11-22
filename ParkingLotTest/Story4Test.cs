using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;
using Xunit;

namespace ParkingLotTest
{
    public class Story4Test
    {
        [Fact]
        public void AC1and2_Should_return_6cars_from_Lot1_5car_from_Lot2()
        {
            // given
            var smartBoy = new SmartBoy(1, new List<Parkinglot>()
            {
                new Parkinglot(1, 10),
                new Parkinglot(2, 10),
            });
            var car = new Car("BMW");
            var count = 0;

            // when
            while (count < 11)
            {
                smartBoy.ParkCar(car);
                count++;
            }

            var expectedCarsCountFromLot1 = 6;
            var actualCarsCountFromLot1 = smartBoy.ParkingLots[0].CarsCount;

            var expectedCarsCountFromLot2 = 5;
            var actualCarsCountFromLot2 = smartBoy.ParkingLots[1].CarsCount;

            // then
            Assert.Equal(expectedCarsCountFromLot1, actualCarsCountFromLot1);
            Assert.Equal(expectedCarsCountFromLot2, actualCarsCountFromLot2);
        }
    }
}
