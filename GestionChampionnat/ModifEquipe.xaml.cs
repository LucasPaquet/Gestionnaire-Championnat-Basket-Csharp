using ClasseBasket;
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
using System.Windows.Shapes;

namespace GestionChampionnat
{
    /// <summary>
    /// Interaction logic for ModifEquipe.xaml
    /// </summary>
    public partial class ModifEquipe : Window
    {
        private AWBB awbb = null;

        public ModifEquipe()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(ModifEquipe_Closing);
        }

        public ModifEquipe(AWBB a)
        {
            InitializeComponent();
            awbb = a;
            DataContext = awbb;
            this.Closing += new System.ComponentModel.CancelEventHandler(ModifEquipe_Closing);
        }

        private void ModifEquipe_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*
            if (awbb.CurrentClub.CurrentEquipe.Nom == "" || awbb.CurrentClub.CurrentEquipe.Nom == null)
            {
                MessageBoxResult result = MessageBox.Show("L'équipe ne va pas être créer car il ne contient pas de nom. Voulez-vous continuez ?", "Confirmation de fermeture", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    // Annuler la fermeture de l'application
                    e.Cancel = true;
                }
                else
                {
                    // cacher l'interface
                    this.Hide();
                }
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }*/
            e.Cancel = true;
            this.Hide();
        }

        private void BtnAddPeople_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rBtnJ.IsChecked == true)
                {
                    awbb.CurrentClub.CurrentEquipe.Joueurs.Add(new Joueur(tbNom.Text, tbPrenom.Text, int.Parse(tbNum.Text)));
                }
                else if (rBtnD.IsChecked == true)
                {
                    awbb.CurrentClub.CurrentEquipe.Delegues.Add(new Delegue(tbNom.Text, tbPrenom.Text, int.Parse(tbNum.Text)));
                }
                else
                {
                    MessageBox.Show("Vous n'avez mit le type de personne à ajouter !", "Erreur d'encodage", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vous n'avez pas mit un bon numéro", "Erreur d'encodage", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
           
        }

        private void CbCat_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            awbb.CurrentClub.CurrentEquipe.Categorie = cbCat.SelectedIndex + 1;
        }

        private void CbNiveau_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            awbb.CurrentClub.CurrentEquipe.Niveau = cbNiveau.SelectedIndex;
            int content = cbNiveau.SelectedIndex;
            switch (content)
            {
                case int n when (n >= -1 && n <= 4):
                    cbCat.Visibility = Visibility.Visible;
                    tbCat.Visibility = Visibility.Visible;
                    break;

                case int n when (n >= 5 && n <= 10):
                    cbCat.SelectedItem = null;
                    cbCat.Visibility = Visibility.Hidden;
                    tbCat.Visibility = Visibility.Hidden;
                    awbb.CurrentClub.CurrentEquipe.Categorie = 0;
                    break;
                default:
                    cbCat.Visibility = Visibility.Visible;
                    tbCat.Visibility = Visibility.Visible;
                    break;

            }
        }

        private void BtnSuprDelegue_OnClick(object sender, RoutedEventArgs e)
        {
            if (dgDelegue.SelectedIndex != -1 && awbb.CurrentClub.CurrentEquipe.Delegues.Count > dgDelegue.SelectedIndex) // pour verifier que l'utilisateur ne choissise pas la nouvelle ligne
            {
                awbb.CurrentClub.CurrentEquipe.Delegues.RemoveAt(dgDelegue.SelectedIndex);
                
            }
            else
            {
                MessageBox.Show("Pas de délégué sélectionné", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSuprJoueur_OnClick(object sender, RoutedEventArgs e)
        {
            if (dgJoueur.SelectedIndex != -1 && awbb.CurrentClub.CurrentEquipe.Joueurs.Count > dgJoueur.SelectedIndex)
            {
                awbb.CurrentClub.CurrentEquipe.Joueurs.RemoveAt(dgJoueur.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Pas de Joueur sélectionné", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ResetChamp()
        {
            cbCat.SelectedItem = null;
            cbNiveau.SelectedItem = null;

        }

        

    }
}