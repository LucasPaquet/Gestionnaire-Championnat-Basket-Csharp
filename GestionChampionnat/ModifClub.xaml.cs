using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using ClasseBasket;
using Microsoft.Win32;

namespace GestionChampionnat
{
    /// <summary>
    /// Interaction logic for ModifClub.xaml
    /// </summary>
    public partial class ModifClub : Window
    {
        private AWBB awbb = null;
        private readonly ModifEquipe modifEquipe = null;
        public ModifClub() // jamais utiliser
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing); // pour gerer la croix de base
            awbb = new AWBB();
            DataContext = awbb;
        }
        public ModifClub(AWBB a)
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing); // pour gerer la croix de base
            awbb = a;
            DataContext = awbb;
            modifEquipe = new ModifEquipe(awbb);
        }

        // pour gerer la croix de base
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (awbb.CurrentClub != null)
            {
                if (awbb.CurrentClub.Nom == "" || awbb.CurrentClub.Nom == null)
                {
                    MessageBoxResult result = MessageBox.Show("Le club ne va pas être créer car il ne contient pas de nom. Voulez-vous continuez ?", "Confirmation de fermeture", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No)
                    {
                        // Annuler la fermeture de l'application
                        e.Cancel = true;
                    }
                    else
                    {
                        // cacher l'interface
                        e.Cancel = true;
                        this.Hide();
                    }
                }
                else
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }


        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void BtnAddArbitre_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                awbb.CurrentClub.Arbitres.Add(new Arbitre(tbNomArbitre.Text, tbPrenom.Text, int.Parse(tbNum.Text)));
            }
            catch (Exception)
            {
                MessageBox.Show("Vous n'avez pas mis un bon numéro pour l'arbitre", "Erreur d'encodage", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void DgEquipe_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            modifEquipe.ShowDialog();
            modifEquipe.Focus();
        }

        private void BtnCreateEquipe_OnClick(object sender, RoutedEventArgs e)
        {
            awbb.CurrentClub.CurrentEquipe = new Equipe();
            modifEquipe.ResetChamp();
            modifEquipe.ShowDialog();
            modifEquipe.Focus();
            if (awbb.CurrentClub.CurrentEquipe.Nom == "" || awbb.CurrentClub.CurrentEquipe.Nom == null) // les deux conditions dans un cas si on tape rien c'est = null et si on tape puis qu'on supr = ""
            {
                MessageBox.Show("L'équipe n'a pas été ajouté car il n'avait pas de nom", "Équipe non ajouté", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                awbb.CurrentClub.Equipes.Add(awbb.CurrentClub.CurrentEquipe);
            }
        }

        private void BtnSearchImg_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers image|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;

                // Mettre à jour la propriété Img avec le chemin retourne
                awbb.CurrentClub.Img = selectedImagePath;
            }
        }

        private void BtnSuprEquipe_OnClick(object sender, RoutedEventArgs e)
        {
            if (dgEquipe.SelectedIndex != -1 && awbb.CurrentClub.Equipes.Count > dgEquipe.SelectedIndex) // pour verifier que l'utilisateur ne choissise pas la nouvelle ligne
            {
                MessageBox.Show("L'équipe " + awbb.CurrentClub.Equipes[dgEquipe.SelectedIndex].Nom + " à été supprimer", "Confirmation de suppression", MessageBoxButton.OK, MessageBoxImage.Information);
                awbb.CurrentClub.Equipes.RemoveAt(dgEquipe.SelectedIndex);

            }
            else
            {
                MessageBox.Show("Pas d'équipe sélectionné", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSuprArbitre_OnClick(object sender, RoutedEventArgs e)
        {
            if (dgArbitre.SelectedIndex != -1 && awbb.CurrentClub.Arbitres.Count > dgArbitre.SelectedIndex) // pour verifier que l'utilisateur ne choissise pas la nouvelle ligne
            {
                MessageBox.Show("L'arbitre " + awbb.CurrentClub.Arbitres[dgArbitre.SelectedIndex].Nom + dgArbitre.SelectedIndex + " à été supprimer", "Confirmation de suppression", MessageBoxButton.OK, MessageBoxImage.Information);
                awbb.CurrentClub.Arbitres.RemoveAt(dgArbitre.SelectedIndex);

            }
            else
            {
                MessageBox.Show("Pas d'arbitre sélectionné", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
