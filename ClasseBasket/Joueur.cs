using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClasseBasket
{
    [Serializable]
    public class Joueur : Personne, INotifyPropertyChanged
    {
        #region Variables membres

        private int _numJoueur;

        #endregion

        #region Proprietes

        public int NumJoueur
        {
            get { return _numJoueur; }
            set
            {
                if (_numJoueur == value) return;
                _numJoueur = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructeur

        public Joueur(String nom, String prenom, int numJoueur)
        {
            Nom = nom;
            Prenom = prenom;
            NumJoueur = numJoueur;
        }

        public Joueur()
        {

        }

        #endregion

        #region SURCHARGES DES OPERATEURS

        public override string ToString()
        {
            return "Joueur n" + NumJoueur + " Prenom : " + Prenom + " Nom : " + Nom;
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