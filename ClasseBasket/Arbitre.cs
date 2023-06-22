using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClasseBasket
{
    [Serializable]
    public class Arbitre : Personne, INotifyPropertyChanged
    {
        #region Variables membres

        private int _numArbitre;

        #endregion

        #region Proprietes

        public int NumArbitre
        {
            get { return _numArbitre; }
            set
            {
                if (_numArbitre == value) return;
                _numArbitre = value;
                OnPropertyChanged();
            }
        }

       

        #endregion

        #region Constructeur

        public Arbitre(String nom, String prenom, int numArbitre)
        {
            Nom = nom;
            Prenom = prenom;
            NumArbitre = numArbitre;
        }

        public Arbitre()
        {
            // pour serialisaton
        }

        #endregion

        #region SURCHARGES DES OPERATEURS

        public override string ToString()
        {
            return "Arbitre n" + NumArbitre + " Prenom : " + Prenom + " Nom : " + Nom;
        }
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;

            Arbitre arbitre = (Arbitre)obj;

            return NumArbitre == arbitre.NumArbitre && base.Equals(obj);
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + NumArbitre.GetHashCode();
            hash = hash * 23 + base.GetHashCode();
            return hash;
        }


        #endregion

        [field: NonSerialized]
        public new event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected new bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}