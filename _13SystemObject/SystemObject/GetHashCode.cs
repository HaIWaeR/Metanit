namespace SystemObject
{
    class Person2
    {
        public string Name { get; set; } = "";

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
