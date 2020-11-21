using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Should_generate_ParkingBoy()
        {
            // given
            var parkingBoy = new ParkingBoy();
            // then
            Assert.NotNull(parkingBoy);
        }

        [Fact]
        public void Should_return_ticket_when_parked_a_car()
        {
            // given
            var parkingBoy = new ParkingBoy();
            // when
            // then
            Assert.NotNull(parkingBoy);
        }
    }
}
