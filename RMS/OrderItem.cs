namespace RMS
{
    public class OrderItem
    {
        public Order Order { get; private set; }
        public FoodItem FoodItem { get; private set; }

        public int Quantity { get; private set; }
        public decimal Amount { get; private set; }

        public OrderItem(Order order, FoodItem foodItem, int quantity)
        {
            Order = order;
            FoodItem = foodItem;
            Quantity = quantity;
            SetAmount();
        }

        public void ChangeQuantity(int newQuantity)
        {
            Quantity = newQuantity;

            SetAmount();
        }

        private void SetAmount()
        {
            Amount = FoodItem.Price * Quantity;
        }
    }
}