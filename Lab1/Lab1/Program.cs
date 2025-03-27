using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var kontener1 = new PlynKontener(1000, 100, 200, 100, true);  
            var kontener2 = new GazKontener(2000, 200, 150, 120, 5);      
            var kontener3 = new ChlodniczyKontener(500, 50, 100, 80, "Mleko", 4.5); 

      
            var statek = new Statek(5, 10000, 30); 

            
                statek.Load(kontener1);
                statek.Load(kontener2);
                statek.Load(kontener3);
            
             

            
            statek.StatekInfo();

           
            kontener1.Load(200); 
            kontener2.Load(150); 
            kontener3.Load(100, "Mleko", 4); 

         
            Console.WriteLine(kontener1.ToString());
            Console.WriteLine(kontener2.ToString());
            Console.WriteLine(kontener3.ToString());

           
            var nowyStatek = new Statek(3, 5000, 25);

           
            statek.Move(nowyStatek, kontener1.NumSeryjny);

          
            nowyStatek.StatekInfo();

            statek.Unload(kontener2);

            statek.StatekInfo();
        }
    }
}
