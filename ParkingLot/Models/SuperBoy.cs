using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot.Models
{
    public class SuperBoy : Boy
    {
        public SuperBoy(List<Parkinglot> parkingLots) : base(parkingLots)
        {
        }

        public override string ParkCar(Car car)
        {
            if (car == null)
            {
                return "wrong car";
            }

            var usableLot = ParkingLots.Aggregate((current, next) =>
                current.AvailablePositionRate >= next.AvailablePositionRate ? current : next);

            if (usableLot != null)
            {
                var ticket = usableLot.AddCarGetTicket(car);
                return ticket;
            }

            return "Not enough position";
        }
    }
}
