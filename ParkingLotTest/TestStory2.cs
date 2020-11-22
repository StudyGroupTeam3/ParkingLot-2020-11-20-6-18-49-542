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
            var parkingLots = new List<Dictionary<string, Car>>()
            {
                LotInitialize.FillLotWithCars(3),
            };
            var ticket = "SuperPark: 456213154";
            Car expectedCar = null;
            string expectedMessage = "Unrecognized parking ticket.";
            string actualMessage;

            //When
            var actualCar = boy.Fetch(ticket, parkingLots, out actualMessage);

            //Then
            Assert.Equal(expectedCar, actualCar);
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void Should_ParkingBoy_Return_Correct_Error_Message_Given_Used_Tickect()
        {
            //Given
            var boy = new ParkingBoy();
            var parkingLots = new List<Dictionary<string, Car>>()
            {
                LotInitialize.FillLotWithCars(3),
            };
            var ticket = "SuperPark: RJ_12784";
            boy.Fetch(ticket, parkingLots);
            Car expectedCar = null;
            string expectedMessage = "Unrecognized parking ticket.";
            string actualMessage;

            //When
            var actualCar = boy.Fetch(ticket, parkingLots, out actualMessage);

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
            var parkingLots = new List<Dictionary<string, Car>>()
            {
                LotInitialize.FillLotWithCars(3),
            };
            Car expectedCar = null;
            string expectedMessage = "Please provide your parking ticket.";
            string actualMessage;

            //When
            var actualCar = boy.Fetch(parkingLots, out actualMessage);

            //Then
            Assert.Equal(expectedCar, actualCar);
            Assert.Equal(expectedMessage, actualMessage);
        }
    }

    public class Story2AC3
    {
        [Fact]
        public void Should_ParkingBoy_Return_Correct_Error_Message_When_Parkinglot_Is_Full()
        {
            //Given
            var boy = new ParkingBoy();
            var parkingLots = new List<Dictionary<string, Car>>()
            {
                LotInitialize.FillLotWithCars(10),
            };
            string expectedMessage = "Not enough position.";
            string actualMessage;

            //When
            var result = boy.Park(new Car("BJ_54654"), parkingLots, out actualMessage);

            //Then
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}
