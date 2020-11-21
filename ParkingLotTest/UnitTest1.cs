namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnATiketGiveACustomer()
        {
            // given
            string expected = "1-1";

            // when
            ParkingBoy parkingBoy = new ParkingBoy();
            string actual = parkingBoy.GiveTickets();

            // then
            Assert.Equal("1-1", actual);
        }
    }
}
