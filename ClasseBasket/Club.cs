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
    public class Club : INotifyPropertyChanged
    {
        #region Variables membres

        private String _nom;
        private String _adresse;
        private String _img;
        private ObservableCollection<Equipe> _equipes;
        private ObservableCollection<Arbitre> _arbitres;
        private Equipe _currentEquipe;

        #endregion

        #region Proprietes

        public String Nom
        {
            get { return _nom; }
            set 
            {
                if (_nom == value) return;
                _nom = value;
                OnPropertyChanged();
            }
        }

        public String Adresse
        {
            get { return _adresse; }
            set
            {
                if (_adresse == value) return;
                _adresse = value;
                OnPropertyChanged();
            }
        }

        public String Img
        {
            get { return _img; }
            set
            {
                if (_img == value) return;
                _img = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Equipe> Equipes
        {
            get { return _equipes; }
            set
            {
                if (_equipes == value) return;
                _equipes = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Arbitre> Arbitres
        {
            get { return _arbitres; }
            set
            {
                if (_arbitres == value) return;
                _arbitres = value;
                OnPropertyChanged();
            }
        }

        public Equipe CurrentEquipe
        {
            get { return _currentEquipe; }
            set
            {
                if (_currentEquipe == value) return;
                _currentEquipe = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructeur

        public Club(String nom, String adresse)
        {
            Nom = nom;
            Adresse = adresse;
            _arbitres = new ObservableCollection<Arbitre>();
            _equipes = new ObservableCollection<Equipe>();
            _arbitres = new ObservableCollection<Arbitre>();
        }
        public Club(String nom, String adresse, String img)
        {
            Nom = nom;
            Adresse = adresse;
            Img = img;
            _arbitres = new ObservableCollection<Arbitre>();
            _equipes = new ObservableCollection<Equipe>();
            _arbitres = new ObservableCollection<Arbitre>();
        }
        public Club()
        {
            // pour la serial
            _arbitres = new ObservableCollection<Arbitre>();
            _equipes = new ObservableCollection<Equipe>();
            _arbitres = new ObservableCollection<Arbitre>();
        }

        #endregion

        #region Surchage des operateurs

        public override string ToString()
        {
            String sEquipe = "";
            String sArbitre = "";
            if (Equipes != null)
            {
                for (int i = 0; i < Equipes.Count; i++)
                {
                    sEquipe = sEquipe + Equipes[i].ToString() + "\n";
                }
            }
            if (Arbitres != null)
            {
                for (int i = 0; i < Arbitres.Count; i++)
                {
                    sArbitre = sArbitre + Arbitres[i].ToString() + "\n";
                }
            }

            return "Nom : " + Nom + ", Adresse  " + Adresse + "\nEquipe : \n" + sEquipe + "\n" + "\nArbitre : \n" + sArbitre;


        }

        #endregion

        #region Methodes

        public void Save(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Club));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fileStream, this);
            }
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