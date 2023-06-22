using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClasseBasket
{
    [Serializable]
    public abstract class Personne : INotifyPropertyChanged
    {
        #region Variables membres

        private string _nom;
        private string _prenom;

        #endregion

        #region Propriétés

        public string Nom
        {
            set
            {
                if (_nom == value) return;
                _nom = value;
                OnPropertyChanged();
            }
            get { return _nom; }
        }

        public string Prenom
        {
            set
            {
                if (_prenom == value) return;
                _prenom = value;
                OnPropertyChanged();
            }
            get { return _prenom; }
        }

        #endregion

        #region Constructeur

        public Personne(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        public Personne()
        {
            Nom = "Sans nom";
            Prenom = "Sans Prenom";
        }

        #endregion

        #region SURCHAGES DES OPERATEURS

        public override string ToString()
        {
            return "(" + Nom + "," + Prenom + ")";
        }

        #endregion

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
    }
}

