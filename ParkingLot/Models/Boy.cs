using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Models
{
    public class Boy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        public Boy()
        {
            parkingLots.Add(new ParkingLot(1, 10));
            parkingLots.Add(new ParkingLot(2, 10));
        }

        public List<ParkingLot> ParkingLots => parkingLots;

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
