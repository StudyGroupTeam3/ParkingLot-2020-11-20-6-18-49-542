using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;
using Xunit;

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
            var actual = boy.FetchCar("103");

            // then
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void Should_return_Unrecognized_parking_ticket_when_give_ticket_used()
        {
            // given
            var boy = new Boy();
            var car = new Car("BMW");

            // when
            boy.ParkCar(car);
            boy.FetchCar("001");

            var expected = "Unrecognized parking ticket";
            var actual = boy.FetchCar("001");

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
            while (count < 10)
            {
                boy.ParkCar(car);
                count++;
            }

            var expected = "Not enough position";
            var actual = boy.ParkCar(car);

            // then
            Assert.Equal(expected, actual);
        }
    }
}
