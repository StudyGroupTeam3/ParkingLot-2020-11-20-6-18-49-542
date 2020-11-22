using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class Story4AC1
    {
        [Theory]
        [InlineData(2, 8)]
        [InlineData(8, 2)]
        [InlineData(3, 6)]
        [InlineData(5, 5)]
        public void Should_SmartParkingBoy_Park_The_Car_To_The_Parkinglot_With_More_Empty_Positions(int currentLoadforPark1, int currentLoadforPark2)
        {
            //Given
            var boy = new SmartParkingBoy();
            var car = new Car("RJ_45675415");
            string message = string.Empty;
            var parkingLots = new List<CarLot<string, Car>>()
            {
                LotInitialize.FillLotWithCars(currentLoadforPark1),
                LotInitialize.FillLotWithCars(currentLoadforPark2),
            };
            string expectedTicket = "SuperPark: RJ_45675415";
            int minimumIndex = 0;
            for (int index = 0; index < parkingLots.Count; index++)
            {
                if (parkingLots[index].Count == Math.Min(currentLoadforPark1, currentLoadforPark2))
                {
                    minimumIndex = index;
                    break;
                }
            }

            int expectedLoad = Math.Min(currentLoadforPark1, currentLoadforPark2) + 1;

            //When
            string actualTicket = boy.Park(car, parkingLots, out message);
            var actualLoad = parkingLots[minimumIndex].Count;

            //Then
            Assert.Equal(expectedTicket, actualTicket);
            Assert.Equal(expectedLoad, actualLoad);
        }
    }
}
