namespace Lab1;

class GazKontener : Kontener, IHazardNotifier
{
    public double Pressure { get; }

    public GazKontener(double maxKg, double wagaWlasna, double wysokosc, double glebokosc, double pressure)
        : base("G", maxKg, wagaWlasna, wysokosc, glebokosc)
    {
        Pressure = pressure;
    }

    public void Hazard(string message)
    {
        Console.WriteLine($"Uwaga: {NumSeryjny} - {message}");
    }

    public override void Load(double kg)
    {
        if (CurrentKg + kg > MaxKg)
        {
            Hazard($"Próba załadowania {kg} kg przekracza dopuszczalną ładowność {MaxKg} kg");
            throw new OverfillException("Próba wykonania niebezpecznej operacji");
        }
        
        base.Load(kg);
    }
    
    public new void Unload()
    {
        CurrentKg *= 0.05;
    }
}
