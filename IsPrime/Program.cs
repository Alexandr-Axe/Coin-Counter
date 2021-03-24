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
        static void Main()
        {
            Pocitadlo Kasa = new Pocitadlo(); //Instance třídy Pocitadlo, která umí spočítat počet mincí
            Console.Write($"Jaká částka byla uhrazena? : ");
            string Castka = Console.ReadLine();
            try
            {
                Kasa.PocitaniMinci(Convert.ToInt32(Castka)); //Počítání mincí pomocí metody PocitaniMinci s částkou, která je převedená ze stringu na int
                Console.WriteLine(Kasa);
                Console.ReadKey();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                Console.ReadKey();
            }
        }
        
    }
    class Pocitadlo
    {
        /*Mince[0] = Padesátikoruny
          Mince[1] = Dvacetikoruny
          Mince[2] = Desetikoruny
          Mince[3] = Pětikoruny
          Mince[4] = Dvoukoruny
          Mince[5] = Jednokoruny
         */
        readonly int[] Mince = new int[] { -1, -1, -1, -1, -1, -1 }; //Pole mincí, každá mince má nastaveno -1, protože na začátku nemáme žádné mince
        public void PocitaniMinci(int ZaplacenaCastka) //Metoda na počítání mincí
        {
            int Zbytek; //Pokud je zbytek nula, znamená to, že máme perfektní počet mincí a program může skončit
            void Calculate(int Hodnota) //Metoda, která dělá život jednodušší, tady je celá logika
            {
                Zbytek = ZaplacenaCastka % Hodnota; //Zjištění, jestli máme zbytek po dělení
                switch (Hodnota) //Pro každou minci je nyní nastavena hodnota (pokud zaplatíme 100, tak se do Mince[0] uloží 2)
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
                if (Zbytek != 0) PocitaniMinci(Zbytek); //Pokud máme nějaký zbytek peněz, program pomocí rekurze pokračuje dál v počítání
                else
                {
                    for (int i = 0; i < Mince.Length; i++)
                    {
                        if (Mince[i] == -1) Mince[i] = 0; //Když nemáme zbytek, můžeme ukončit program. Pokud zaplatíme 100 a vrátí se nám 2 padesátikoruny, ostatní mince budou mít hodnotu -1
                    }
                }
            }
            //Pokud máme neprobádanou minci, vypočítáme její počet
            if (Mince[0] == -1) Calculate(50);
            else if (Mince[1] == -1) Calculate(20);
            else if (Mince[2] == -1) Calculate(10);
            else if (Mince[3] == -1) Calculate(5);
            else if (Mince[4] == -1) Calculate(2);
            else Mince[5] = ZaplacenaCastka;
        }
        public override string ToString() => $"Počet padesátikorun : { Mince[0]}\nPočet dvacetikorun : {Mince[1]}\nPočet desetikorun : {Mince[2]}\nPočet pětikorun : {Mince[3]}\nPočet dvoukorun : {Mince[4]}\nPočet jednokorun : {Mince[5] }";
    }
}
