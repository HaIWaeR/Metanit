namespace InterfaceTrain.Intarface
{
    interface IPlayable
    {
        int Volume { get; }
        void Play(string music);
        void Stop();
    }
}