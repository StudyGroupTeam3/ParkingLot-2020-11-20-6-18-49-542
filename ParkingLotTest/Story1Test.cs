using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using ParkingLot.Models;
using Xunit;

namespace ParkingLotTest
{
    public class Story1Test
    {
        [Fact]
        public void Story1_AC1_Should_return_ticket_when_park_car()
        {
            // given
            var boy = new Boy();
            var car = new Car("BWM");

            // when
            var expected = "001";
            var actual = boy.ParkCar(car);

            // then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Story1_AC1_Should_return_car_when_give_ticket()
        {
            // given
            var boy = new Boy();
            var car = new Car("BWM");

            // when
            var ticket = boy.ParkCar(car);
            var expected = "BWM";
            var actual = boy.FetchCar(ticket);

            // then
            Assert.Equal(expected, actual.Brand);
        }

        [Fact]
        public void Story1_AC2_Should_park_multiple_cars_fetch_right_car_by_ticket()
        {
            // given
            var boy = new Boy();
            var car1 = new Car("BWM");
            var car2 = new Car("Benz");
            var car3 = new Car("Porsche");

            // when
            var ticket1 = boy.ParkCar(car1);
            var ticket2 = boy.ParkCar(car2);
            var ticket3 = boy.ParkCar(car3);

            var expected1 = "BWM";
            var actual1 = boy.FetchCar(ticket1);

            var expected2 = "Benz";
            var actual2 = boy.FetchCar(ticket3);

            var expected3CountOfCars = 3;
            var actual3CountOfCars = boy.GetCarsCount();

            // then
            Assert.Equal(expected1, actual1.Brand);
            Assert.NotEqual(expected2, actual2.Brand);
            Assert.Equal(expected3CountOfCars, actual3CountOfCars);
        }

        [Fact]
        public void Story1_AC3_Should_fetch_wrong_when_given_wrong_ticket()
        {
            // given
            var boy = new Boy();
            var car = new Car("BWM");

            // when
            boy.ParkCar(car);

            Car expected = null;
            var actual = boy.FetchCar("wrong ticket");

            // then
            Assert.Equal(expected, actual);
        }
    }
}
