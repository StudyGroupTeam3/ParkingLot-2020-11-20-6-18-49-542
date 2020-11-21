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
            parkingBoy.ParCar(car);
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
            var parkingTicket = parkingBoy.ParCar(car);
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
            var parkingTicket = parkingBoy.ParCar(car);
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
            var parkingTicket = parkingBoy.ParCar(expectedCar);
            // when
            var actualCar = parkingBoy.FetchCar(parkingTicket);
            // then
            Assert.Equal(expectedCar, actualCar);
        }
    }
}
