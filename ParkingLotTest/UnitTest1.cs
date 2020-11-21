using System;
using System.Collections.Generic;

namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        [Theory]
        [InlineData("carA")]
        public void ShouldReturnATicketGivenACar(string car)
        {
            // given
            string expected = "ticket-1-1";

            // when
            ParkingBoy parkingBoy = new ParkingBoy();
            string actual = parkingBoy.ParkingCar(car);

            // then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ticket-1-1")]
        public void ShouldReturnCarAGivenTicketOfCarA(string ticket)
        {
            // given
            string expected = "carA";

            // when
            ParkingBoy parkingBoy = new ParkingBoy();
            string carA = "carA";
            string carB = "carB";
            parkingBoy.ParkingCar(carA);
            parkingBoy.ParkingCar(carB);
            string actual = parkingBoy.FetchCar(ticket);

            // then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ticket-1-2")]
        public void ShouldReturnCarBGivenTicketOfCarB(string ticket)
        {
            // given
            string expected = "carB";

            // when
            ParkingBoy parkingBoy = new ParkingBoy();
            string carA = "carA";
            string carB = "carB";
            parkingBoy.ParkingCar(carA);
            parkingBoy.ParkingCar(carB);
            string actual = parkingBoy.FetchCar(ticket);

            // then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ticket-1-1")]
        public void ShouldReturnNoFetchedCarGivenUsedTicket(string ticket)
        {
            // given
            string expected = "Unrecognized parking ticket.";

            // when
            ParkingBoy parkingBoy = new ParkingBoy();
            string carA = "carA";
            string carB = "carB";
            parkingBoy.ParkingCar(carA);
            parkingBoy.ParkingCar(carB);
            parkingBoy.FetchCar(ticket);
            string actual = parkingBoy.FetchCar(ticket);

            // then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        public void ShouldHaveNoFetchedGivenNullTicket(string ticket)
        {
            // given
            string expected = "Please provide your parking ticket.";

            // when
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.ParkingCar(expected);
            string actual = parkingBoy.FetchCar(ticket);

            // then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ticket-1-2")]
        public void ShouldHaveNoFetchedGivenWrongTicket(string ticket)
        {
            // given
            string expected = "Unrecognized parking ticket.";

            // when
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.ParkingCar(expected);
            string actual = parkingBoy.FetchCar(ticket);

            // then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("car-11")]
        [InlineData("car-1")]
        [InlineData("")]
        public void ShouldHaveNoTicketWhenPositionIsFull(string car)
        {
            // given
            string expected = "Not enough position.";
            // when
            List<string> cars = new List<string>()
            {
                "car-1", "car-2", "car-3", "car-4", "car-5",
                "car-6", "car-7", "car-8", "car-9", "car-10",
            };
            ParkingBoy parkingBoy = new ParkingBoy();
            for (int i = 0; i < cars.Count; i++)
            {
                parkingBoy.ParkingCar(cars[i]);
            }

            string actual = parkingBoy.ParkingCar(car);
            // then
            Assert.Equal(expected, actual);
        }
    }
}
