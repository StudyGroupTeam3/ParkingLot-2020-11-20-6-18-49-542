using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private Dictionary<Car, ParkingLot> parkedCars = new Dictionary<Car, ParkingLot>();
        private List<ParkingLot> parkingLots;
        private int leftPosition;
        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
            leftPosition = parkingLots.Count * parkingLots[0].Capacity;
        }

        public ParkingTicket ParkingCar(Car car, out string errorMessage)
        {
            if (car == null)
            {
                errorMessage = "Input car is null.";
            }

            if (leftPosition <= 0)
            {
                errorMessage = "Not enough position.";
                return null;
            }

            ParkingLot parkingLot = new ParkingLot("A");
            errorMessage = string.Empty;
            ParkingTicket parkingTicket = new ParkingTicket(car.CarId, parkingLot);
            parkedCars.Add(car, parkingLot);
            leftPosition--;
            return parkingTicket;
        }

        public Car FetchCar(ParkingTicket parkingTicket, out string errorMessage)
        {
            Car car = null;
            if (parkingTicket == null)
            {
                errorMessage = "Please provide your parking ticket.";
                return null;
            }

            if (parkingTicket.IsUsed)
            {
                errorMessage = "Unrecognized parking ticket.";
                return null;
            }

            foreach (var parkedCar in parkedCars)
            {
                if (parkedCar.Key.CarId == parkingTicket.CarId)
                {
                    parkingTicket.IsUsed = true;
                    car = parkedCar.Key;
                }
            }

            errorMessage = string.Empty;
            Car outCar = car;
            parkedCars.Remove(car);
            return outCar;
        }
    }
}
