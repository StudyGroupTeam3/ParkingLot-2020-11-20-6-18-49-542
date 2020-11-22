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
            var employee2 = new SmartParkingBoy("Joy");
            manager.HireBoy(employee);
            manager.HireBoy(employee2);
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

        [Theory]
        [InlineData("RJ_36528", "SuperPark: RJ_36528")]
        [InlineData("BJ_88888", "SuperPark: BJ_88888")]
        [InlineData("NY_34987713", "SuperPark: NY_34987713")]
        public void Should_Manager_Can_Tell_Boy_To_Fetch(string plateNumber, string parkingTicket)
        {
            //Given
            var manager = new ParkingManager("Chris");
            var employee = new ParkingBoy("Jack");
            var employee2 = new SmartParkingBoy("Joy");
            manager.HireBoy(employee);
            manager.HireBoy(employee2);
            string parkMessage = string.Empty;
            string fectchMessage = string.Empty;
            var fetchedCar = new Car(plateNumber);
            var ticket = parkingTicket;
            var parkingLots = new List<CarLot<string, Car>>()
            {
                new CarLot<string, Car>(),
            };
            manager.ManagerPark(fetchedCar, parkingLots, out parkMessage);
            Car expected = fetchedCar;

            //When
            var result = manager.ManagerFetch(ticket, parkingLots, out fectchMessage);

            //Then
            Assert.IsType<Car>(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("RJ_36528", "SuperPark: RJ_36528")]
        [InlineData("BJ_88888", "SuperPark: BJ_88888")]
        [InlineData("NY_34987713", "SuperPark: NY_34987713")]
        public void Should_Manager_Can_Park_To_His_Parkinglot(string plateNumber, string parkingTicket)
        {
            //Given
            var manager = new ParkingManager("Chris");
            string parkMessage = string.Empty;
            var car = new Car(plateNumber);

            string expected = parkingTicket;

            //When
            var result = manager.SelfPark(car, out parkMessage);

            //Then
            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("RJ_36528", "SuperPark: RJ_36528")]
        [InlineData("BJ_88888", "SuperPark: BJ_88888")]
        [InlineData("NY_34987713", "SuperPark: NY_34987713")]
        public void Should_Manager_Can_Fetch_From_Private_Lots(string plateNumber, string parkingTicket)
        {
            //Given
            var manager = new ParkingManager("Chris");
            string parkMessage = string.Empty;
            string fectchMessage = string.Empty;
            var fetchedCar = new Car(plateNumber);
            var ticket = parkingTicket;
            manager.SelfPark(fetchedCar, out parkMessage);
            Car expected = fetchedCar;

            //When
            var result = manager.SelfFetch(ticket, out fectchMessage);

            //Then
            Assert.IsType<Car>(result);
            Assert.Equal(expected, result);
        }
    }
}
