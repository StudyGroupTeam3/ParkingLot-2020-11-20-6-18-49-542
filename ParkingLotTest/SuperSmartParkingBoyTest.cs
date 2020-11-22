using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotTest
{
    using Xunit;
    using ParkingLot;

    public class SuperSmartParkingBoyTest
    {
        [Fact]
        public void Should_always_park_cars_to_the_parking_lot_which_has_larger_available_position_rate()
        {
            // given
            List<ParkingLot> parkingLotList = new List<ParkingLot> { new ParkingLot(0, 5), new ParkingLot(1, 2) };
            var superSmartParkingBoy = new SuperSmartParkingBoy(parkingLotList);
            for (int i = 0; i < 3; i++)
            {
                parkingLotList[0].AddCar(new Car());
            }

            parkingLotList[1].AddCar(new Car());
            var expectedCar = new Car();
            // when
            var parkingTicket = superSmartParkingBoy.ParkCar(expectedCar, out string errorMessagePark1);
            // then
            Assert.True(parkingTicket.ParkingLotId == 1);
        }
    }
}
