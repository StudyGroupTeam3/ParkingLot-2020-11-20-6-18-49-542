namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class FakeParkingLot : ParkingLot
    {
        public FakeParkingLot(uint id) : base(id)
        {
        }
    }

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
