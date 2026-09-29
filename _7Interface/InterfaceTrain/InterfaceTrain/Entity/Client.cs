using InterfaceTrain.Intarface;

namespace InterfaceTrain.Entity
{
    public class Client : IEntity
    {
        private static int _count = 1;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Client(string name)
        {
            Id = _count;
            Name = name;
            _count++;
        }
    }
}
