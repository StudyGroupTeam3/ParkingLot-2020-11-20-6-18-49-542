using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private readonly List<ParkingLot> parkingLotList;

        public ParkingBoy(List<ParkingLot> parkingLotList)
        {
            this.parkingLotList = parkingLotList;
        }

        protected List<ParkingLot> ParkingLotList => this.parkingLotList;

        public virtual ParkingTicket ParkCar(ICar car, out string errorMessage)
        {
            if (!IsInputCarValid(car))
            {
                errorMessage = null;
                return null;
            }

            if (this.parkingLotList.Where(parkingLot => parkingLot.HasPosition()).ToList().Count == 0)
            {
                errorMessage = "Not enough position.";
                return null;
            }

            var parkingLot = this.parkingLotList.FirstOrDefault(parkingLot => parkingLot.HasPosition());
            uint parkingLotId = parkingLot.ParkingLotId;
            uint carId = parkingLot.CarId;
            parkingLot.AddCar(car);
            errorMessage = null;
            return new ParkingTicket(parkingLotId, carId);
        }

        public ICar FetchCar(ParkingTicket parkingTicket, out string errorMessage)
        {
            if (!IsInputParkingTicketValid(parkingTicket, out errorMessage))
            {
                return null;
            }

            var parkingLot =
                this.parkingLotList.FirstOrDefault(parkingLot => parkingLot.ParkingLotId == parkingTicket.ParkingLotId);
            errorMessage = null;
            return parkingLot.GetCar(parkingTicket.CarId);
        }

        protected bool IsInputCarValid(ICar car)
        {
            if (car is null)
            {
                return false;
            }

            if (this.parkingLotList.Where(parkingLot => parkingLot.HasCar(car)).ToList().Count > 0)
            {
                return false;
            }

            return true;
        }

        private bool IsInputParkingTicketValid(ParkingTicket parkingTicket, out string errorMessage)
        {
            if (parkingTicket is null)
            {
                errorMessage = "Please provide your parking ticket.";
                return false;
            }

            if (this.parkingLotList.Where(parkingLot => parkingLot.ParkingLotId == parkingTicket.ParkingLotId).ToList().Count == 0)
            {
                errorMessage = "Unrecognized parking ticket.";
                return false;
            }

            var parkingLot =
                this.parkingLotList.FirstOrDefault(parkingLot => parkingLot.ParkingLotId == parkingTicket.ParkingLotId);

            if (!parkingLot.IsCarIdProvided(parkingTicket.CarId))
            {
                errorMessage = "Unrecognized parking ticket.";
                return false;
            }

            if (!parkingLot.HasCarId(parkingTicket.CarId))
            {
                errorMessage = "Unrecognized parking ticket.";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
