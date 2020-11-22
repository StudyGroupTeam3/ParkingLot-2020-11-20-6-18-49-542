using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLotTest
{
    using Xunit;
    using ParkingLot;

    public class ParkingLotServiceManagerTest
    {
        [Fact]
        public void Should_parking_lot_service_manager_add_standard_parking_boy_to_managementList()
        {
            // given
            List<ParkingLot> parkingLotListForManager = new List<ParkingLot> { new ParkingLot(0), new ParkingLot(1) };
            List<ParkingLot> parkingLotListForParkingBoy = new List<ParkingLot> { new ParkingLot(2), new ParkingLot(3) };
            var parkingBoy = new ParkingBoy(parkingLotListForParkingBoy);
            var managementList = new List<ParkingBoy>();
            var parkingLotServiceManager = new ParkingLotServiceManager(parkingLotListForManager, managementList);
            // when
            parkingLotServiceManager.AddParkingBoy(parkingBoy);
            bool isStandardParkingBoyAdded = managementList.Contains(parkingBoy);
            // then
            Assert.True(isStandardParkingBoyAdded);
        }

        [Fact]
        public void Should_parking_lot_service_manager_add_smart_parking_boy_to_managementList()
        {
            // given
            List<ParkingLot> parkingLotListForManager = new List<ParkingLot> { new ParkingLot(0), new ParkingLot(1) };
            List<ParkingLot> parkingLotListForParkingBoy = new List<ParkingLot> { new ParkingLot(2), new ParkingLot(3) };
            var smartParkingBoy = new SmartParkingBoy(parkingLotListForParkingBoy);
            var managementList = new List<ParkingBoy>();
            var parkingLotServiceManager = new ParkingLotServiceManager(parkingLotListForManager, managementList);
            // when
            parkingLotServiceManager.AddParkingBoy(smartParkingBoy);
            bool isSmartParkingBoyAdded = managementList.Contains(smartParkingBoy);
            // then
            Assert.True(isSmartParkingBoyAdded);
        }

        [Fact]
        public void Should_parking_lot_service_manager_return_parking_boy_to_do_parking_works()
        {
            // given
            List<ParkingLot> parkingLotListForManager = new List<ParkingLot> { new ParkingLot(0), new ParkingLot(1) };
            List<ParkingLot> parkingLotListForParkingBoy = new List<ParkingLot> { new ParkingLot(2), new ParkingLot(3) };
            var superSmartParkingBoy = new SuperSmartParkingBoy(parkingLotListForParkingBoy);
            var managementList = new List<ParkingBoy>();
            var parkingLotServiceManager = new ParkingLotServiceManager(parkingLotListForManager, managementList);
            // when
            parkingLotServiceManager.AddParkingBoy(superSmartParkingBoy);
            bool isSuperSmartParkingBoyAdded = managementList.Contains(superSmartParkingBoy);
            // then
            Assert.True(isSuperSmartParkingBoyAdded);
        }

        [Fact]
        public void Should_parking_lot_service_manager_add_super_smart_parking_boy_to_managementList()
        {
            // given
            List<ParkingLot> parkingLotListForManager = new List<ParkingLot> { new ParkingLot(0), new ParkingLot(1) };
            List<ParkingLot> parkingLotListForParkingBoy = new List<ParkingLot> { new ParkingLot(2), new ParkingLot(3) };
            var expectedSuperSmartParkingBoy = new SuperSmartParkingBoy(parkingLotListForParkingBoy);
            var parkingLotServiceManager = new ParkingLotServiceManager(parkingLotListForManager, new List<ParkingBoy>());
            parkingLotServiceManager.AddParkingBoy(expectedSuperSmartParkingBoy);
            // when
            var specifiedParkingBoy = parkingLotServiceManager.SpecifyParkingBoy();
            // then
            Assert.Equal(expectedSuperSmartParkingBoy, specifiedParkingBoy);
        }

        [Fact]
        public void Should_specified_parking_boy_only_manipulate_parking_lots_managed_by_him()
        {
            // given
            List<ParkingLot> parkingLotListForManager = new List<ParkingLot> { new ParkingLot(0), new ParkingLot(1) };
            List<ParkingLot> parkingLotListForParkingBoy = new List<ParkingLot> { new ParkingLot(2, 0), new ParkingLot(3, 0) };
            var standardParkingBoy = new ParkingBoy(parkingLotListForParkingBoy);
            var parkingLotServiceManager = new ParkingLotServiceManager(parkingLotListForManager, new List<ParkingBoy>());
            parkingLotServiceManager.AddParkingBoy(standardParkingBoy);
            var specifiedParkingBoy = parkingLotServiceManager.SpecifyParkingBoy();
            // when
            string errorMessage;
            specifiedParkingBoy.ParkCar(new Car(), out errorMessage);
            // then
            Assert.Equal("Not enough position.", errorMessage);
        }
    }
}
