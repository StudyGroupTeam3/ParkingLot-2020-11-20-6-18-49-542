using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class SuperSmartParkingBoy : ParkingBoy
    {
        public SuperSmartParkingBoy(List<ParkingLot> parkingLotList) : base(parkingLotList)
        {
        }

        public override ParkingTicket ParkCar(ICar car, out string errorMessage)
        {
            if (!IsInputCarValid(car))
            {
                errorMessage = null;
                return null;
            }

            if (this.ParkingLotList.Where(parkingLot => parkingLot.HasPosition()).ToList().Count == 0)
            {
                errorMessage = "Not enough position.";
                return null;
            }

            var maxParkingLotPosition =
                this.ParkingLotList.Select(parkingLot => parkingLot.AvailablePositionRate).Max();
            var parkingLot = this.ParkingLotList.FirstOrDefault(parkingLot => parkingLot.AvailablePositionRate == maxParkingLotPosition);
            uint parkingLotId = parkingLot.ParkingLotId;
            uint carId = parkingLot.CarId;
            parkingLot.AddCar(car);
            errorMessage = null;
            return new ParkingTicket(parkingLotId, carId);
        }
    }
}
