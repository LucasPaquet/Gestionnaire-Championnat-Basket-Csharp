using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClasseBasket
{
    [Serializable]
    public class Equipe : INotifyPropertyChanged
    {
        #region Varaibles membres

        private ObservableCollection<Joueur> _joueurs;
        private ObservableCollection<Delegue> _delegues;
        private Coach _entraineur;
        private string _nom; // par défaut nom club + niveau
        private int _niveau;
        private int _categorie;

        #endregion

        #region Propriete

        public ObservableCollection<Joueur> Joueurs
        {
            set
            {
                if (_joueurs == value) return;
                _joueurs = value;
                OnPropertyChanged();
            }
            get { return _joueurs; }
        }

        public ObservableCollection<Delegue> Delegues
        {
            set
            {
                if (_delegues == value) return;
                _delegues = value;
                OnPropertyChanged();
            }
            get { return _delegues; }
        }

        public Coach Entraineur
        {
            set
            {
                if (_entraineur == value) return;
                _entraineur = value;
                OnPropertyChanged();
            }
            get { return _entraineur; }
        }

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

        public int Niveau
        {
            set
            {
                if (_niveau == value) return;
                _niveau = value;
                OnPropertyChanged();
            }
            get { return _niveau; }
        }

        public int Categorie
        {
            get { return _categorie; }
            set
            {
                if (_categorie == value) return;
                _categorie = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructeur

        public Equipe(Coach entraineur, string nom, int niveau, int categorie)
        {
            _joueurs = new ObservableCollection<Joueur>();
            _delegues = new ObservableCollection<Delegue>();
            Entraineur = entraineur;
            Nom = nom;
            Niveau = niveau;
            Categorie = categorie;
        }

        public Equipe()
        {
            // C'est pour pouvoir serialiser la classe ()
            _joueurs = new ObservableCollection<Joueur>();
            _delegues = new ObservableCollection<Delegue>();
            _entraineur = new Coach("Sans nom", "Sans prénom", 0);
        }

        #endregion

        public override string ToString()
        {
            String sJoueur = "\n";
            if (Joueurs != null)
            {
                for (int i = 0; i < Joueurs.Count; i++)
                {
                    sJoueur = sJoueur + Joueurs[i].ToString() + "\n";
                }
                return Nom + " : Coach -> " + Entraineur.ToString() + ", Niveau " + Niveau + "\n\n" + sJoueur;
            }
            else
            {
                return Nom + " : Coach -> " + Entraineur.ToString() + "&&&     Niveau  " + Niveau + " et pas de joueurs ";
            }

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
    }
}