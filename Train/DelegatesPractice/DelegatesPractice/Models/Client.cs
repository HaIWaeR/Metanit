namespace DelegatesPractice.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime RegisteredAt { get; set; }
        public bool IsConstant { get; set; }
        public Client() { }
        public Client(int id, string name, string city, DateTime registeredAt)
        {
            Id = id;
            Name = name;
            City = city;
            RegisteredAt = registeredAt;
            IsConstant = true;
            }

        public override string ToString() 
            => $"Id: {Id}, Name: {Name}, City: {City}, RegDate: {RegisteredAt}, Constant: {IsConstant}";
    }
}
