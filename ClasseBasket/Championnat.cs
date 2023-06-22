using ClasseBasket;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClasseBasket 
{
    [Serializable]

    public class Championnat : INotifyPropertyChanged
    {
        #region Variables membres

        private String _nom;
        private ObservableCollection<EquipeClassement> _equipes;
        private ObservableCollection<Match> _matches;
        private Match _currentMatch;

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

        public ObservableCollection<EquipeClassement> Equipes
        {
            get { return _equipes; }
            set
            {
                if (_equipes == value) return;
                _equipes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Match> Matches
        {
            get { return _matches; }
            set
            {
                if (_matches == value) return;
                _matches = value;
                OnPropertyChanged();
            }
        }

        public Match CurrentMatch
        {
            get { return _currentMatch; }
            set
            {
                if (_currentMatch == value) return;
                _currentMatch = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructeur

        public Championnat(String nom, ObservableCollection<Equipe> equipes)
        {
            _nom = nom;
            _equipes = new ObservableCollection<EquipeClassement>();
            _matches = new ObservableCollection<Match>();
            for (int i = 0; i < equipes.Count; i++)
            {
                Equipes.Add(new EquipeClassement(equipes[i]));
            }
        }

        public Championnat()
        {
            _equipes = new ObservableCollection<EquipeClassement>();
            _matches = new ObservableCollection<Match>();
        }
        

        #endregion

        public void Save(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Championnat));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fileStream, this);
            }
        }

        public static Championnat Load(string fileName)
        {
            Championnat instance = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Championnat));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                instance = (Championnat)serializer.Deserialize(fileStream);
            }
            return instance;
        }

        /// <summary>
        /// Methode qui permet de jouer un match et de mettre a jour le classement
        /// </summary>
        /// <param name="m">L'object match jouer</param>
        /// <param name="scoreLocal">Score de l'equipe local</param>
        /// <param name="scoreExterieur">Score de l'equipe exterieur</param>
        public void PlayMatch(Match m, int scoreLocal, int scoreExterieur)
        {

            // maj des scores dans le ClasseGestionBasket.Match
            m.ScoreLocal = scoreLocal;
            m.ScoreExterieur = scoreExterieur;

            if (scoreLocal > scoreExterieur)
            {
                // Local gagne
                m.EquipeLocal.AjouteVictoire();
                m.EquipeExterieur.AjouteDefaite();
            }
            else if (scoreLocal < scoreExterieur)
            {
                // Local Perd
                m.EquipeLocal.AjouteDefaite();
                m.EquipeExterieur.AjouteVictoire();
            }
            else
            {
                // egalite
                m.EquipeLocal.AjouteEgalite();
                m.EquipeExterieur.AjouteEgalite();
            }

            m.Played = true;

            
        }
        public void GenerateMatches()
        {
            Delegue[] delegues = new Delegue[5];
            Arbitre[] arbitres = new Arbitre[2];

            DateTime currentDate = DateTime.Now.Date;
            DateTime nextSaturday = currentDate.AddDays(DayOfWeek.Saturday - currentDate.DayOfWeek);
            DateTime nextSunday = currentDate.AddDays(DayOfWeek.Sunday - currentDate.DayOfWeek);

            int matchesPerWeekend = 4;
            int matchesCount = 0;

            for (int i = 0; i < Equipes.Count - 1; i++)
            {
                for (int j = i + 1; j < Equipes.Count; j++)
                {
                    DateTime matchDate = GetNextMatchDate(nextSaturday, nextSunday);
                    Matches.Add(new Match(Equipes[i], Equipes[j], matchDate));

                    matchesCount++;
                    if (matchesCount >= matchesPerWeekend)
                    {
                        nextSaturday = matchDate.AddDays(7);
                        nextSunday = matchDate.AddDays(8);
                        matchesCount = 0;
                    }
                }
            }
        }

        private DateTime GetNextMatchDate(DateTime nextSaturday, DateTime nextSunday)
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime nextMatchDate = nextSaturday;

            if (currentDate > nextSunday)
            {
                nextMatchDate = nextSaturday.AddDays(7);
            }

            return nextMatchDate;
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