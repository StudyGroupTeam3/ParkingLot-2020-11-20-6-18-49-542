using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace ParkingLot.Models
{
    public class Boy
    {
        private readonly List<Parkinglot> parkingLots = new List<Parkinglot>();
        private readonly int boyNumber;
        public Boy(int boyNumber)
        {
            this.boyNumber = boyNumber;
        }

        public List<Parkinglot> ParkingLots => parkingLots;
        public string BoyNumber => boyNumber.ToString().PadLeft(2, '0');

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

            if (int.Parse(ticket[..2]) != boyNumber)
            {
                return new Car("Unrecognized parking ticket");
            }

            var lotIndex = int.Parse(ticket[2..4]) - 1;
            var car = parkingLots[lotIndex].GetCarGivenTicket(ticket);

            return car ?? new Car("Unrecognized parking ticket");
        }

        public int GetCarsCount()
        {
            return parkingLots.Select(lot => lot.CarsCount).Sum();
        }

        public void AddParkingLot(Parkinglot parkingLot)
        {
            parkingLot.LotNumber = (parkingLots.Count + 1).ToString().PadLeft(2, '0');
            parkingLot.BoyNumberBelonged = BoyNumber;
            parkingLots.Add(parkingLot);
        }
    }
}
