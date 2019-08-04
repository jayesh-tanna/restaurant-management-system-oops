using System;
using System.Collections.Generic;
using System.Linq;

namespace RMS
{
    public class Order
    {
        public OrderStatus Status { get; private set; }
        public Customer Customer { get; private set; }
        public decimal TotalAmount { get { return GetTotalAMount(); } }
        public Waiter Waiter { get; private set; }

        private List<Table> _tables;

        private List<OrderItem> _orderItems;

        public Order(List<Table> tables)
        {
            _tables = tables ?? throw new ArgumentNullException("tables");
            _orderItems = new List<OrderItem>();
            Status = OrderStatus.Placed;
        }

        public void RemoveFoodItem(FoodItem item)
        {
            var orderItem = _orderItems.FirstOrDefault(x => x.FoodItem == item);

            if (Status == OrderStatus.Placed && orderItem != null)
            {
                _orderItems.Remove(orderItem);
            }
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Placed)
                Status = OrderStatus.Cancelled;
            else
                throw new Exception("Cannot cancel this. Current status is " + Status.ToString());
        }

        public void AddFoodItem(FoodItem foodItem, int quantity)
        {
            if (Status == OrderStatus.Placed)
                _orderItems.Add(new OrderItem(this, foodItem, quantity));
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
        }

        public void AssignWaiter(Waiter waiter)
        {
            Waiter = waiter;
        }

        internal void ChangeFoodItemQuantity(FoodItem item, int newQuantity)
        {
            var orderItem = _orderItems.FirstOrDefault(x => x.FoodItem == item);

            if (orderItem == null)
                throw new ArgumentNullException("Fooditem");

            orderItem.ChangeQuantity(newQuantity);
        }

        private decimal GetTotalAMount()
        {
            return _orderItems.Select(x => x.Amount).Sum();
        }
    }
}