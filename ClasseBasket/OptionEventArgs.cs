using System;

namespace ClasseBasket
{
    public struct RGB
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public RGB(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
    public class OptionEventArgs : EventArgs
    {
        #region VARIABLES

        private int _taille;
        private RGB _color;

        #endregion

        #region CONSTRUCTEUR

        public OptionEventArgs(int taille, RGB color)
        {
            _taille = taille;
            _color = color;
        }

        #endregion

        #region GETX ET SETX

        public int Taille
        {
            set { _taille = value; }
            get { return _taille; }
        }

        public RGB Color
        {
            set { _color = value; }
            get { return _color; }
        }

        #endregion
    }
}