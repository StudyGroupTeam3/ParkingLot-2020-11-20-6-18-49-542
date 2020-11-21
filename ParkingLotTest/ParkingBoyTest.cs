using System;

namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_Park_Return_ParkingTicket_When_Park_To_Available_ParkingLot()
        {
            // given
            var car = new Car("JAA8888");
            var parkingBoy = new ParkingBoy("Jack");
            var parkingLot = new ParkingLot("ParkingLotOne");

            // when
            var parkingTicket = parkingBoy.Park(car, parkingLot);

            // then
            Assert.IsType<ParkingTicket>(parkingTicket);
        }

        [Fact]
        public void Should_Fetch_Return_Car_With_Valid_ParkingTicket()
        {
            // given
            // given
            var parkedCar = new Car("JAA8888");
            var parkingBoy = new ParkingBoy("Jack");
            var parkingLot = new ParkingLot("ParkingLotOne");
            var parkingTicket = parkingBoy.Park(parkedCar, parkingLot);

            // when
            var fetchedCar = parkingBoy.Fetch(parkingTicket, parkingLot);

            // then
            Assert.IsType<Car>(fetchedCar);
            //Assert.Equal(fetchedCar, parkedCar);
        }
    }
}
