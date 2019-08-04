using System;
using System.Collections.Generic;
using System.Linq;

namespace RMS
{
    public class Waiter : User
    {
        public Branch Branch { get; private set; }
        private List<Order> _orders;
        public DateTime ShiftFromTime { get; private set; }
        public DateTime ShiftToTime { get; private set; }

        public Waiter(Branch branch, string name, string contactNo) : base(name, contactNo)
        {
            Branch = branch;
        }

        public void SetBranch(Branch branch)
        {
            Branch = branch;
        }

        public void SetShiftFromTime(DateTime time)
        {
            ShiftFromTime = time;
        }

        public void SetShiftToTime(DateTime time)
        {
            ShiftToTime = time;
        }

        public void CreateOrder(Order order)
        {
            if (_orders.Any(x => x == order))
                throw new Exception("Already exist");

            order.AssignWaiter(this);

            _orders.Add(order);
        }

        public void CancelOrder(Order order)
        {
            order.Cancel();
        }

        public void AddFoodItem(Order order, FoodItem item, int quantity)
        {
            order.AddFoodItem(item, quantity);
        }

        public void CancelFoodItem(Order order, FoodItem item)
        {
            order.RemoveFoodItem(item);
        }

        public void ChangeFoodItemQuantity(Order order,FoodItem item,int newQuantity)
        {
            if (newQuantity == 0)
                CancelFoodItem(order, item);
            else
                order.ChangeFoodItemQuantity(item, newQuantity);
        }
    }
}