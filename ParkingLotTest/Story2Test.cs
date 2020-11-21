using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;
using Xunit;
using Xunit.Sdk;

namespace ParkingLotTest
{
    public class Story2Test
    {
        [Fact]
        public void Should_return_Unrecognized_parking_ticket_when_give_wrong_ticket()
        {
            // given
            var boy = new Boy();

            // when]
            var expected = "Unrecognized parking ticket";
            var actual = boy.FetchCar("01103");

            // then
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void Should_return_Unrecognized_parking_ticket_when_give_ticket_used()
        {
            // given
            var boy = new Boy();
            var car1 = new Car("BMW");
            var car2 = new Car("BMW");

            // when
            boy.ParkCar(car1);
            boy.FetchCar("01001");
            boy.ParkCar(car2);

            var expected = "Unrecognized parking ticket";
            var actual = boy.FetchCar("01001");

            // then
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void Should_return_Please_provide_your_parking_ticket_when_give_null()
        {
            // given
            var boy = new Boy();
            var car = new Car("BMW");

            // when
            boy.ParkCar(car);

            var expected = "Please provide your parking ticket";
            var actual = boy.FetchCar(null);

            // then
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void Should_return_Not_enough_Position_parking_when_park_car_into_parking_lot_without_position()
        {
            // given
            var boy = new Boy();
            var car = new Car("BMW");
            var count = 0;

            // when
            while (count < 20)
            {
                boy.ParkCar(car);
                count++;
            }

            var expected = "Not enough position";
            var actual = boy.ParkCar(car);

            // then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_return_10cars_from_Lot1_1car_from_Lot2()
        {
            // given
            var boy = new Boy();
            var car = new Car("BMW");
            var count = 0;

            // when
            while (count < 11)
            {
                boy.ParkCar(car);
                count++;
            }

            var expectedCarsCountFromLot1 = 10;
            var actualCarsCountFromLot1 = boy.ParkingLots[0].CarsCount;

            var expectedCarsCountFromLot2 = 1;
            var actualCarsCountFromLot2 = boy.ParkingLots[1].CarsCount;

            // then
            Assert.Equal(expectedCarsCountFromLot1, actualCarsCountFromLot1);
            Assert.Equal(expectedCarsCountFromLot2, actualCarsCountFromLot2);
        }
    }
}
