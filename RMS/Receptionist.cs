using System.Collections.Generic;
using System.Linq;

namespace RMS
{
    public class Receptionist : User
    {
        public Branch Branch { get; private set; }
        public List<Reservation> _reservations;

        public Receptionist(Branch branch, string name, string contactNo) : base(name, contactNo)
        {
            Branch = branch;
            _reservations = new List<Reservation>();
        }

        public void SetBranch(Branch branch)
        {
            Branch = branch;
        }

        public IEnumerable<Reservation> GetAllReservation()
        {
            return _reservations.ToArray();
        }

        public void AddReservation(Reservation reservation)
        {
            _reservations.Add(reservation);
        }

        public void AllocateTable()
        {
            if (_reservations.Count > 0)
            {
                Reservation reservation = _reservations[0]; 

                var availableTables = Branch.GetAllAvailableTables().ToList();

                int totalTables = availableTables.Count() - reservation.NoOfTableRequired;

                if (totalTables > 0)
                {
                    for (int i = 0; i < reservation.NoOfTableRequired; i++)
                    {
                        Table table = availableTables[i];

                        reservation.AddTable(table);
                    }

                    _reservations.Remove(reservation);
                }
                else
                {
                    throw new System.Exception("Enough tables not available");
                }
            }
            else
            {
                throw new System.Exception("No reservation found");
            }
        }

        public void CancelReservation(Reservation reservation)
        {
            reservation.SetStatus(ReservationStatus.Cancelled);

            _reservations.Remove(reservation);
        }
    }
}