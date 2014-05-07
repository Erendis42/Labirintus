using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labirintus
{
    class Program
    {
        static void Main(string[] args)
        {
            Játék játék;
            try { játék = new Játék(Kommunikáció.Bekér()); }
            catch { játék = new Játék(25); }
            játék.Start();
            Kommunikáció.Vége();
            Console.ReadLine();
        }
    }
}
