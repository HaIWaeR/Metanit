using IntarfacePractic.Interface;

namespace IntarfacePractic.Services
{
    public class OrderService
    {
        private readonly INotifier _notifier;
        public OrderService(INotifier notifier)
        {
            _notifier = notifier;
        }
        public void CompleteOrder(int orderId)
        {
            _notifier.Send($"Заказ {orderId} оформлен");
        }
    }
}
