using DelegatesPractice.Models;

namespace DelegatesPractice.Processing
{
    public delegate bool Condition(Order orders);
    public static class OrderFilter
    {
        static public List<Order> Filter(List<Order> orders, Condition condition)
        {
            List<Order> filteredOrders = new List<Order>();

            foreach (var order in orders)
            {
                if (condition(order))
                {
                    filteredOrders.Add(order);
                }
            }
            return filteredOrders;
        }

        public static bool AmountMoreTen(Order order) =>
            order.Amount >= 10_000;
        
        public static bool OrderCancelled(Order order) =>
           order.Status == OrderStatus.Canceled;

        public static bool ClientIsConstant(Order order) =>
            order.Client.IsConstant;
    }
}
