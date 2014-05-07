using System;

namespace Labirintus
{
    class Játékos
    {
        #region Adattagok
        int x;
        int y;
        char karakter;
        #endregion

        #region Tulajdonságok
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public char Karakter
        {
            get { return karakter; }
        }
        #endregion

        #region Konstruktor
        public Játékos()
        {
            x = 1;
            y = 1;
            karakter = '@';
        }
        #endregion
    }
}