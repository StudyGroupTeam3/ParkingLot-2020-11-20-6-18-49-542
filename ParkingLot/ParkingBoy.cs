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
<<<<<<< HEAD
        private Dictionary<Car, ParkingLot> parkedCars = new Dictionary<Car, ParkingLot>();
        private List<ParkingLot> parkingLots;
        private int leftPosition;
        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
            leftPosition = parkingLots.Count * parkingLots[0].Capacity;
        }
=======
        private int capacity = 10;
        private int maxParkingLots = 2;
        private Dictionary<string, string> carAndTicketInformation = new Dictionary<string, string>();
>>>>>>> 001b23044a312ebd488f7f9c88ca360ae64d355c

        public ParkingTicket ParkingCar(Car car, out string errorMessage)
        {
<<<<<<< HEAD
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
=======
            for (int i = 0; i < maxParkingLots; i++)
            {
                if (carAndTicketInformation.Count >= i * capacity && carAndTicketInformation.Count < (i + 1) * capacity)
                {
                    ParkingLots parkingLot = new ParkingLots($"{i + 1}");
                    List<string> tickets = parkingLot.GetTickets();
                    string ticket = tickets[carAndTicketInformation.Count - i * capacity];
                    carAndTicketInformation.Add(ticket, car);
                    return ticket;
                }
            }

            /*
            if (carAndTicketInformation.Count < maxParkingLots * capacity)
            {
                List<ParkingLots> parkingLotses = new List<ParkingLots>();
                List<string> tickets = new List<string>();
                for (int i = 0; i < maxParkingLots; i++)
                {
                    ParkingLots parkingLot = new ParkingLots($"{i} + 1");
                    for (int j = 0; j < capacity; j++)
                    {
                        tickets.Add(parkingLot.GetTickets()[j]);
                    }

                    parkingLotses.Add(parkingLot);
                }

                string ticket = tickets[carAndTicketInformation.Count];
                carAndTicketInformation.Add(ticket, car);
                return ticket;
            }
            */
            return "Not enough position.";
>>>>>>> 001b23044a312ebd488f7f9c88ca360ae64d355c
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

<<<<<<< HEAD
            errorMessage = string.Empty;
            Car outCar = car;
            parkedCars.Remove(car);
            return outCar;
=======
            string fecthedCar = carAndTicketInformation[ticket];
            carAndTicketInformation.Remove(ticket);
            return fecthedCar;
>>>>>>> 001b23044a312ebd488f7f9c88ca360ae64d355c
        }
    }
}
