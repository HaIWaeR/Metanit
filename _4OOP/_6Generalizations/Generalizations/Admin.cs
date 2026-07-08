namespace Generalizations
{
    public class Admin<I, P>
    {
        public I Id { get; set; }
        public P Password { get; set; }
        public string Name { get; set; }
        public Admin(I id, P passwod, string name)
        {
            Id = id;
            Password = passwod;
            Name = name;
        }
    }
}
