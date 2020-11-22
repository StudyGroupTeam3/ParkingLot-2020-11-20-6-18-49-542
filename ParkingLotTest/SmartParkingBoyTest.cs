using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotTest
{
    using Xunit;
    using ParkingLot;

    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_always_park_cars_to_the_parking_lot_which_contains_more_empty_positions()
        {
            // given
            List<ParkingLot> parkingLotList = new List<ParkingLot> { new ParkingLot(0, 1), new ParkingLot(1, 2) };
            var smartParkingBoy = new SmartParkingBoy(parkingLotList);
            var expectedCar = new Car();
            // when
            var parkingTicket = smartParkingBoy.ParkCar(expectedCar, out string errorMessagePark1);
            // then
            Assert.True(parkingTicket.ParkingLotId == 1);
        }
    }
}
