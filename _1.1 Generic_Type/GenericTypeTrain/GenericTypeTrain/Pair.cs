using System.Threading.Channels;

namespace GenericTypeTrain
{
    public class Pair<TFirst, TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }

        public Pair(TFirst first, TSecond second)
        {
            First = first;
            Second = second;
        }
        public override string ToString() => $"{First} — {Second}";
        public void Show()
        {
            Console.WriteLine($"Первая: {First}\nВторая: {Second}");
        }
    }
}