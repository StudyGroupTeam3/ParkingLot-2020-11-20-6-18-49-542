using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class FakeParkingLot : ParkingLot
    {
        public FakeParkingLot(uint id) : base(id)
        {
        }

        public bool HasCar(ICar car)
        {
            return this.ParkingLotPlaces.Where(idCarPair => idCarPair.Value.Equals(car)).ToList().Count == 1;
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

        [Fact]
        public void Should_add_car_into_parkingLotPlaces_when_AddCar()
        {
            // given
            var fakeParkingLot = new FakeParkingLot(0);
            var car = new Car();
            // when
            fakeParkingLot.AddCar(car);
            var isCarAdded = fakeParkingLot.HasCar(car);
            // then
            Assert.True(isCarAdded);
        }
    }
}
