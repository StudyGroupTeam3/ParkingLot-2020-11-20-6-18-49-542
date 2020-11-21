namespace ParkingLot
{
    using System;
    public class Car
    {
        private string plateNumber;

        public Car(string carPlateNumber)
        {
            this.plateNumber = carPlateNumber;
        }

        public string GetPlateNumber()
        {
            return plateNumber;
        }
    }
}
