using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class Story5AC1
    {
        [Theory]

        [InlineData(3, 6, 20, 30)]
        [InlineData(3, 6, 10, 30)]
        [InlineData(3, 3, 10, 10)]
        public void Should_SuperSmartParkingBoy_Park_The_Car_To_The_Parkinglot_With_Higher_EmptyRate(int currentLotLoad1, int currentLotLoad2, int loadCapacity1, int loadCapacity2)
        {
            //Given
            var boy = new SuperSmartParkingBoy("Jack");
            var car = new Car("RJ_45675415");
            string message = string.Empty;
            var parkingLots = new List<CarLot<string, Car>>()
            {
                LotInitialize.FillLotWithCars(currentLotLoad1, loadCapacity1),
                LotInitialize.FillLotWithCars(currentLotLoad2, loadCapacity2),
            };
            var testCount = parkingLots[0].Count;
            var testCapacity = parkingLots[0].Capacity;
            string expectedTicket = "SuperPark: RJ_45675415";
            double minimumLoadRate = Math.Min(parkingLots[0].LoadRate, parkingLots[1].LoadRate);
            int targetIndex = 0;
            for (int index = 0; index < parkingLots.Count; index++)
            {
                if (parkingLots[index].LoadRate == Math.Min(parkingLots[0].LoadRate, parkingLots[1].LoadRate))
                {
                    targetIndex = index;
                    break;
                }
            }

            int expectedLoad = parkingLots[targetIndex].Count + 1;

            //When
            string actualTicket = boy.Park(car, parkingLots, out message);
            var actualLoad = parkingLots[targetIndex].Count;

            //Then
            Assert.Equal(expectedTicket, actualTicket);
            Assert.Equal(expectedLoad, actualLoad);
        }
    }
}
