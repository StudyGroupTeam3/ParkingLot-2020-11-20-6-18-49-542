using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Models
{
    public interface IFetchCar
    {
        public Car FetchCar(string ticket);
    }
}
