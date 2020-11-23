﻿using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;
using Xunit;

namespace ParkingLotTest
{
    public class Story4Test
    {
        [Fact]
        public void AC1and2_Should_return_6cars_from_Lot1_5car_from_Lot2()
        {
            // given
            var manager = new Manager();
            manager.AddParkingLot(new Parkinglot(10));
            manager.AddParkingLot(new Parkinglot(10));
            var smartBoy = new SmartBoy(1);
            manager.AddBoy(smartBoy);
            manager.DistributeParkingLots(smartBoy, manager.ParkingLots[0]);
            manager.DistributeParkingLots(smartBoy, manager.ParkingLots[1]);

            var car = new Car("BMW");
            var count = 0;

            // when
            while (count < 11)
            {
                smartBoy.ParkCar(car);
                count++;
            }

            var expectedCarsCountFromLot1 = 6;
            var actualCarsCountFromLot1 = smartBoy.ParkingLots[0].CarsCount;

            var expectedCarsCountFromLot2 = 5;
            var actualCarsCountFromLot2 = smartBoy.ParkingLots[1].CarsCount;

            // then
            Assert.Equal(expectedCarsCountFromLot1, actualCarsCountFromLot1);
            Assert.Equal(expectedCarsCountFromLot2, actualCarsCountFromLot2);
        }
    }
}
