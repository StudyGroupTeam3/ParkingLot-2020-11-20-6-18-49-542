using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.PortableExecutable;
using System.Text;
using ParkingLot.Models;
using Xunit;

namespace ParkingLotTest
{
    public class Story6Test : IDisposable
    {
        private readonly Boy boy = new Boy(1);
        private readonly SmartBoy smartBoy = new SmartBoy(2);
        private readonly SuperBoy superBoy = new SuperBoy(3);
        private readonly Manager manager = new Manager();

        public Story6Test()
        {
            boy.AddParkingLot(new Parkinglot(10));
            smartBoy.AddParkingLot(new Parkinglot(10));
            superBoy.AddParkingLot(new Parkinglot(10));
            manager.AddBoy(boy);
            manager.AddBoy(smartBoy);
            manager.AddBoy(superBoy);
        }

        public void Dispose()
        {
        }

        [Fact]
        public void AC1_Should_return_updated_managementList_when_add_parking_boys()
        {
            // given

            // when
            var expected = new List<Boy>() { boy, smartBoy, superBoy, };
            var actual = manager.ManagementList;

            // then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AC1_Should_return_ticket_when_manager_call_boy_parking_car()
        {
            // given
            var car = new Car("BMW");

            // when
            var ticket = manager.CallBoy(2).ParkCar(car);
            var expected = "0201001";
            var actual = ticket;

            // then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AC1_Should_return_wrong_message_when_manager_give_boy_ticket_from_another_parkingLot()
        {
            // given
            var car = new Car("BMW");

            // when
            manager.CallBoy(1).ParkCar(car);
            var ticket2 = manager.CallBoy(2).ParkCar(car);
            var expected = "Unrecognized parking ticket";
            var actual = manager.CallBoy(1).FetchCar(ticket2);

            // then
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void AC2_Should_return_ticket_or_car_when_manager_work_as_standard_boy()
        {
            // given
            var car = new Car("BMW");
            var count = 0;
            // when
            while (count < 20)
            {
                manager.ParkCar(car);
                count++;
            }

            var ticket = manager.ParkCar(car);
            var expected = "0301001";
            var actual = ticket;

            // then
            Assert.Equal(expected, actual);
        }
    }
}
