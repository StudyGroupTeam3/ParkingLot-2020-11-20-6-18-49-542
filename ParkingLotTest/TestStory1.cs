using System.Collections.Generic;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class TestStory1
    {
        [Theory]
        [InlineData("RJ_36528", "SuperPark: RJ_36528")]
        [InlineData("BJ_88888", "SuperPark: BJ_88888")]
        [InlineData("NY_34987713", "SuperPark: NY_34987713")]
        public void Should_ParkingBoyPark_Return_Right_Ticket(string plateNumber, string parkingTicket)
        {
            //Given
            var boy = new ParkingBoy();
            var car = new Car(plateNumber);
            var parkingLot = new Dictionary<string, Car>();
            string expected = parkingTicket;

            //When
            string result = boy.Park(car, parkingLot);

            //Then
            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }
    }
}
