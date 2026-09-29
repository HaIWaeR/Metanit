using IntarfacePractic.Interface;

namespace IntarfacePractic.Services
{
    public class ClientServices
    {
        private readonly INotifier _notifier;
        public ClientServices(INotifier notifier)
        {
            _notifier = notifier;
        }
        public void Register(string name)
        {
            _notifier.Send($"Регистрация пользователя: {name}, прошла успешно ");
        }
    }
}
