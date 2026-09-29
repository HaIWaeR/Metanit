namespace InterfaceTrain.Intarface
{
    interface IChargeable
    {
        int BatteryLevel { get; }
        void Charge(int value);
    }
}
