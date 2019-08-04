using System;
using System.Collections.Generic;
using System.Linq;

namespace RMS
{
    public class Menu
    {
        public Branch Branch { get; private set; }

        private List<MenuSection> _menuSections;

        public Menu(Branch branch)
        {
            Branch = branch;
            _menuSections = new List<MenuSection>();
        }

        public void SetBranch(Branch branch) => Branch = branch;

        public void AddSection(MenuSection section)
        {
            if (_menuSections.Any(x => x == section))
                throw new Exception("Already Exist");

            _menuSections.Add(section);
        }

        public bool RemoveSection(MenuSection section)
        {
            return _menuSections.Remove(section);
        }
    }
}