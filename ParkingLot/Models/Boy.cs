using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace ParkingLot.Models
{
    public class Boy : IParkCar, IFetchCar
    {
        private readonly List<Parkinglot> parkingLots = new List<Parkinglot>();
        private readonly int boyNumber;
        public Boy(int boyNumber)
        {
            this.boyNumber = boyNumber;
        }

        public List<Parkinglot> ParkingLots => parkingLots;
        public int BoyNumber => boyNumber - 1;

        public virtual string ParkCar(Car car)
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

        public int GetCarsCount()
        {
            return parkingLots.Select(lot => lot.CarsCount).Sum();
        }
    }
}
