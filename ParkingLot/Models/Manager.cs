using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Models
{
    public class Manager : IParkCar, IFetchCar
    {
        private List<Boy> managementList = new List<Boy>();
        private List<Parkinglot> parkingLots = new List<Parkinglot>();

        public List<Boy> ManagementList => managementList;
        public List<Parkinglot> ParkingLots => parkingLots;

        public void AddBoy(Boy boy)
        {
            managementList.Add(boy);
        }

        public void AddParkingLot(Parkinglot parkingLot)
        {
            parkingLot.LotNumber = (parkingLots.Count + 1).ToString().PadLeft(2, '0');
            parkingLots.Add(parkingLot);
        }

        public Boy CallBoy(int boyNumber)
        {
            return managementList[boyNumber - 1];
        }

        public void DistributeParkingLots(Boy boy, Parkinglot parkingLot)
        {
            boy.ParkingLots.Add(parkingLot);
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

        public Car FetchCar(string ticket)
        {
            if (ticket == null)
            {
                return new Car("Please provide your parking ticket");
            }

            var lotFind = parkingLots.FirstOrDefault(lot => lot.LotNumber == ticket[..2]);

            if (lotFind == null)
            {
                return new Car("Unrecognized parking ticket");
            }

            var car = lotFind.GetCarGivenTicket(ticket);

            return car ?? new Car("Unrecognized parking ticket");
        }
    }
}
