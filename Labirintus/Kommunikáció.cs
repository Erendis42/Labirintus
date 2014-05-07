using System;

namespace Labirintus
{
    class Kommunikáció
    {
        #region Publikus metódusok
        /// <summary>
        /// Bekér a felegy pozitív egész 2-25 közötti számot, majd továbbadja
        /// </summary>
        /// <returns></returns>
        public static int Bekér()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("################################################################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(22, 2);
            Console.WriteLine("L A B I R I N T U S  J Á T É K");
            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("################################################################################");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(7, 7);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Irányítás:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(18, 7);
            Console.WriteLine("a nyilak segítségével");
            Console.SetCursorPosition(7, 9);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("A játék célja:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(22, 9);
            Console.WriteLine("az összes csillag begyűjtését követően a pálya");
            Console.SetCursorPosition(7, 10);
            Console.WriteLine("bal alsó sarkában található = jelre lépve kijutni az útvesztőből");
            Console.SetCursorPosition(62, 13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Jó játékot!");
            Console.SetCursorPosition(7, 17);
            Console.Write("Hány csillagot tegyek le?");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(7, 19);
            Console.WriteLine("(5-25 közötti egész szám. 5: játszható, 25: \"idegesítő #@$ $<&¤,");
            Console.SetCursorPosition(7, 20);
            Console.WriteLine("mindjárt kiß&$<om az egész kócerájt a kukába\")");
            Console.SetCursorPosition(33, 17);
            int cs = int.Parse(Console.ReadLine());
            return cs;
        }
        /// <summary>
        /// Megjeleníti a játék aktuális állapotát
        /// </summary>
        /// <param name="p">A labirintus (és játék közben a csillagok is)</param>
        /// <param name="x">A játékos X koordinátája</param>
        /// <param name="y">A játékos Y koordinátája</param>
        /// <param name="k">A játékost megjelenítő karakter (@)</param>
        /// <param name="cs">A játékmezőn még meglévő csillagok száma</param>
        /// <param name="l">Lépések száma</param>
        public static void Kiír(char[,] p, int x, int y, char k, int cs, int l)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < p.GetLength(0); i++)
            {
                for (int j = 0; j < p.GetLength(1); j++)
                {
                    if (x == j && y == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(k);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else if (p[i, j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(p[i, j]);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                        Console.Write(p[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Csillagok száma: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(cs);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Lépések száma: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(l);
        }
        public static void Vége()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(22, 10);
            Console.WriteLine("Kijutottál a labirintusból! \\o/");
            Console.SetCursorPosition(0, 24);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion
    }
}