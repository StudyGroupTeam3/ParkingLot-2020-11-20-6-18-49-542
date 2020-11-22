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
            var parkingLots = new List<CarLot<string, Car>>()
            {
                new CarLot<string, Car>(),
            };
            string expected = parkingTicket;

            //When
            string result = boy.Park(car, parkingLots);

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
            var parkingLots = new List<CarLot<string, Car>>()
            {
                new CarLot<string, Car>(),
            };
            boy.Park(fetchedCar, parkingLots);
            Car expected = fetchedCar;

            //When
            var result = boy.Fetch(ticket, parkingLots);

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
            var parkingLots = new List<CarLot<string, Car>>()
            {
                LotInitialize.FillLotWithCars(3)
            };
            var ticket = "SuperPark: RJ_12784";
            boy.Park(new Car("RJ_12784"), parkingLots);
            Car expected = parkingLots[0]["RJ_12784"];

            //When
            var result = boy.Fetch(ticket, parkingLots);

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
            var parkingLots = new List<CarLot<string, Car>>()
            {
                LotInitialize.FillLotWithCars(3)
            };
            var ticket = "SuperPark: 456213154";
            Car expected = null;

            //When
            var result = boy.Fetch(ticket, parkingLots);

            //Then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_ParkingBoyFecth_Return_No_Car_Given_No_Tickect()
        {
            //Given
            var boy = new ParkingBoy();
            var parkingLots = new List<CarLot<string, Car>>()
            {
                LotInitialize.FillLotWithCars(3)
            };

            Car expected = null;

            //When
            var result = boy.Fetch(parkingLots);

            //Then
            Assert.Equal(expected, result);
        }
    }

    public class AC4
    {
        [Fact]
        public void Should_ParkingBoyFecth_Return_No_Car_Given_Used_Tickect()
        {
            //Given
            var boy = new ParkingBoy();
            var parkingLots = new List<CarLot<string, Car>>()
            {
                LotInitialize.FillLotWithCars(3),
            };

            var ticket = "SuperPark: RJ_12784";
            boy.Fetch(ticket, parkingLots);
            Car expected = null;

            //When
            var result = boy.Fetch(ticket, parkingLots);

            //Then
            Assert.Equal(expected, result);
        }
    }

    public class AC5
    {
        [Fact]
        public void Should_ParkingBoyPark_Return_No_Ticket_Given_Full_Parkinglot()
        {
            //Given
            var boy = new ParkingBoy();
            var parkingLots = new List<CarLot<string, Car>>()
            {
                LotInitialize.FillLotWithCars(10),
            };
            var car = new Car("BJ_454867");
            string expected = null;

            //When
            var result = boy.Park(car, parkingLots);

            //Then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_ParkingBoyPark_Return_No_Ticket_Given_Parked_Car()
        {
            //Given
            var boy = new ParkingBoy();
            var parkingLots = new List<CarLot<string, Car>>()
            {
                LotInitialize.FillLotWithCars(3),
            };
            var car = new Car("RJ_12784");
            boy.Park(car, parkingLots);
            string expected = null;

            //When
            var result = boy.Park(car, parkingLots);

            //Then
            Assert.Equal(expected, result);
        }
    }
}
