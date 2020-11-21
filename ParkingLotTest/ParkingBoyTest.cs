using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_generate_ParkingBoy()
        {
            // given
            var parkingBoy = new ParkingBoy(new ParkingLot(0));
            // then
            Assert.NotNull(parkingBoy);
        }

        [Fact]
        public void Should_park_car_when_given_a_car()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            // when
            parkingBoy.ParkingCar(car);
            var isCarParked = parkingLot.HasCar(car);

            // then
            Assert.True(isCarParked);
        }
    }
}
