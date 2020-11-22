using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_generate_ParkingBoy()
        {
            // given
            var parkingBoy = new ParkingBoy(new ParkingLot(0));
            // then
            Assert.NotNull(parkingBoy);
        }

        [Fact]
        public void Should_park_car_when_given_a_car()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            // when
            parkingBoy.ParkCar(car, out string errorMessage);
            var isCarParked = parkingLot.HasCar(car);

            // then
            Assert.True(isCarParked);
        }

        [Fact]
        public void Should_return_parking_ticket_when_parked_a_car()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            // when
            var parkingTicket = parkingBoy.ParkCar(car, out string errorMessage);
            // then
            Assert.NotNull(parkingTicket);
        }

        [Fact]
        public void Should_return_correct_parking_ticket_when_parked_a_car()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            // when
            var parkingTicket = parkingBoy.ParkCar(car, out string errorMessage);
            bool isParkingTicketCorrect = parkingTicket.ParkingLotId == 0 && parkingTicket.CarId == 0;
            // then
            Assert.True(isParkingTicketCorrect);
        }

        [Fact]
        public void Should_return_the_car_when_use_correct_parking_ticket_to_fetch_the_car()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var expectedCar = new Car();
            var parkingTicket = parkingBoy.ParkCar(expectedCar, out string errorMessagePark);
            // when
            var actualCar = parkingBoy.FetchCar(parkingTicket, out string errorMessage);
            // then
            Assert.Equal(expectedCar, actualCar);
        }

        [Fact]
        public void Should_get_the_right_car_when_add_multiple_cars()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var expectedCar = new Car();
            var anotherCar = new Car();
            var parkingTicket = parkingBoy.ParkCar(expectedCar, out string errorMessagePark1);
            parkingBoy.ParkCar(anotherCar, out string errorMessagePark2);
            // when
            var actualCar = parkingBoy.FetchCar(parkingTicket, out string errorMessage);
            var isFetchedTheRightCar = expectedCar.Equals(actualCar) && !anotherCar.Equals(actualCar);
            // then
            Assert.True(isFetchedTheRightCar);
        }

        [Fact]
        public void Should_return_null_when_given_not_provided_ticket_to_fetch_car()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var parkingTicket = parkingBoy.ParkCar(car, out string errorMessagePark);
            // when
            var actualCar = parkingBoy.FetchCar(new ParkingTicket(parkingTicket.ParkingLotId, parkingTicket.CarId + 1), out string errorMessage);
            // then
            Assert.Null(actualCar);
        }

        [Fact]
        public void Should_return_null_when_not_given_a_parking_ticket_to_fetch_car()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var parkingTicket = parkingBoy.ParkCar(car, out string errorMessagePark);
            // when
            var actualCar = parkingBoy.FetchCar(null, out string errorMessage);
            // then
            Assert.Null(actualCar);
        }

        [Fact]
        public void Should_return_null_when_use_a_used_parking_ticket_to_fetch_a_car()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var parkingTicket = parkingBoy.ParkCar(car, out string errorMessage);
            parkingBoy.FetchCar(parkingTicket, out string errorMessage1);
            // when
            var actualCar = parkingBoy.FetchCar(parkingTicket, out string errorMessage2);
            // then
            Assert.Null(actualCar);
        }

        [Fact]
        public void Should_return_no_ticket_when_try_to_park_a_car_when_there_is_no_position_in_parking_lot()
        {
            // given
            var parkingLot = new ParkingLot(0, 1);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var parkingTicket = parkingBoy.ParkCar(car, out string errorMessage1);
            // when
            var anotherCar = new Car();
            var newParkingTicket = parkingBoy.ParkCar(anotherCar, out string errorMessage2);
            // then
            Assert.Null(newParkingTicket);
        }

        [Fact]
        public void Should_return_no_ticket_when_passing_a_null_car()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            // when
            var parkingTicket = parkingBoy.ParkCar(null, out string errorMessage);
            // then
            Assert.Null(parkingTicket);
        }

        [Fact]
        public void Should_return_no_ticket_when_passing_a_parked_car()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var parkingTicket = parkingBoy.ParkCar(car, out string errorMessagePark1);
            // when
            var newParkingTicket = parkingBoy.ParkCar(car, out string errorMessagePark2);
            // then
            Assert.Null(newParkingTicket);
        }

        [Fact]
        public void Should_return_no_car_and_generate_error_message_Unrecognized_parking_ticket_when_parking_boy_does_not_provide_the_ticket()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var parkingTicket = parkingBoy.ParkCar(car, out string errorMessagePark);
            // when
            string errorMessage;
            var actualCar = parkingBoy.FetchCar(new ParkingTicket(parkingTicket.ParkingLotId, parkingTicket.CarId + 1), out errorMessage);
            // then
            Assert.Null(actualCar);
            Assert.Equal("Unrecognized parking ticket.", errorMessage);
        }

        [Fact]
        public void Should_return_no_car_and_generate_error_message_Unrecognized_parking_ticket_when_customer_provide_a_used_ticket()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var parkingTicket = parkingBoy.ParkCar(car, out string errorMessagePark);
            parkingBoy.FetchCar(parkingTicket, out string errorMessage1);
            // when
            string errorMessage;
            var actualCar = parkingBoy.FetchCar(parkingTicket, out errorMessage);
            // then
            Assert.Null(actualCar);
            Assert.Equal("Unrecognized parking ticket.", errorMessage);
        }

        [Fact]
        public void Should_return_no_car_and_generate_error_message_Please_provide_your_parking_ticket_when_customer_does_not_provide_a_ticket()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var parkingTicket = parkingBoy.ParkCar(car, out string errorMessagePark);
            // when
            string errorMessage;
            var actualCar = parkingBoy.FetchCar(null, out errorMessage);
            // then
            Assert.Null(actualCar);
            Assert.Equal("Please provide your parking ticket.", errorMessage);
        }

        [Fact]
        public void Should_return_no_parking_ticket_and_generate_error_message_Not_enough_position_when_the_parking_boy_attempt_to_park_into_a_parking_lot_without_position()
        {
            // given
            var parkingLot = new ParkingLot(0, 0);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            // when
            string errorMessage;
            var parkingTicket = parkingBoy.ParkCar(car, out errorMessage);
            // then
            Assert.Null(parkingTicket);
            Assert.Equal("Not enough position.", errorMessage);
        }
    }
}
