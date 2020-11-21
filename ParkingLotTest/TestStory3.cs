using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class Story3AC1
    {
        [Theory]
        [InlineData("RJ_36528", "SuperPark: RJ_36528")]
        public void Should_ParkingBoy_Park_The_Car_To_The_NextParkinglot_When_The_Current_Is_Full(string plateNumber, string parkingTicket)
        {
            //Given
            var boy = new ParkingBoy();
            var car = new Car(plateNumber);
            var parkingLots = new List<Dictionary<string, Car>>()
            {
                LotInitialize.FillLotWithTenCars(),
                LotInitialize.FillLotWithSomeCars(),
            };
            string expectedTicket = parkingTicket;
            int loadsOfSecondParkinglot = parkingLots[1].Count;
            int expectedLoadsOfFirstParkinglot = 10;
            int expectedLoadsOfSecondParkinglot = loadsOfSecondParkinglot + 1;

            //When
            string actualTicket = boy.Park(car, parkingLots);
            var actualLoadsOfFirstParkinglot = parkingLots[0].Count;
            var actualLoadsOfSecondParkinglot = parkingLots[1].Count;

            //Then
            Assert.Equal(expectedTicket, actualTicket);
            Assert.Equal(expectedLoadsOfFirstParkinglot, actualLoadsOfFirstParkinglot);
            Assert.Equal(expectedLoadsOfSecondParkinglot, actualLoadsOfSecondParkinglot);
        }

        //[Theory]
        //[InlineData("RJ_36528", "SuperPark: RJ_36528")]
        //public void Should_ParkingBoy_Park_The_Car_To_The_CurrentParkinglot_When_The_Current_IsNot_Full(string plateNumber, string parkingTicket)
        //{
        //    //Given
        //    var boy = new ParkingBoy();
        //    var car = new Car(plateNumber);
        //    var parkingLots = new List<Dictionary<string, Car>>()
        //    {
        //        LotInitialize.FillLotWithSomeCars(),
        //        LotInitialize.FillLotWithTenCars(),
        //    };
        //    int loadsOfFirstParkinglot = parkingLots[0].Count;
        //    string expectedTicket = parkingTicket;
        //    int expectedLoadsOfFirstParkinglot = loadsOfFirstParkinglot + 1;
        //    int expectedLoadsOfSecondParkinglot = 10;

        //    //When
        //    string actualTicket = boy.Park(car, parkingLots);
        //    var actualLoadsOfFirstParkinglot = parkingLots[0].Count;
        //    var actualLoadsOfSecondParkinglot = parkingLots[1].Count;

        //    //Then
        //    Assert.Equal(expectedTicket, actualTicket);
        //    Assert.Equal(expectedLoadsOfFirstParkinglot, actualLoadsOfFirstParkinglot);
        //    Assert.Equal(expectedLoadsOfSecondParkinglot, actualLoadsOfSecondParkinglot);
        //}

        //[Theory]
        //[InlineData("RJ_36528", "SuperPark: RJ_36528")]
        //public void Should_ParkingBoy_Return_Null_When_Both_Parkinglots_Are_Full(string plateNumber, string parkingTicket)
        //{
        //    //Given
        //    var boy = new ParkingBoy();
        //    var car = new Car(plateNumber);
        //    var parkingLots = new List<Dictionary<string, Car>>()
        //    {
        //        LotInitialize.FillLotWithTenCars(),
        //        LotInitialize.FillLotWithTenCars(),
        //    };
        //    int loadsOfFirstParkinglot = parkingLots[0].Count;
        //    string expectedTicket = parkingTicket;
        //    int expectedLoadsOfFirstParkinglot = loadsOfFirstParkinglot + 1;
        //    int expectedLoadsOfSecondParkinglot = 10;

        //    //When
        //    string actualTicket = boy.Park(car, parkingLots);
        //    var actualLoadsOfFirstParkinglot = parkingLots[0].Count;
        //    var actualLoadsOfSecondParkinglot = parkingLots[1].Count;

        //    //Then
        //    Assert.Equal(expectedTicket, actualTicket);
        //    Assert.Equal(expectedLoadsOfFirstParkinglot, actualLoadsOfFirstParkinglot);
        //    Assert.Equal(expectedLoadsOfSecondParkinglot, actualLoadsOfSecondParkinglot);
        //}
    }
}
