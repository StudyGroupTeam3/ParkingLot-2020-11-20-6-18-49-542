namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        private readonly uint id;
        private readonly SortedDictionary<uint, ICar> parkingLotPlaces = new SortedDictionary<uint, ICar>();

        public ParkingLot(uint id)
        {
            this.id = id;
        }

        protected SortedDictionary<uint, ICar> ParkingLotPlaces => this.parkingLotPlaces;

        public void AddCar(ICar car)
        {
            this.parkingLotPlaces[(uint)parkingLotPlaces.Count] = car;
        }

        public ICar GetCar(uint carId)
        {
            return this.parkingLotPlaces[carId];
        }

        public bool HasCar(ICar car)
        {
            return this.parkingLotPlaces.Where(idCarPair => idCarPair.Value.Equals(car)).ToList().Count > 0;
        }

        public bool HasCarId(uint carId)
        {
            return this.parkingLotPlaces.ContainsKey(carId);
        }
    }
}
