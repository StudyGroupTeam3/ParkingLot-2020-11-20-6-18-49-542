using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Models
{
    public class Manager : IParkCar
    {
        private List<Boy> managementList = new List<Boy>();
        private List<Parkinglot> parkingLots = new List<Parkinglot>();

        public List<Boy> ManagementList => managementList;

        public void AddBoy(Boy boy)
        {
            managementList.Add(boy);
            LoadParkingLots(boy);
        }

        public Boy CallBoy(int boyNumber)
        {
            return managementList[boyNumber - 1];
        }

        public string ParkCar(Car car)
        {
            if (car == null)
            {
                return "wrong car";
            }

            var usableLot = parkingLots.FirstOrDefault(lot => lot.Capacity > lot.CarsCount);

            if (usableLot != null)
            {
                var ticket = usableLot.AddCarGetTicket(car);
                return ticket;
            }

            return "Not enough position";
        }

        private void LoadParkingLots(Boy boy)
        {
            foreach (var parkinglot in boy.ParkingLots)
            {
                parkingLots.Add(parkinglot);
            }
        }
    }
}
