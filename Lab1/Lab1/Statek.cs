namespace Lab1
{
    class Statek
    {
        public int MaxKontenery { get; }
        public double MaxKg { get; }
        public double Predkosc { get; } 
        public List<Kontener> Kontenery { get; }

        public Statek(int maxKontenery, double maxKg, double predkosc)
        {
            MaxKontenery = maxKontenery;
            MaxKg = maxKg;
            Predkosc = predkosc;
            Kontenery = new List<Kontener>();
        }

       
        public void Load(Kontener kontener)
        {
            if (Kontenery.Count >= MaxKontenery || GetKg() + kontener.MaxKg > MaxKg)
                throw new OverfillException("Statek nie może przewozić więcej kontenerów lub ich waga przekracza limit.");
            Kontenery.Add(kontener);
        }

     
        public void Unload(Kontener kontener)
        {
            Kontenery.Remove(kontener);
        }

       
        public void LoadStatek(List<Kontener> kontenery)
        {
            double totalKg = GetKg();
            if (Kontenery.Count + kontenery.Count > MaxKontenery)
                throw new OverfillException("Za dużo kontenerów.");
            foreach (var k in kontenery)
            {
                totalKg += k.MaxKg;
                if (totalKg > MaxKg)
                    throw new OverfillException("Waga przekroczyła limit statku.");
                Kontenery.Add(k);
            }
        }

        
        public void Replace(string numSeryjny, Kontener k)
        {
            var kontener = Kontenery.Find(c => c.NumSeryjny == numSeryjny);
            if (kontener != null) Unload(kontener);
            Load(k);
        }

        
        public void Move(Statek innyStatek, string numSeryjny)
        {
            var kontener = Kontenery.Find(c => c.NumSeryjny == numSeryjny);
            if (kontener != null)
            {
                Unload(kontener);
                innyStatek.Load(kontener);
            }
        }
        
        public double GetKg()
        {
            double waga = 0;
            foreach (var k in Kontenery)
            {
                waga += k.CurrentKg;
            }
            return waga;
        }


        public void KontenerInfo(string numSeryjny)
        {
            var kontener = Kontenery.Find(c => c.NumSeryjny == numSeryjny);
            if (kontener != null) Console.WriteLine(kontener.ToString());
        }

        
        public void StatekInfo()
        {
            Console.WriteLine($"Statek ma {Kontenery.Count}/{MaxKontenery} kontenerów i przewozi {GetKg()} kg ładunku.");
            foreach (var k in Kontenery)
            {
                Console.WriteLine(k.ToString());
            }
        }
    }
}
