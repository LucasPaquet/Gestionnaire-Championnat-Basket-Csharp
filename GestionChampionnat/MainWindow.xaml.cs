using GestionChampionnat.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClasseBasket;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;

namespace GestionChampionnat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AWBB awbb = null;
        private readonly CreationChampionnat creationChampionnat = null;
        private readonly GestChampionnat gestChampionnat = null;
        private readonly ModifClub modifClub = null;
        private bool IsClosing = false; // Permet de fermer complement l'application

        private const string RegistryKeyPath = "Software\\WindowPositionApp";
        private const string LeftRegistryValue = "Left";
        private const string TopRegistryValue = "Top";

        public MainWindow()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing); // pour gerer la croix de base

            string cheminFichier = GetCheminFichier();
            
            if (!string.IsNullOrEmpty(cheminFichier) && File.Exists(cheminFichier))
                awbb = AWBB.Load(cheminFichier);
            else
                awbb = new AWBB();
            /*
            //pour le test fichier en binaire
            if (File.Exists("awbb.dat"))
                awbb = Serializers.Deserialize("awbb.dat");
            else
                awbb = new AWBB();
            */

            DataContext = awbb;
            modifClub = new ModifClub(awbb);
            creationChampionnat = new CreationChampionnat(awbb);
            gestChampionnat = new GestChampionnat(awbb);
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.IsClosing)
            {
                // La fenêtre est déjà en cours de fermeture, ne rien faire
                return;
            }

            // Définir IsClosing sur true pour indiquer que la fenêtre est en cours de fermeture
            this.IsClosing = true;

            // Demandez à l'utilisateur s'il veut vraiment fermer l'application
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment fermer l'application ?", "Confirmation de fermeture", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                // Annuler la fermeture de l'application
                e.Cancel = true;

                // Réinitialiser IsClosing pour permettre une prochaine fermeture
                this.IsClosing = false;
            }
            else
            {
                // Terminer l'application
                string cheminFichier = GetCheminFichier();

                if (!string.IsNullOrEmpty(cheminFichier))
                {
                    // Terminer l'application en enregistrant les données dans le chemin spécifié
                    awbb.Save(cheminFichier);
                }
                else
                {
                    // Terminer l'application en enregistrant les données dans le fichier "awbb.xml" par défaut
                    awbb.Save("awbb.xml");
                }

                // Enregistrer la position de la fenêtre dans le registre avant de la fermer
                RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath);
                if (key != null)
                {
                    key.SetValue(LeftRegistryValue, Left);
                    key.SetValue(TopRegistryValue, Top);
                }

                //Serializers.Serialize(awbb, "awbb.dat"); // pour tester en binaire

                Application.Current.Shutdown();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Restaurer la position de la fenêtre depuis le registre
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath);
            if (key != null)
            {
                double left = Convert.ToDouble(key.GetValue(LeftRegistryValue));
                double top = Convert.ToDouble(key.GetValue(TopRegistryValue));

                Left = left;
                Top = top;
            }
        }


        private void BtnQuit_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.IsClosing)
            {
                // La fenêtre est déjà en cours de fermeture, ne rien faire
                return;
            }

            // Définir IsClosing sur true pour indiquer que la fenêtre est en cours de fermeture
            this.IsClosing = true;

            // Demandez à l'utilisateur s'il veut vraiment fermer l'application
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment fermer l'application ?", "Confirmation de fermeture", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                // Annuler la fermeture de l'application

                // Réinitialiser IsClosing pour permettre une prochaine fermeture
                this.IsClosing = false;
            }
            else
            {
                // Terminer l'application
                string cheminFichier = GetCheminFichier();

                if (!string.IsNullOrEmpty(cheminFichier))
                {
                    // Terminer l'application en enregistrant les données dans le chemin spécifié
                    awbb.Save(cheminFichier);
                }
                else
                {
                    // Terminer l'application en enregistrant les données dans le fichier "awbb.xml" par défaut
                    awbb.Save("awbb.xml");
                }

                // Enregistrer la position de la fenêtre dans le registre avant de la fermer
                RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath);
                if (key != null)
                {
                    key.SetValue(LeftRegistryValue, Left);
                    key.SetValue(TopRegistryValue, Top);
                }

                //Serializers.Serialize(awbb, "mesdonnee.dat"); // pour tester en binaire

                Application.Current.Shutdown();
            }
        }

        private void BtnCreateChamp_OnClick(object sender, RoutedEventArgs e)
        {
            creationChampionnat.ShowDialog();
            creationChampionnat.Focus();
        }
        private void LvChampionnat_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            gestChampionnat.ShowDialog();
            gestChampionnat.Focus();
        }

        private void LvClub_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            modifClub.ShowDialog();
            modifClub.Focus();
        }

        private void LbClub_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            modifClub.ShowDialog();
            modifClub.Focus();
            
            // awbb.Clubs[lbClub.SelectedIndex] = awbb.CurrentClub;
        }

        private void BtnCreateClub_OnClick(object sender, RoutedEventArgs e)
        {
            awbb.CurrentClub = new Club();
            modifClub.ShowDialog();
            modifClub.Focus();
            if (awbb.CurrentClub.Nom == "" || awbb.CurrentClub.Nom == null) // les deux conditions dans un cas si on tape rien c'est = null et si on tape puis qu'on supr = ""
            {
                MessageBox.Show("Le club n'a pas été ajouté car il n'avait pas de nom", "Club non ajouté", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                awbb.Clubs.Add(awbb.CurrentClub);
            }
            
        }


        private void BtnSuprChamp_OnClick(object sender, RoutedEventArgs e)
        {
            if (lvChampionnat.SelectedIndex != -1)
            {
                MessageBox.Show("Le championnat " + awbb.Championnats[lvChampionnat.SelectedIndex].Nom + " à été supprimer", "Confirmation de suppression", MessageBoxButton.OK, MessageBoxImage.Information);
                awbb.Championnats.RemoveAt(lvChampionnat.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Pas de championnat sélectionné", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSupprClub_OnClick(object sender, RoutedEventArgs e)
        {
            if (lbClub.SelectedIndex != -1)
            {
                MessageBox.Show("Le club " + awbb.Clubs[lbClub.SelectedIndex].Nom + " à été supprimer", "Confirmation de suppression", MessageBoxButton.OK, MessageBoxImage.Information);
                awbb.Clubs.RemoveAt(lbClub.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Pas de club sélectionné", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // recuperer le chemin ver le fichier awbb.xml
        private string GetCheminFichier()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(RegistryKeyPath);
            if (regKey != null)
            {
                string cheminFichier = regKey.GetValue("CheminFichier") as string;
                if (!string.IsNullOrEmpty(cheminFichier))
                    return cheminFichier;
            }

            return null;
        }
    }
}
