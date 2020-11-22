using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace ParkingLot.Models
{
    public class Boy
    {
        private readonly List<Parkinglot> parkingLots;
        private readonly int boyNumber;
        public Boy(int boyNumber, List<Parkinglot> parkingLots)
        {
            this.boyNumber = boyNumber;
            this.parkingLots = parkingLots;
        }

        public List<Parkinglot> ParkingLots => parkingLots;
        public int BoyNumber => boyNumber;

        public virtual string ParkCar(Car car)
        {
            if (car == null)
            {
                return "wrong car";
            }

            var usableLot = parkingLots.FirstOrDefault(lot => lot.Capacity > lot.CarsCount);

            if (usableLot != null)
            {
                var ticket = usableLot.AddCarGetTicket(boyNumber, car);
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

            var lotIndex = int.Parse(ticket[..2]) - 1;
            var car = parkingLots[lotIndex].GetCarGivenTicket(ticket);

            return car ?? new Car("Unrecognized parking ticket");
        }

        public int GetCarsCount()
        {
            return parkingLots.Select(lot => lot.CarsCount).Sum();
        }
    }
}
