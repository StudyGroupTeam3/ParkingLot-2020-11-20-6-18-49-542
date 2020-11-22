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
    }
}
