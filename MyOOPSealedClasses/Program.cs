using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOOPSealedClasses
{
    sealed class Sealedclass
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sealedclass sealedclass = new Sealedclass();
            int total = sealedclass.Add(1, 2);
            Console.WriteLine("Addiion is: {0}", total);
            Console.ReadLine();
        }
       
    }
}
