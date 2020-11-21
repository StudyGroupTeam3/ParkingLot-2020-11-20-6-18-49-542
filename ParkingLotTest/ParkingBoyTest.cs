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

            var mockSecretGenerator = new Mock<ParkingLot>();

            // when
            var parkingTicket = parkingBoy.Park(car, parkingLot);

            // then
            Assert.IsType<ParkingTicket>(parkingTicket);
        }
    }
}
