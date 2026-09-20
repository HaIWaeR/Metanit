using DelegatesPractice.Models;

namespace DelegatesPractice.Processing
{
    public delegate decimal DiscountRule(Order order);


    public static class DiscountRules
    {
        private const decimal AmountLimit = 10_000m;
        public static decimal RegularClientDiscount(Order order)
        {
            if (order.Client == null)
            {
                throw new InvalidOperationException("Client is empty");
            }

            if (order.Client.IsConstant)
                return order.Amount * 0.9m;
            else
                return order.Amount;
        }
        public static decimal LargeAmountDiscount(Order order)
        {
            if (order.Amount >= AmountLimit)
                return order.Amount * 0.95m;
            else
                return order.Amount;
        }
        public static decimal NoDiscount(Order order)
        {
            return order.Amount;
        }

        public static DiscountRule CreateDiscountRule(decimal percent)
        {
            decimal multiplier = 1 - (percent / 100m);

            decimal Rule(Order order) => order.Amount * multiplier;

            return Rule;
        }
    }
}
