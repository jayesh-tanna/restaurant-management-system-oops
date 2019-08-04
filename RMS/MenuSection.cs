using System.Collections.Generic;
using System.Linq;

namespace RMS
{
    public class MenuSection
    {
        public Section Section { get; private set; }

        private List<FoodItem> _foodItems;

        public MenuSection(Section section)
        {
            Section = section;
            _foodItems = new List<FoodItem>();
        }

        public void SetSection(Section section) => Section = section;

        public void AddFoodItem(FoodItem foodItem)
        {
            if (_foodItems.Any(x => x.Equals(foodItem)))
                throw new System.Exception("Already exists");

            _foodItems.Add(foodItem);
        }

        public bool RemoveFoodItem(FoodItem foodItem)
        {
            return _foodItems.Remove(foodItem);
        }
    }
}