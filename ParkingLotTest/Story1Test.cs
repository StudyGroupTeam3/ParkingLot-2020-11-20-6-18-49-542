using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using ParkingLot.Models;
using Xunit;

namespace ParkingLotTest
{
    public class Story1Test : IDisposable
    {
        private readonly List<Parkinglot> parkingLots;
        private readonly Boy boy;

        public Story1Test()
        {
            parkingLots = new List<Parkinglot>
            {
                new Parkinglot(1, 10),
            };

            boy = new Boy(parkingLots);
        }

        public void Dispose()
        {
        }

        [Fact]
        public void AC1_Should_return_ticket_when_park_car()
        {
            // given
            var car = new Car("BMW");

            // when
            var expected = "01001";
            var actual = boy.ParkCar(car);

            // then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AC1_Should_return_car_when_give_ticket()
        {
            // given
            var car = new Car("BMW");

            // when
            var ticket = boy.ParkCar(car);
            var expected = "BMW";
            var actual = boy.FetchCar(ticket);

            // then
            Assert.Equal(expected, actual.Brand);
        }

        [Fact]
        public void AC2_Should_park_multiple_cars()
        {
            // given
            var car1 = new Car("BMW");
            var car2 = new Car("Benz");
            var car3 = new Car("Porsche");

            // when
            boy.ParkCar(car1);
            boy.ParkCar(car2);
            boy.ParkCar(car3);

            var expected = 3;
            var actual = boy.GetCarsCount();

            // then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AC2_Should_fetch_right_car_by_ticket()
        {
            // given
            var car1 = new Car("BMW");
            var car2 = new Car("Benz");
            var car3 = new Car("Porsche");

            // when
            var ticket1 = boy.ParkCar(car1);
            var ticket2 = boy.ParkCar(car2);
            var ticket3 = boy.ParkCar(car3);

            var expected1 = "BMW";
            var actual1 = boy.FetchCar(ticket1);

            var expected2 = "Benz";
            var actual2 = boy.FetchCar(ticket3);

            // then
            Assert.Equal(expected1, actual1.Brand);
            Assert.NotEqual(expected2, actual2.Brand);
        }

        [Fact]
        public void AC3_Should_fetch_null_when_given_wrong_ticket()
        {
            // given
            var car = new Car("BMW");

            // when
            boy.ParkCar(car);

            var expected = "Unrecognized parking ticket";
            var actual = boy.FetchCar("01050");

            // then
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void AC4_Should_fetch_null_when_given_used_ticket()
        {
            // given
            var car = new Car("BMW");

            // when
            var ticket = boy.ParkCar(car);
            boy.FetchCar(ticket);

            var expected = "Unrecognized parking ticket";
            var actual = boy.FetchCar(ticket);

            // then
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void AC5_Should_not_get_ticket_when_no_position()
        {
            // given
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
        public void Case_plus_Should_return_wrong_when_park_null()
        {
            // given

            // when
            var expected = "wrong car";
            var actual = boy.ParkCar(null);

            // then
            Assert.Equal(expected, actual);
        }
    }
}
