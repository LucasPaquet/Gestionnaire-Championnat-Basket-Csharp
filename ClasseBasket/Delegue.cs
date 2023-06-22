using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClasseBasket
{
    [Serializable]
    public class Delegue : Personne, INotifyPropertyChanged
    {
        #region Variables membres

        private int _numDelegue;

        #endregion

        #region Proprietes

        public int NumDelegue
        {
            get { return _numDelegue; }
            set { _numDelegue = value; }
        }

        #endregion

        #region Constructeur

        public Delegue(String nom, String prenom, int numDelegue)
        {
            Nom = nom;
            Prenom = prenom;
            NumDelegue = numDelegue;
        }

        public Delegue()
        {
            // pour serialisaton
        }

        #endregion

        #region SURCHARGES DES OPERATEURS

        public override string ToString()
        {
            return "Delegue n" + NumDelegue + " Prenom : " + Prenom + " Nom : " + Nom;
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