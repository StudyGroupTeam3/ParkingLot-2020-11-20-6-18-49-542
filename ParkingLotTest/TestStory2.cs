using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class Story2AC1
    {
        [Fact]
        public void Should_ParkingBoy_Return_Correct_Error_Message_Given_Wrong_Tickect()
        {
            //Given
            var boy = new ParkingBoy();
            Dictionary<string, Car> parkingLot = LotInitialize.FillLotWithSomeCars();
            var ticket = "SuperPark: 456213154";
            Car expectedCar = null;
            string expectedMessage = "Unrecognized parking ticket.";
            string actualMessage;

            //When
            var actualCar = boy.Fetch(ticket, parkingLot, out actualMessage);

            //Then
            Assert.Equal(expectedCar, actualCar);
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void Should_ParkingBoy_Return_Correct_Error_Message_Given_Used_Tickect()
        {
            //Given
            var boy = new ParkingBoy();
            Dictionary<string, Car> parkingLot = LotInitialize.FillLotWithSomeCars();
            var ticket = "SuperPark: RJ_12784";
            boy.Fetch(ticket, parkingLot);
            Car expectedCar = null;
            string expectedMessage = "Unrecognized parking ticket.";
            string actualMessage;

            //When
            var actualCar = boy.Fetch(ticket, parkingLot, out actualMessage);

            //Then
            Assert.Equal(expectedCar, actualCar);
            Assert.Equal(expectedMessage, actualMessage);
        }
    }

    public class Story2AC2
    {
        [Fact]
        public void Should_ParkingBoy_Return_Correct_Error_Message_Given_No_Tickect()
        {
            //Given
            var boy = new ParkingBoy();
            Dictionary<string, Car> parkingLot = LotInitialize.FillLotWithSomeCars();
            Car expectedCar = null;
            string expectedMessage = "Please provide your parking ticket.";
            string actualMessage;

            //When
            var actualCar = boy.Fetch(parkingLot, out actualMessage);

            //Then
            Assert.Equal(expectedCar, actualCar);
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}
