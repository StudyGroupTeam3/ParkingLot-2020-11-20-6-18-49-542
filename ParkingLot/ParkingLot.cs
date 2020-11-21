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

        public ParkingTicket Park(Car car)
        {
            if (this.hasPosition && this.cars.TryAdd(car.GetPlateNumber(), car))
            {
                UpdateUsageCondition();
                return GenerateParkingTicket(car);
            }

            return null;
        }

        public Car Fetch(ParkingTicket parkingTicket)
        {
            if (cars.ContainsKey(parkingTicket.GetCarPlateNumber()))
            {
                return cars[parkingTicket.GetCarPlateNumber()];
            }

            return null;
        }

        public void UpdateUsageCondition()
        {
            this.hasPosition = cars.Count < this.capacity;
        }

        private ParkingTicket GenerateParkingTicket(Car car)
        {
            return new ParkingTicket(car.GetPlateNumber(), this.name);
        }
    }
}
