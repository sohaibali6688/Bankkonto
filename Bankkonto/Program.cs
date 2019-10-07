using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Bankkonto
{
    class Program
    {
        static void Main(string[] args)
        {
            String Seriennummer,nochmal="";

            do
            {

               

                bool eingabeprüfung = true;
                do
                {
                    Console.WriteLine("Seriennummer der Banknote eingeben:");
                    Seriennummer = Console.ReadLine().ToUpper();

                    if (Seriennummer.Length != 12)
                    {

                        Console.WriteLine("Die Seriennummer hat nicht die richtige Länge");
                        eingabeprüfung = false;
                    }
                    else if (char.IsLetter(Seriennummer[0]) == false || char.IsLetter(Seriennummer[1]) == false)
                    {
                        Console.WriteLine("Die ersten beiden Zeichen müssen Buchstaben sein:");
                        eingabeprüfung = false;
                    }
                    else if (Regex.IsMatch(Seriennummer.Substring(2, Seriennummer.Length - 2), "^[0-9]+$") == false) 
                    {
                        Console.WriteLine("Die letzten zehn Zeichen müssen Ziffern sein.");
                        eingabeprüfung = false;
                    }
                    else
                    {

                        Console.WriteLine("Folgende Seriennummer wird geprüft: " + Seriennummer);
                        eingabeprüfung = true;
                    }


                } while (eingabeprüfung == false);


                int summe, stelle1, stelle2,Rest,kontrollziffer;
                stelle1 = Convert.ToInt32(Seriennummer[0])-64;
                stelle2 = Convert.ToInt32(Seriennummer[1]) - 64;

                summe = stelle1 + stelle2;

                for (int i = 2; i < Seriennummer.Length-1; i++)
                {
                    summe += Convert.ToInt32(Convert.ToString(Seriennummer[i]));
                }


                Rest = summe % 9;
                kontrollziffer = Convert.ToInt32(Convert.ToString(Seriennummer[11]));

                if (kontrollziffer == 7 - Rest || (7 - Rest == 0 && kontrollziffer == 9) || (7 - Rest == -1 && kontrollziffer == 8))
                {
                    Console.WriteLine("Die Seriennummer ist gültig!");
                }
                else
                {
                    Console.WriteLine("Die Seriennummer ist nicht gültig!");
                }


                Console.WriteLine("Soll noch eine Seriennummer geprüft werden? (j/n)");
                nochmal = Console.ReadLine();
            } while (nochmal == "j");
            



        }
    }
}
