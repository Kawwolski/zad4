using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zad4
{
    public class Program 
    {
      
        static void Main(string[] args)
        {
          
            const string filepath = "test.txt";
            try
            {
                
                Console.WriteLine("Podaj wartosc klucza");
                int k = int.Parse(Console.ReadLine());
                Cesar cesar = new Cesar(filepath);
                
                if (File.Exists(filepath))
                {
                    Console.WriteLine("Podaj tekst do zaszyfrowania");
                    string s = Console.ReadLine();
                    Console.WriteLine("Zaszyfrowana wiadomosc wg klucza: " + cesar.Coding(s, k));
                    cesar.Dispose();
                }
                else
                {
                    Console.WriteLine("Nie ma pliku");

                }
                Cesar cesar1 = new Cesar(filepath);
                Console.WriteLine("Odszyfrowana wiadomosc wg klucza: " + cesar1.Encoding(k));
                cesar1.Dispose();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();

        }

    }
    
}
