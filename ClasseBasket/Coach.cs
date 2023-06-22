using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClasseBasket
{
    [Serializable]
    public class Coach : Personne, INotifyPropertyChanged
    {
        #region Variables membres

        private int _numCoach;

        #endregion

        #region Proprietes

        public int NumCoach
        {
            get { return _numCoach; }
            set
            {
                if (_numCoach == value) return;
                _numCoach = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructeur

        public Coach(String nom, String prenom, int numCoach)
        {
            Nom = nom;
            Prenom = prenom;
            NumCoach = numCoach;
        }

        public Coach()
        {

        }
        #endregion

        #region SURCHARGES DES OPERATEURS

        public override string ToString()
        {
            return "Coach n" + NumCoach + " Prenom : " + Prenom + " Nom : " + Nom;
        }

        #endregion
        [field: NonSerialized]
        public new event PropertyChangedEventHandler PropertyChanged;

        protected new virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
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