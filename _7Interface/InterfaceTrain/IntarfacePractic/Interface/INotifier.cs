namespace IntarfacePractic.Interface
{
    public interface INotifier
    {
        string Name { get; }
        void Send(string message);
    }
}
