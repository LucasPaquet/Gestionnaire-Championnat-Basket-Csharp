using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClasseBasket
{
    [Serializable]
    public class EquipeClassement : INotifyPropertyChanged
    {
        #region VARIABLES MEMBRES

        private Equipe _equipe;
        private int _victoire;
        private int _defaite;
        private int _egalite;
        private int _point;

        #endregion

        #region PROPRIETES

        public Equipe Equipe
        {
            get { return _equipe; }
            set
            {
                if (_equipe == value) return;
                _equipe = value;
                OnPropertyChanged();
            }
        }
        public int Victoire
        {
            get { return _victoire; }
            set
            {
                if (_victoire == value) return;
                _victoire = value;
                OnPropertyChanged();
            }
        }
        public int Defaite
        {
            get { return _defaite; }
            set
            {
                if (_defaite == value) return;
                _defaite = value;
                OnPropertyChanged();
            }
        }
        public int Egalite
        {
            get { return _egalite; }
            set
            {
                if (_egalite == value) return;
                _egalite = value;
                OnPropertyChanged();
            }
        }
        public int Point
        {
            get { return _point; }
            set
            {
                if (_point == value) return;
                _point = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region CONSTRUCTEUR

        public EquipeClassement()
        {
            Victoire = 0;
            Defaite = 0;
            Egalite = 0;
            Point = 0;
        }
        public EquipeClassement(Equipe e)
        {
            Equipe = e;
            Victoire = 0;
            Defaite = 0;
            Egalite = 0;
            Point = 0;
        }

        #endregion

        #region METHODE
        public override string ToString()
        {
            return Victoire + " " + Point;
        }
        public void AjouteVictoire()
        {
            Victoire += 1;
            Point += 3;
        }
        public void AjouteDefaite()
        {
            Defaite += 1;
            Point += 1;
        }
        public void AjouteEgalite()
        {
            Egalite += 1;
            Point += 2;
        }
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}