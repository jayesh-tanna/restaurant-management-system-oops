using System;
using System.Collections.Generic;
using System.Linq;

namespace RMS
{
    public class Reservation
    {
        public ReservationStatus Status { get; private set; }

        public Customer Customer { get; private set; }

        public DateTime DateTime { get; private set; }

        public int NoOfPersons { get; private set; }

        public int NoOfTableRequired { get; private set; }

        private List<Table> _tables;

        public Reservation(Customer customer, DateTime dateTime, int noOfPersons, int noOfTableRequired)
        {
            Customer = customer;
            DateTime = dateTime;
            NoOfPersons = noOfPersons;
            Status = ReservationStatus.Reserved;
            _tables = new List<Table>();
            NoOfTableRequired = noOfTableRequired;
        }

        public void AddTable(Table table)
        {
            if (_tables.Any(x => x == table))
                throw new Exception("Already exist");

            if (table.Available)
            {
                _tables.Add(table);

                table.SetReservation(this);
            }
        }

        public void SetNoOfTableRequired(int noOfTableRequired)
        {
            NoOfTableRequired = noOfTableRequired;
        }

        public IEnumerable<Table> GetAllTables()
        {
            return _tables;
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer = customer;
        }

        public void ChangeTime(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public void UpdateNoOfPersons(int noOfPersons)
        {
            NoOfPersons = noOfPersons;
        }

        public void SetStatus(ReservationStatus status)
        {
            Status = status;
        }
    }
}