namespace RMS
{
    public class FoodItem
    {
        public string Name { get; private set; }

        public MenuSection MenuSection { get; private set; }

        public string Ingredients { get; private set; }

        public decimal Price { get; private set; }

        public FoodItem(string name, MenuSection section, decimal price)
        {
            Name = name;
            MenuSection = section;
            Price = price;
        }

        public void SetName(string name) => Name = name;

        public void SetMenuSection(MenuSection section) => MenuSection = section;

        public void SetIngredients(string ingredients) => Ingredients = ingredients;

        public void SetPrice(decimal price) => Price = price;
    }
}