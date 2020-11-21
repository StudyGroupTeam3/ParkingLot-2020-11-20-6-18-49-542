namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_generate_parkingLot()
        {
            var parkingLot = new ParkingLot(0);
            Assert.NotNull(parkingLot);
        }
    }
}
