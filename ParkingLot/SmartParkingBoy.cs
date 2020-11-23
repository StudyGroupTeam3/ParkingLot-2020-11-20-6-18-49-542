using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(List<ParkingLot> parkingLotList) : base(parkingLotList)
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
                this.ParkingLotList.Select(parkingLot => parkingLot.ParkingPositionNumber).Max();
            var parkingLot = this.ParkingLotList.FirstOrDefault(parkingLot => parkingLot.ParkingPositionNumber == maxParkingLotPosition);
            uint parkingLotId = parkingLot.ParkingLotId;
            uint carId = parkingLot.CarId;
            parkingLot.AddCar(car);
            errorMessage = null;
            return new ParkingTicket(parkingLotId, carId);
        }
    }
}
