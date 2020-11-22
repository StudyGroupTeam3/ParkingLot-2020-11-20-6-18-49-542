using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class Story6AC1
    {
        [Fact]
        public void Should_Manager_Can_Add_Boy_To_List()
        {
            //Given
            var manager = new ParkingManager("Jack");
            var boy = new ParkingBoy("Joy");

            //When
            manager.HireBoy(boy);
            bool result = manager.ManageList.Contains(boy);

            //Then
            Assert.Equal(true, result);
        }

        [Theory]
        [InlineData("RJ_36528", "SuperPark: RJ_36528")]
        [InlineData("BJ_88888", "SuperPark: BJ_88888")]
        [InlineData("NY_34987713", "SuperPark: NY_34987713")]
        public void Should_Manager_Can_Tell_Boy_To_Park(string plateNumber, string parkingTicket)
        {
            //Given
            var manager = new ParkingManager("Chris");
            var employee = new ParkingBoy("Jack");
            manager.HireBoy(employee);
            string parkMessage = string.Empty;
            var car = new Car(plateNumber);
            var parkingLots = new List<CarLot<string, Car>>()
            {
                LotInitialize.FillLotWithCars(10, 20),
                LotInitialize.FillLotWithCars(8, 30),
            };

            string expected = parkingTicket;

            //When
            var result = manager.ManagerPark(car, parkingLots, out parkMessage);

            //Then
            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }
    }
}
