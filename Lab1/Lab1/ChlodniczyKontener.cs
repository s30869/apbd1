namespace Lab1;

class ChlodniczyKontener : Kontener
{
    public string Type { get; }
    public double Temperatura { get; }
    private string actualProdukt;

    public ChlodniczyKontener(double maxKg, double wagaWlasna, double wysokosc, double glebokosc, string type, double temperatura) 
        : base("C", maxKg, wagaWlasna, wysokosc, glebokosc)
    {
        Type = type;
        Temperatura = temperatura;
        actualProdukt = null;
    }

    public void Load(double kg, string productType, double wymaganaTemperatura)
    {
        if (actualProdukt == null)
        {
            actualProdukt = productType;
        }
        else if (actualProdukt != productType)
        {
            throw new Exception($"Uwaga: Kontener może przechowywać tylko {actualProdukt}.");
        }
        
        if (Temperatura > wymaganaTemperatura)
        {
            throw new Exception($"Uwaga: Temperatura kontenera nie może być niższa niż wymagana ({wymaganaTemperatura}°C).");
        }

        base.Load(kg);
    }
}