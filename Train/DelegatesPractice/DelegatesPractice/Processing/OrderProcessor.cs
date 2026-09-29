using DelegatesPractice.Models;

namespace DelegatesPractice.Processing
{
    public class OrderProcessor
    {
        public List<DiscountStep> Steps { get; } = new List<DiscountStep>();
        public delegate decimal DiscountStep(Order order, decimal amount);
        public DiscountRule? Rule { get; set; }

        public decimal Process(Order order)
        {
            decimal amount = order.Amount;

            foreach (var step in Steps)
            {
                amount = step(order, amount);
            }

            return amount;        
        }
    }
}