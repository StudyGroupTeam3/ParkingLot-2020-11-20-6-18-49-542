using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ParkingLot
{
    public class ParkingTicket
    {
        private bool isUsed = false;
        public ParkingTicket(string carId, ParkingLot parkingLot)
        {
            CarId = carId;
            Lot = parkingLot;
        }

        public string CarId { get; }
        public ParkingLot Lot { get; }

        public string TicketId
        {
            get => $"{this.Lot.LotName}-{this.CarId}";
        }

        public bool IsUsed
        {
            get { return isUsed; }
            set { }
        }
    }
}