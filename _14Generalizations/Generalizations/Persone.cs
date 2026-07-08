namespace Generalizations
{
    class Persone<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }

        public Persone(T id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
