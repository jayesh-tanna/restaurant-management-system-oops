namespace RMS
{
    public class User
    {
        public string Name { get; private set; }

        public string ContactNo { get; private set; }

        public User(string name, string contactNo)
        {
            Name = name;
            ContactNo = contactNo;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetContactNo(string contactNo)
        {
            ContactNo = contactNo;
        }
    }
}