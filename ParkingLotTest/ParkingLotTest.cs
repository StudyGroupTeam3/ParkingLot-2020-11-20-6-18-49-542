namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_generate_ParkingLot()
        {
            // given
            var parkingLot = new ParkingLot(0);
            // then
            Assert.NotNull(parkingLot);
        }
    }
}
