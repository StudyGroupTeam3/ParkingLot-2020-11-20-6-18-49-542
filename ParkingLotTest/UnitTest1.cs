namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        [Theory]
        [InlineData("carA")]
        public void ShouldReturnATicketGivenACar(string car)
        {
            // given
            string expected = "ticket-1-1";

            // when
            ParkingBoy parkingBoy = new ParkingBoy();
            string actual = parkingBoy.ParkingCar(car);

            // then
            Assert.Equal("ticket-1-1", actual);
        }

        [Theory]
        [InlineData("ticket-1-1")]
        public void ShouldReturnACarGivenATicket(string ticket)
        {
            // given
            string expected = "carA";

            // when
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.ParkingCar(expected);
            string actual = parkingBoy.FetchCar(ticket);

            // then
            Assert.Equal("carA", actual);
        }
    }
}
