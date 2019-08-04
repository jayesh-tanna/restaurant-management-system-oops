using System;
using System.Collections.Generic;
using System.Linq;

namespace RMS
{
    public class Restaurant
    {
        private List<Branch> _branches;

        public string Name { get; private set; }

        public StarRating Rating { get; private set; }

        public Restaurant(string name, StarRating rating)
        {
            Name = name;
            Rating = rating;
            _branches = new List<Branch>();
        }

        public void AddBranch(Branch branch)
        {
            if (_branches.Any(x => x == branch))
                throw new Exception("This branch is already exist");
            _branches.Add(branch);
        }

        public bool TryRemoveBranch(Branch branch)
        {
            return _branches.Remove(branch);
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetRating(StarRating rating)
        {
            Rating = rating;
        }
    }
}