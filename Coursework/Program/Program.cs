using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoxOffice;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Performance performance = new Performance("lol", "kek", "pituh", 1998);
            Console.WriteLine($"{performance.Author}");
            Console.ReadKey();
        }
    }
}
