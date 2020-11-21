using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;
using Xunit;

namespace ParkingLotTest
{
    public class Story1Test
    {
        [Fact]
        public void AC1_Should_return_ticket_when_park_car()
        {
            // given
            var boy = new Boy();
            var car = new Car("BWM");

            // when
            var expected = $"Brand: {car.Brand}\nTime: {DateTime.Now}";
            var actual = boy.ParkCar(car);

            // then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AC1_Should_return_car_when_give_ticket()
        {
            // given
            var boy = new Boy();
            var car = new Car("BWM");

            // when
            var ticket = boy.ParkCar(car);
            var expected = "BWM";
            var actual = boy.FetchCar(ticket);

            // then
            Assert.Equal(expected, actual);
        }
    }
}
