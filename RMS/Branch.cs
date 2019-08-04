using System;
using System.Collections.Generic;
using System.Linq;

namespace RMS
{
    public class Branch
    {
        public string Name { get; private set; }

        public string Address { get; private set; }
        public Restaurant Restaurant { get; private set; }
        private List<Table> _tables;

        public Menu Menu { get; private set; }

        public Branch(Restaurant restaurant, string name, string address)
        {
            Name = name;
            Address = address;
            Restaurant = restaurant;
            _tables = new List<Table>();
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetAddress(string address)
        {
            Address = address;
        }

        public void SetMenu(Menu menu)
        {
            Menu = menu;
        }

        public void AddTable(Table table)
        {
            if (_tables.Any(x => x == table))
                throw new Exception("Already exist");

            _tables.Add(table);
        }

        public bool TryRemoveTable(Table table)
        {
            return _tables.Remove(table);
        }

        public IEnumerable<Table> GetAllAvailableTables()
        {
            return _tables.Where(x => x.Available);
        }
    }
}