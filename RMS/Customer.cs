using System.Collections.Generic;
using System.Linq;

namespace RMS
{
    public class Customer : User
    {
        private List<Order> _orders;

        private List<Reservation> _reservations;

        public Customer(string name, string contactNo) : base(name, contactNo)
        {
            _orders = new List<Order>();
            _reservations = new List<Reservation>();
        }

        public void AddOrder(Order order)
        {
            if (_orders.Any(x => x == order))
                throw new System.Exception("Already exist");

            _orders.Add(order);
        }

        public void AddReservation(Reservation reservation)
        {
            if (_reservations.Any(x => x == reservation))
                throw new System.Exception("Already exist");

            _reservations.Add(reservation);
        }

        //public bool CancelReservation(Reservation reservation)
        //{

        //}

        //public bool CancelOrder(Order order)
        //{

        //}
    }
}