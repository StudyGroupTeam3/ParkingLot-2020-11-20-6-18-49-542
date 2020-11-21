namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        private readonly uint id;
        private readonly SortedDictionary<uint, ICar> parkingLotPlaces = new SortedDictionary<uint, ICar>();
        private uint carId = 0;

        public ParkingLot(uint id)
        {
            this.id = id;
        }

        public uint ParkingLotId => this.id;
        public uint CarId => this.carId;
        protected SortedDictionary<uint, ICar> ParkingLotPlaces => this.parkingLotPlaces;

        public void AddCar(ICar car)
        {
            this.parkingLotPlaces[this.GenerateCarId()] = car;
        }

        public ICar GetCar(uint carId)
        {
            var car = this.parkingLotPlaces[carId];
            this.parkingLotPlaces.Remove(carId);
            return car;
        }

        public bool HasCar(ICar car)
        {
            return this.parkingLotPlaces.Where(idCarPair => idCarPair.Value.Equals(car)).ToList().Count > 0;
        }

        public bool HasCarId(uint carId)
        {
            return this.parkingLotPlaces.ContainsKey(carId);
        }

        public bool IsCarIdProvided(uint carId)
        {
            return carId < this.carId;
        }

        private uint GenerateCarId()
        {
            return this.carId++;
        }
    }
}
