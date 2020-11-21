namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        private uint id;
        private SortedDictionary<uint, ICar> parkingLotPlaces = new SortedDictionary<uint, ICar>();

        public ParkingLot(uint id)
        {
            this.id = id;
        }

        protected SortedDictionary<uint, ICar> ParkingLotPlaces => this.parkingLotPlaces;

        public void AddCar(ICar car)
        {
            this.parkingLotPlaces[(uint)parkingLotPlaces.Count] = car;
        }
    }
}
