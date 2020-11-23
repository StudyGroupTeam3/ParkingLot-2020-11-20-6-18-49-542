using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void ShouldParkACarAddACarInParkingLot()
        {
            // given
            string expected = "CARA111";

            // when
            string positionErrorMessage;
            Car car = new Car("CARA111");
            ParkingLot parkingLot1 = new ParkingLot("A");
            ParkingLot parkingLot2 = new ParkingLot("B");
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(parkingLot1);
            parkingLots.Add(parkingLot2);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            string actual = parkingBoy.ParkingCar(car, out positionErrorMessage).CarId;

            // then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldFetchACarUsingParkingTicket()
        {
            // given
            Car car = new Car("CARA111");

            // when
            string positionErrorMessage, errorMessage;
            ParkingLot parkingLot1 = new ParkingLot("A");
            ParkingLot parkingLot2 = new ParkingLot("B");
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(parkingLot1);
            parkingLots.Add(parkingLot2);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            ParkingTicket parkingTicket = parkingBoy.ParkingCar(car, out positionErrorMessage);
            Car actual = parkingBoy.FetchCar(parkingTicket, out errorMessage);

            // then
            Assert.Equal(car, actual);
        }

        [Fact]
        public void ShouldFetchACarUsingCorrespondingParkingTicket()
        {
            // given
            Car car1 = new Car("CARA111");
            Car car2 = new Car("CARA112");

            // when
            string errorMessage, positionErrorMessage1, positionErrorMessage2;
            ParkingLot parkingLot1 = new ParkingLot("A");
            ParkingLot parkingLot2 = new ParkingLot("B");
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(parkingLot1);
            parkingLots.Add(parkingLot2);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            ParkingTicket parkingTicket1 = parkingBoy.ParkingCar(car1, out positionErrorMessage1);
            ParkingTicket parkingTicket2 = parkingBoy.ParkingCar(car2, out positionErrorMessage2);
            Car actual = parkingBoy.FetchCar(parkingTicket2, out errorMessage);

            // then
            Assert.Equal(car2, actual);
        }

        [Fact]
        public void ShouldGiveErrorMessageWhenTicketIsNull()
        {
            // given
            Car car = new Car("CARA111");

            // when
            string errorMessage, positionErrorMessage;
            ParkingLot parkingLot1 = new ParkingLot("A");
            ParkingLot parkingLot2 = new ParkingLot("B");
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(parkingLot1);
            parkingLots.Add(parkingLot2);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            ParkingTicket parkingTicket = parkingBoy.ParkingCar(car, out positionErrorMessage);
            Car actual = parkingBoy.FetchCar(null, out errorMessage);

            // then
            Assert.Equal("Please provide your parking ticket.", errorMessage);
        }

/*
        [Fact]
        public void ShouldGiveErrorMessageWhenTicketIsUsed()
        //ShouldGiveErrorMessageWhenGiveWrongTicket()
        {
            // given
            Car car1 = new Car("CARA111");
            Car car2 = new Car("CARA112");

            // when
            string errorMessage1, errorMessage2;
            ParkingBoy parkingBoy = new ParkingBoy();
            ParkingTicket parkingTicket1 = parkingBoy.ParkingCar(car1);
            ParkingTicket parkingTicket2 = parkingBoy.ParkingCar(car2);
            parkingBoy.FetchCar(parkingTicket1, out errorMessage1);
            parkingBoy.FetchCar(parkingTicket1, out errorMessage2);

            // then
            Assert.Equal("Unrecognized parking ticket.", errorMessage2);
        }
*/
    }
}