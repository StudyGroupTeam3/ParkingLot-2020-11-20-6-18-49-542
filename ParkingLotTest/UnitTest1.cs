using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void ShouldParkACarGivenACar()
        {
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car car = new Car("CARA111");
            // given
            string expected = car.GetCarNumber();

            // when
            string actual = parkingBoy.ParkingCar(car).GetCarNumber();

            // then
            Assert.Equal(expected, actual);
        }
    }
}
