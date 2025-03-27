using Lab1;

class PlynKontener : Kontener, IHazardNotifier
{
    public bool IsHazardous { get; }

    public PlynKontener(double maxKg, double wagaWlasna, double wysokosc, double glebokosc, bool isHazardous)
        : base("L", maxKg, wagaWlasna, wysokosc, glebokosc)
    {
        IsHazardous = isHazardous;
    }

    public void Hazard(string message)
    {
        Console.WriteLine($"Uwaga: {NumSeryjny} - {message}");
    }

    public override void Load(double kg)
    {
        double max = IsHazardous ? MaxKg * 0.5 : MaxKg * 0.9;
        
        if (kg > max)
        {
            Hazard($"Próba załadowania {kg} kg, przekracza limit {(IsHazardous ? "50%" : "90%")}. Maksymalnie: {max} kg");
            throw new OverfillException("Próba wykonania niebezpecznej operacji");
        }
        
        base.Load(kg);
    }
}