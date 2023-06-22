using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClasseBasket
{
    [Serializable]
    public class Match : INotifyPropertyChanged
    {
        #region Variables membres

        private EquipeClassement _equipeLocal;
        private EquipeClassement _equipeExterieur;
        private DateTime _rencontre;
        private int _scoreLocal;
        private int _scoreExterieur;
        private Arbitre[] _arbitres;
        private Delegue[] _delegues;
        private bool _played;

       


        #endregion

        #region Propriete

        public EquipeClassement EquipeLocal
        {
            set
            {
                if (_equipeLocal == value) return;
                _equipeLocal = value;
                OnPropertyChanged();
            }
            get { return _equipeLocal; }
        }

        public EquipeClassement EquipeExterieur
        {
            get { return _equipeExterieur; }
            set
            {
                if (_equipeExterieur == value) return;
                _equipeExterieur = value;
                OnPropertyChanged();
            }
        }

        public DateTime Rencontre
        {
            get { return _rencontre; }
            set
            {
                if (_rencontre == value) return;
                _rencontre = value;
                OnPropertyChanged();
            }
        }
        public bool Played
        {
            get { return _played; }
            set
            {
                if (_played == value) return;
                _played = value;
                OnPropertyChanged();
            }
        }


        public Delegue[] Delegues
        {
            get { return _delegues; }
            set
            {
                if (_delegues == value) return;
                _delegues = value;
                OnPropertyChanged();
            }
        }


        public Arbitre[] Arbitres
        {
            get { return _arbitres; }
            set
            {
                if (_arbitres == value) return;
                _arbitres = value;
                OnPropertyChanged();
            }
        }


        public int ScoreExterieur
        {
            get { return _scoreExterieur; }
            set
            {
                if (_scoreExterieur == value) return;
                _scoreExterieur = value;
                OnPropertyChanged();
            }
        }


        public int ScoreLocal
        {
            get { return _scoreLocal; }
            set
            {
                if (_scoreLocal == value) return;
                _scoreLocal = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructeur

        public Match(EquipeClassement equipeLocal, EquipeClassement equipeExterieur, DateTime rencontre)
        {
            EquipeLocal = equipeLocal;
            EquipeExterieur = equipeExterieur;
            Rencontre = rencontre;
            Played = false;
        }

        public Match()
        {
            // poour le serial
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