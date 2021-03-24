using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace IsPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            Pocitadlo Kasa = new Pocitadlo();
            while (true)
            {
                Console.Write($"Jakou částku jste uhradil? : ");
                string Castka = Console.ReadLine();
                try
                {
                    Kasa.PocitaniMinci(Convert.ToInt32(Castka));
                    Console.WriteLine(Kasa);
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        
    }
    class Pocitadlo
    {
        int[] Mince = new int[] { -1, -1, -1, -1, -1, -1 };
        public void PocitaniMinci(int ZaplacenaCastka)
        {
            int Zbytek;
            void Calculate(int Hodnota)
            {
                Zbytek = ZaplacenaCastka % Hodnota;
                switch (Hodnota)
                {
                    case 50:
                        Mince[0] = (ZaplacenaCastka - Zbytek) / Hodnota;
                        break;
                    case 20:
                        Mince[1] = (ZaplacenaCastka - Zbytek) / Hodnota;
                        break;
                    case 10:
                        Mince[2] = (ZaplacenaCastka - Zbytek) / Hodnota;
                        break;
                    case 5:
                        Mince[3] = (ZaplacenaCastka - Zbytek) / Hodnota;
                        break;
                    case 2:
                        Mince[4] = (ZaplacenaCastka - Zbytek) / Hodnota;
                        break;
                    case 1:
                        Mince[5] = (ZaplacenaCastka - Zbytek) / Hodnota;
                        break;
                }
                if (Zbytek != 0) PocitaniMinci(Zbytek);
                else 
                {
                    for (int i = 0; i < Mince.Length; i++)
                    {
                        if (Mince[i] == -1) Mince[i] = 0;
                    }
                }
            }
            if (Mince[0] == -1) Calculate(50);
            else if (Mince[1] == -1) Calculate(20);
            else if (Mince[2] == -1) Calculate(10);
            else if (Mince[3] == -1) Calculate(5);
            else if (Mince[4] == -1) Calculate(2);
            else Mince[5] = ZaplacenaCastka;
        }
        public override string ToString() => $"{Mince[0]} / {Mince[1]} / {Mince[2]} / {Mince[3]} / {Mince[4]} / {Mince[5]}";
    }
}
