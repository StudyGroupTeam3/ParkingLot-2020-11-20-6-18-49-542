using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ParkingLot
{
    public class CarLot<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private int defaultCapacity = 10;
        public CarLot(int capacity)
        {
            Capacity = capacity;
        }

        public CarLot()
        {
            Capacity = defaultCapacity;
        }

        public int Capacity { get; }

        public double LoadRate => Convert.ToDouble(Count) / Convert.ToDouble(Capacity);
    }
}
