using System;
using System.Threading;

namespace Labirintus
{
    class Játék
    {
        static Random rndSeed = new Random();

        #region Adattagok
        /// <summary>
        /// A képernyőn megjelenő játékmezőhöz kapcsolódó adatok. A játékmezőn elhelyezett csillagok és a megtett lépések száma
        /// </summary>
        int csillagokSzáma = 0;
        int lépésekSzáma = 0;
        Játékos játékos = new Játékos();

        char[] s1 = { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', };
        char[] s2 = { '#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#','X','#', };

        const int HEIGHT = 21;
        const int WIDTH = 71;
        char[,] palya = new char[HEIGHT, WIDTH];

        #endregion
        #region Konstruktor
        /// <summary>
        /// Játék inicializálása: pálya kiválasztása, megadott számú csillag elhelyezése véletlenszerűen.
        /// </summary>
        /// <param name="csillagokSzáma">A felhasználó által megadott 5 és 25 közötti pozitív egész szám</param>
        public Játék(int csillagokSzáma)
        {
            for (int i = 0; i < HEIGHT; i+= 2)
            {
                for (int j = 0; j < WIDTH; j++)
			    {
                    palya[i, j] = s1[j];
                    if(i < HEIGHT-1)
                        palya[i + 1, j] = s2[j];
			    }
            }

            palya[HEIGHT - 1, WIDTH - 2] = '=';

            if (csillagokSzáma < 5)
                this.csillagokSzáma = 5;
            else if (csillagokSzáma > 25)
                this.csillagokSzáma = 25;
            else
                this.csillagokSzáma = csillagokSzáma;
            csillagokSzáma = this.csillagokSzáma;

            /* Enélkül a seed nélkül a csillagok elhelyezése nem eléggé véletlenszerű, a pálya téglalap-
             * és nem szabályos négyzet alakja ellenére az átló mentén helyezkednek el.
             * (lásd: dokumentáció ) */
            Random rndX = new Random(rndSeed.Next(1, 1111));
            Random rndY = new Random(rndSeed.Next(2, 2222));

            // ennyi egyseg nem fal palyareszt kell bejarni
            int palyaTerulete = (((HEIGHT - 1) / 2) * ((WIDTH - 1) / 2));

            int[,] iranyok = { { 0, 2 }, { 0, -2 }, { 2, 0 }, { -2, 0 } }; // jobb, bal, le, fel

            int[] poz1 = { 1, 1 };


            while (palyaTerulete > 0)
            {
                // Console.WriteLine(palyaTerulete.ToString());
                Random irany = new Random(rndSeed.Next(3, 3333));
                int i = irany.Next(1000) % 4;

                int[] poz2 = {poz1[0] + iranyok[i,0], poz1[1] + iranyok[i, 1]};

                if (poz2[0] > 0 && poz2[0] < HEIGHT && poz2[1] > 0 && poz2[1] < WIDTH)
                {
                    if(palya[poz1[0], poz1[1]] == 'X')
                        palya[poz1[0], poz1[1]] = 'V';

                    if (palya[poz1[0], poz1[1]] == 'V')
                    {

                        if (palya[poz2[0], poz2[1]] == 'X')
                        {
                            palya[(poz2[0] + poz1[0]) / 2, (poz2[1] + poz1[1]) / 2] = ' '; // fal eltavolitasa
                        }
                        palya[poz1[0], poz1[1]] = ' ';
                        palyaTerulete--;
                    }
                    else
                    {
                        // poz1 == ' '
                        if (palya[poz2[0], poz2[1]] != ' ')
                        {
                            palya[(poz2[0] + poz1[0]) / 2, (poz2[1] + poz1[1]) / 2] = ' ';
                            if (palya[poz2[0], poz2[1]] == 'V')
                            {
                                palya[poz2[0], poz2[1]] = ' ';
                                palyaTerulete--;
                            }
                        }
                    }
                    poz1 = poz2;
                }
            }

            while (csillagokSzáma > 0)
            {
                int x = rndX.Next(2, 71);
                int y = rndY.Next(2, 21);
                if (palya[y, x] == ' ')
                {
                    palya[y, x] = '*';
                    csillagokSzáma--;
                }

            }
        }
        #endregion

        #region Publikus metódus
        /// <summary>
        /// Maga a játék
        /// </summary>
        public void Start()
        {
            
            Kommunikáció.Kiír(palya, játékos.X, játékos.Y, játékos.Karakter, csillagokSzáma, lépésekSzáma);
            bool vége = false;
            while (!vége)
            {
                ConsoleKeyInfo x = Console.ReadKey(true);
                switch (x.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (palya[játékos.Y, játékos.X - 1] != '#' && (palya[játékos.Y, játékos.X - 1] != '=' || csillagokSzáma == 0))
                        {
                            játékos.X--;
                            lépésekSzáma++;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (palya[játékos.Y, játékos.X + 1] != '#' && (palya[játékos.Y, játékos.X + 1] != '=' || csillagokSzáma == 0))
                        {
                            játékos.X++;
                            lépésekSzáma++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (palya[játékos.Y - 1, játékos.X] != '#' && (palya[játékos.Y - 1, játékos.X] != '=' || csillagokSzáma == 0))
                        {
                            játékos.Y--;
                            lépésekSzáma++;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (palya[játékos.Y + 1, játékos.X] != '#' && (palya[játékos.Y + 1, játékos.X] != '=' || csillagokSzáma == 0))
                        {
                            játékos.Y++;
                            lépésekSzáma++;
                        }
                        break;
                    default:
                        break;
                }
                while (Console.KeyAvailable)
                {
                    x = Console.ReadKey(false);
                }
                if (palya[játékos.Y, játékos.X] == '*')
                {
                    palya[játékos.Y, játékos.X] = ' ';
                    csillagokSzáma--;
                }
                if (palya[játékos.Y, játékos.X] == '=')
                    vége = true;
                Kommunikáció.Kiír(palya, játékos.X, játékos.Y, játékos.Karakter, csillagokSzáma, lépésekSzáma);
                Thread.Sleep(10);
            }
        }
        #endregion
    }
}
