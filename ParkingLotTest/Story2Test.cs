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
        public void AC1_Should_return_Unrecognized_parking_ticket_when_give_wrong_ticket()
        {
            // given
            var boy = new Boy(1);
            boy.AddParkingLot(new Parkinglot(10));

            // when
            var expected = "Unrecognized parking ticket";
            var actual = boy.FetchCar("0101103");

            // then
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void AC1_Should_return_Unrecognized_parking_ticket_when_give_ticket_used()
        {
            // given
            var boy = new Boy(1);
            boy.AddParkingLot(new Parkinglot(10));
            var car1 = new Car("BMW");
            var car2 = new Car("BMW");

            // when
            boy.ParkCar(car1);
            boy.FetchCar("0101001");
            boy.ParkCar(car2);

            var expected = "Unrecognized parking ticket";
            var actual = boy.FetchCar("0101001");

            // then
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void AC2_Should_return_Please_provide_your_parking_ticket_when_give_null()
        {
            // given
            var boy = new Boy(1);
            boy.AddParkingLot(new Parkinglot(10));
            var car = new Car("BMW");

            // when
            boy.ParkCar(car);

            var expected = "Please provide your parking ticket";
            var actual = boy.FetchCar(null);

            // then
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void AC3_Should_return_Not_enough_Position_parking_when_park_car_into_parking_lot_without_position()
        {
            // given
            var boy = new Boy(1);
            boy.AddParkingLot(new Parkinglot(10));
            boy.AddParkingLot(new Parkinglot(10));
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
    }
}
