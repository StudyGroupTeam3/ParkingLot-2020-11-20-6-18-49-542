using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace ParkingLot
{
    public class ParkingLot
    {
        private string name;
        private int capacity = 10;
        private Dictionary<string, Car> cars = new Dictionary<string, Car>();
        private bool hasPosition = true;

        public ParkingLot(string inputName)
        {
            this.name = inputName;
        }

        public bool Park(Car carToPark)
        {
            return cars.TryAdd(carToPark.GetPlateNumber(), carToPark);
        }

        public void UpdateUsageCondition()
        {
            this.hasPosition = cars.Count <= this.capacity;
        }

        public bool HasPosition()
        {
            return this.hasPosition;
        }
    }
}
