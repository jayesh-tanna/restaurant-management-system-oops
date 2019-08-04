namespace RMS
{
    public class Table
    {
        public int Number { get; private set; }

        public int Capacity { get; private set; }

        public bool Available { get; private set; }

        public Branch Branch { get; private set; }

        public Reservation Reservation { get; private set; }

        public Table(int number, int capacity, Branch branch)
        {
            Number = number;
            Capacity = capacity;
            Branch = branch;
            Available = true;
        }

        public void SetReservation(Reservation reservation)
        {
            Reservation = reservation;

            SetAvailability(false);
        }

        public void SetNumber(int number)
        {
            Number = number;
        }

        public void SetCapacity(int capacity)
        {
            Capacity = capacity;
        }

        public void SetAvailability(bool available)
        {
            Available = available;
        }

        public void SetBranch(Branch branch)
        {
            Branch = branch;
        }
    }
}