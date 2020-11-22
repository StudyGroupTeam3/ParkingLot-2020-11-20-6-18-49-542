using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using ParkingLot.Models;
using Xunit;

namespace ParkingLotTest
{
    public class Story6Test
    {
        [Fact]
        public void AC1_Should_return_updated_managementList_when_add_parking_boys()
        {
            // given
            var manager = new Manager();
            var boy = new Boy(new List<Parkinglot>() { new Parkinglot(1, 10), });
            var smartBoy = new SmartBoy(new List<Parkinglot>() { new Parkinglot(1, 10), });
            var superBoy = new SuperBoy(new List<Parkinglot>() { new Parkinglot(1, 10), });

            // when
            manager.AddBoy(boy);
            manager.AddBoy(smartBoy);
            manager.AddBoy(superBoy);
            var expected = new List<Boy>() { boy, smartBoy, superBoy, };
            var actual = manager.ManagementList;

            // then
            Assert.Equal(expected, actual);
        }
    }
}
