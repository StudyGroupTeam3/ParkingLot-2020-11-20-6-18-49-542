using System;

namespace ParkingLot
{
    public class Car
    {
        private readonly string plateNumber;

        public Car(string carPlateNumber)
        {
            this.plateNumber = carPlateNumber;
        }

        public string GetPlateNumber()
        {
            return this.plateNumber;
        }
    }
}
