using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace ClasseBasket
{
    [Serializable]
    public class AWBB : INotifyPropertyChanged // implementer Inotify 
    {
        #region Variables membres

        private ObservableCollection<Championnat> _championnats;
        private ObservableCollection<Club> _clubs;
        private Championnat _currentChampionnat;
        private Club _currentClub;

        #endregion

        #region Propriete

        public ObservableCollection<Championnat> Championnats
        {
            get { return _championnats; }
            set
            {
                if (_championnats == value) return;
                _championnats = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Club> Clubs
        {
            get { return _clubs; }
            set
            {
                if (_clubs == value) return;
                _clubs = value;
                OnPropertyChanged();
            }
        }

        public Championnat CurrentChampionnat
        {
            get { return _currentChampionnat; }
            set
            {
                if (_currentChampionnat == value) return;
                _currentChampionnat = value;
                OnPropertyChanged();
            }
        }

        public Club CurrentClub
        {
            get { return _currentClub; }
            set
            {
                if (_currentClub == value) return;
                _currentClub = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructeur

        public AWBB()
        {
            _clubs = new ObservableCollection<Club>();
            _championnats = new ObservableCollection<Championnat>();
        }

        #endregion

        #region Methodes
        /// <summary>
        /// Retourne un vecteur de 5 delegues choisit aleatoirement, trois de l'equipe local et deux de l'equipe exterieur
        /// </summary>
        /// <param name="equipeLocal">ClasseGestionBasket.Equipe locale</param>
        /// <param name="equipeExterieur">ClasseGestionBasket.Equipe exterieur</param>
        /// <returns>ClasseGestionBasket.Delegue[5] Retourne un vecteur de 5 delegues</returns>
        public Delegue[] FindDelegues(EquipeClassement equipeLocal, EquipeClassement equipeExterieur)
        {
            Delegue[] delegues = new Delegue[5];
            Random rand = new Random();
            int nombreAleatoireExterieur;
            int nombreAleatoireLocal;

            nombreAleatoireLocal = rand.Next(equipeLocal.Equipe.Delegues.Count - 2);
            nombreAleatoireExterieur = rand.Next(equipeExterieur.Equipe.Delegues.Count - 1);

            for (int i = 0; i < 3; i++)
            {
                delegues[i] = equipeLocal.Equipe.Delegues[nombreAleatoireLocal + i];
            }

            for (int i = 3; i < 5; i++)
            {
                delegues[i] = equipeExterieur.Equipe.Delegues[nombreAleatoireExterieur + i - 3];
            }

            return delegues;
        }
        /// <summary>
        /// Retourne un vecteur de deux arbitres choisit aleatoirement qui sont differents et qui ne viennent pas du meme club que des deux equipes passe en parametre
        /// </summary>
        /// <param name="equipeLocal">ClasseGestionBasket.Equipe locale</param>
        /// <param name="equipeExterieur">ClasseGestionBasket.Equipe Exterieur</param>
        /// <returns>ClasseGestionBasket.Arbitre[2] Retourne un vecteur de deux arbitres</returns>
        public Arbitre[] FindArbitres(EquipeClassement equipeLocal, EquipeClassement equipeExterieur) 
        {
            // !!! fonction à retravailler car il peut avoir deux fois le même arbitres
            Arbitre[] arbitres = new Arbitre[2];
            Random rand = new Random();
            int nombreAleatoire, find, nombreAleatoire2;
            Arbitre tmpArbitre;

            for (int i = 0; i < 2; i++)
            {
                do
                {
                    find = 0;
                    nombreAleatoire = rand.Next(Clubs.Count);
                    for (int j = 0; j < Clubs[nombreAleatoire].Equipes.Count; j++)
                    {
                        if (equipeLocal.Equals(Clubs[nombreAleatoire].Equipes[j]) || equipeExterieur.Equals(Clubs[nombreAleatoire].Equipes[j]))
                        {
                            find = 1;
                            break;
                        }
                    }
                } while (find == 1);

                do
                {
                    nombreAleatoire2 = rand.Next(Clubs[nombreAleatoire].Arbitres.Count);
                    tmpArbitre = Clubs[nombreAleatoire].Arbitres[nombreAleatoire2];
                } while (tmpArbitre.Equals(arbitres[0]) && tmpArbitre.Equals(arbitres[1]));

                arbitres[i] = tmpArbitre;
            }
            return arbitres;
        }
        /// <summary>
        /// Permet d'attribuer a tous les matchs d'un championnat des arbitres
        /// </summary>
        /// <param name="championnat">ClasseGestionBasket.Championnat dont on veut mettre des arbitres</param>
        public void AttribuerArbitreAllMatch(Championnat championnat)
        {
            Match mt;
            for (int i = 0; i < championnat.Matches.Count; i++)
            {
                mt = championnat.Matches[i];

                mt.Arbitres = FindArbitres(mt.EquipeLocal, mt.EquipeExterieur); // on definit deux arbitre a chaque match
            }
        }
        /// <summary>
        /// Permet d'attribuer a tous les matchs d'un championnat des delegues
        /// </summary>
        /// <param name="championnat"></param>
        public void AttribuerDelegueAllMatch(Championnat championnat)
        {
            Match mt;
            for (int i = 0; i < championnat.Matches.Count; i++)
            {
                mt = championnat.Matches[i];

                mt.Delegues = FindDelegues(mt.EquipeLocal, mt.EquipeExterieur); // on definit deux arbitre a chaque match
            }
        }

        public void CreateChampionnat(String nom, int niveau, int categorie, List<String> equipesList)
        {
            ObservableCollection<Equipe> equipes = new ObservableCollection<Equipe>();

            for (int i = 0; i < Clubs.Count; i++) // boucle tout les clubs dans la AWBB
            {
                for (int j = 0;
                     j < Clubs[i].Equipes.Count;
                     j++) // pour chaque clubs dans la AWBB, BOUCLE toute les equipes du club
                {
                    if (Clubs[i].Equipes[j].Niveau == niveau) // si le niveau (poussin,P4,D3) == l'index selection
                    {
                        if (Clubs[i].Equipes[j].Categorie == 0)
                        {
                            foreach (String equipe in equipesList)
                            {
                                if (equipe == Clubs[i].Equipes[j].Nom)
                                {
                                    equipes.Add(Clubs[i].Equipes[j]);
                                    break;
                                }
                            }

                            
                        }
                        else
                        {
                            if (Clubs[i].Equipes[j].Categorie == (categorie + 1))
                            {
                                equipes.Add(Clubs[i].Equipes[j]);
                            }
                        }

                    }
                }
            }

            Championnats.Add(new Championnat(nom,equipes));
            Championnats.Last().GenerateMatches();
        }



        public void Save(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AWBB));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fileStream, this);
            }
        }

        public static AWBB Load(string fileName)
        {
            AWBB instance = null;
            XmlSerializer serializer = new XmlSerializer(typeof(AWBB));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                instance = (AWBB)serializer.Deserialize(fileStream);
            }
            return instance;
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