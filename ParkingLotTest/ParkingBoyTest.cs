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
            parkingBoy.ParkCar(car);
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
            var parkingTicket = parkingBoy.ParkCar(car);
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
            var parkingTicket = parkingBoy.ParkCar(car);
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
            var parkingTicket = parkingBoy.ParkCar(expectedCar);
            // when
            var actualCar = parkingBoy.FetchCar(parkingTicket);
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
            var parkingTicket = parkingBoy.ParkCar(expectedCar);
            parkingBoy.ParkCar(anotherCar);
            // when
            var actualCar = parkingBoy.FetchCar(parkingTicket);
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
            var parkingTicket = parkingBoy.ParkCar(car);
            // when
            var actualCar = parkingBoy.FetchCar(new ParkingTicket(parkingTicket.ParkingLotId, parkingTicket.CarId + 1));
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
            var parkingTicket = parkingBoy.ParkCar(car);
            // when
            var actualCar = parkingBoy.FetchCar(null);
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
            var parkingTicket = parkingBoy.ParkCar(car);
            parkingBoy.FetchCar(parkingTicket);
            // when
            var actualCar = parkingBoy.FetchCar(parkingTicket);
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
            var parkingTicket = parkingBoy.ParkCar(car);
            // when
            var anotherCar = new Car();
            var newParkingTicket = parkingBoy.ParkCar(anotherCar);
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
            var parkingTicket = parkingBoy.ParkCar(null);
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
            var parkingTicket = parkingBoy.ParkCar(car);
            // when
            var newParkingTicket = parkingBoy.ParkCar(car);
            // then
            Assert.Null(newParkingTicket);
        }
    }
}
