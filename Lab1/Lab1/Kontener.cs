using System;

namespace Lab1
{
    public abstract class Kontener
    {
        private static int id = 1;
        
        
        public string NumSeryjny { get; }
        public double MaxKg { get; }
        public double CurrentKg { get; set; }
        public double WlasnaWaga { get; }
        public double Wysokosc { get; }
        public double Glebokosc { get; }
        
        protected Kontener(string type, double maxKg, double wlasnaWaga, double wysokosc, double glebokosc)
        {

            NumSeryjny = $"KON-{type}-{id++}";
            MaxKg = maxKg;
            WlasnaWaga = wlasnaWaga;
            Wysokosc = wysokosc;
            Glebokosc = glebokosc;
            CurrentKg = 0;
        }
        
        public virtual void Load(double kg)
        {
            if (CurrentKg + kg > MaxKg)
                throw new OverfillException("Jest przekroczona maksymalną waga kontenera!");
            CurrentKg += kg;
        }
        
        public void Unload()
        {
            CurrentKg = 0;
        }
        
        public override string ToString()
        {
            return $"{NumSeryjny} | Załadowane: {CurrentKg}/{MaxKg} kg | Waga własna: {WlasnaWaga} kg | Wysokość: {Wysokosc} cm | Głębokość: {Glebokosc} cm";
        }
    }
    
    public class OverfillException : Exception
    {
        public OverfillException(string message) : base(message) { }
    }
}