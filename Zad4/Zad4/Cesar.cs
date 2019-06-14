using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zad4
{
   public class Cesar : IDisposable
    {
        bool disposed;
        FileStream fs { get; set; }
        public Cesar(string path)
        {
            
           fs = new FileStream(path, FileMode.OpenOrCreate,FileAccess.ReadWrite);
            
        }
        ~Cesar()
        {
            Console.WriteLine("Destructed");
            fs.Dispose();
            Console.ReadKey();
        }
       public int Step(char c,int k)
        {
            char offset = char.IsUpper(c) ? 'A' : 'a';
            return (((c + k) - offset) % 26) + offset;
        }
       public string Coding(string st,int k)
        {
            string exit = "";

            foreach (char c in st)
            {
                if (!char.IsLetter(c))
                {
                    exit += c;
                }
                else
                {

                    char d = (char)(Step(c, k));
                    exit += d;
                }
            }

            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(exit);
            }

            return exit;

            
        }
       public string Encoding(int k)
        {

            k = 26 - k;
            string exit = "", st = "";

            using(StreamReader sr=new StreamReader(fs))
            {
                st = sr.ReadLine();
            }

            foreach(char c in st)
            {
                if (!char.IsLetter(c))
                {
                    exit += c;
                }
                else
                {
                    char d = (char)(Step(c, k));
                    exit += d;
                }
            }

            return exit;

        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                fs.Dispose();
                Console.WriteLine("Closed");
                Console.ReadKey();
                disposed = true;
            }
        }

        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
