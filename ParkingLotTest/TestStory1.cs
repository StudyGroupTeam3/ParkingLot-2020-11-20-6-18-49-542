using System.Collections.Generic;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class AC1
    {
        [Theory]
        [InlineData("RJ_36528", "SuperPark: RJ_36528")]
        [InlineData("BJ_88888", "SuperPark: BJ_88888")]
        [InlineData("NY_34987713", "SuperPark: NY_34987713")]
        public void Should_ParkingBoyPark_Return_Right_Ticket(string plateNumber, string parkingTicket)
        {
            //Given
            var boy = new ParkingBoy();
            var car = new Car(plateNumber);
            var parkingLot = new Dictionary<string, Car>();
            string expected = parkingTicket;

            //When
            string result = boy.Park(car, parkingLot);

            //Then
            Assert.IsType<string>(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("RJ_36528", "SuperPark: RJ_36528")]
        [InlineData("BJ_88888", "SuperPark: BJ_88888")]
        [InlineData("NY_34987713", "SuperPark: NY_34987713")]
        public void Should_ParkingBoyFetch_Return_Right_Car(string plateNumber, string parkingTicket)
        {
            //Given
            var boy = new ParkingBoy();
            var fetchedCar = new Car(plateNumber);
            var ticket = parkingTicket;
            var parkingLot = new Dictionary<string, Car>();
            boy.Park(fetchedCar, parkingLot);
            Car expected = fetchedCar;

            //When
            var result = boy.Fetch(ticket, parkingLot);

            //Then
            Assert.IsType<Car>(result);
            Assert.Equal(expected, result);
        }
    }

    public class AC2
    {
        [Fact]
        public void Should_ParkingBoyFecth_Return_Right_Car()
        {
            //Given
            var boy = new ParkingBoy();
            var cars = CarsFactory.LoadAllCars();
            var parkingLot = new Dictionary<string, Car>();
            foreach (Car car in cars)
            {
                boy.Park(car, parkingLot);
            }

            var ticket = "SuperPark: RJ_12784";
            Car expected = cars[0];

            //When
            var result = boy.Fetch(ticket, parkingLot);

            //Then
            Assert.Equal(expected, result);
        }
    }

    public class AC3
    {
        [Fact]
        public void Should_ParkingBoyFecth_Return_No_Car_Given_Wrong_Tickect()
        {
            //Given
            var boy = new ParkingBoy();
            var cars = CarsFactory.LoadAllCars();
            var parkingLot = new Dictionary<string, Car>();
            foreach (Car car in cars)
            {
                boy.Park(car, parkingLot);
            }

            var ticket = "SuperPark: 456213154";
            Car expected = null;

            //When
            var result = boy.Fetch(ticket, parkingLot);

            //Then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_ParkingBoyFecth_Return_No_Car_Given_No_Tickect()
        {
            //Given
            var boy = new ParkingBoy();
            var cars = CarsFactory.LoadAllCars();
            var parkingLot = new Dictionary<string, Car>();
            foreach (Car car in cars)
            {
                boy.Park(car, parkingLot);
            }

            Car expected = null;

            //When
            var result = boy.Fetch(parkingLot);

            //Then
            Assert.Equal(expected, result);
        }
    }
}
