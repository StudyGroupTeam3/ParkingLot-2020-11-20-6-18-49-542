using System;

namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_Park_Return_ParkingTicket_When_Has_Position()
        {
            // given
            var car = new Car("JAA8888");
            var parkingLot = new ParkingLot("ParkingLotOne");

            // when
            var parkingTicket = parkingLot.Park(car);

            // then
            Assert.IsType<ParkingTicket>(parkingTicket);
            Assert.NotNull(parkingTicket);
        }

        [Fact]
        public void Should_Park_Return_Null_When_Has_No_Position()
        {
            // given
            var parkingLot = new ParkingLot("ParkingLotOne");
            for (int i = 0; i < 10; i++)
            {
                var car = new Car($"JAA{i}");
                parkingLot.Park(car);
            }

            // when
            var parkingTicket = parkingLot.Park(new Car("JA8888"));

            // then
            Assert.Null(parkingTicket);
        }

        [Fact]
        public void Should_Fetch_Return_Car_Given_Valid_Ticket()
        {
            // given
            var parkingLot = new ParkingLot("ParkingLotOne");
            var parkedCar = new Car("JA8888");
            ParkingTicket parkingTicket = parkingLot.Park(parkedCar);

            // when
            var fetchedCar = parkingLot.Fetch(parkingTicket);

            // then
            Assert.IsType<Car>(fetchedCar);
            Assert.Equal(parkedCar, fetchedCar);
        }
    }
}
