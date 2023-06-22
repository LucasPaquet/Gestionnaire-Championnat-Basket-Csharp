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
using Microsoft.SqlServer.Server;

namespace GestionChampionnat
{
    /// <summary>
    /// Interaction logic for CreationChampionnat.xaml
    /// </summary>
    public partial class CreationChampionnat : Window
    {
        private readonly ObservableCollection<String> listEquipes = new ObservableCollection<String>();
        private AWBB awbb = null;

        // peut-être jamais utilisé
        public CreationChampionnat()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing); // pour gerer la croix de base
            lvEquipe.ItemsSource = listEquipes;


        }
        public CreationChampionnat(AWBB a)
        {
            InitializeComponent();
            awbb = a;
            lvEquipe.ItemsSource = listEquipes;
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing); // pour gerer la croix de base

        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            ResetChamp();
            Hide();
        }
        private void BtnReset_OnClick(object sender, RoutedEventArgs e)
        {
            ResetChamp();
        }

        /// <summary>
        /// Clear all field in the form
        /// </summary>
        private void ResetChamp()
        {
            // pour etre plus intuitif
            cbCat.Visibility = Visibility.Visible;
            tbCat.Visibility = Visibility.Visible;

            tbNom.Text = "";

            // Remettre les comboBox a blanc 
            cbCat.SelectedItem = null;
            cbNiveau.SelectedItem = null;

            listEquipes.Clear(); // on reset les comboBox dont plus d'equipe a afficher
        }


        private void CbNiveau_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Vérifier que la sélection est un ComboBoxItem
            if (cbNiveau.SelectedItem != null && cbNiveau.SelectedItem is ComboBoxItem item)
            {
                // Récupérer le contenu de l'élément sélectionné
                int content = cbNiveau.SelectedIndex;

                // Mettre à jour les contrôles d'interface utilisateur en fonction de la forme sélectionnée
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
                        break;
                    default:
                        cbCat.Visibility = Visibility.Visible;
                        tbCat.Visibility = Visibility.Visible;
                        break;

                }

                listEquipes.Clear(); // supr tout les elem de la list

                // boucle pour ajouter les equipes dans la liste en fonction du niveau
                for (int i = 0; i < awbb.Clubs.Count; i++) // boucle tout les clubs dans la AWBB
                {
                    for (int j = 0; j < awbb.Clubs[i].Equipes.Count; j++) // pour chaque clubs dans la AWBB, BOUCLE toute les equipes du club
                    {
                        if (awbb.Clubs[i].Equipes[j].Niveau == cbNiveau.SelectedIndex) // si le niveau (poussin,P4,D3) == l'index selection
                        {
                            if (awbb.Clubs[i].Equipes[j].Categorie == 0)
                            {
                                listEquipes.Add(awbb.Clubs[i].Equipes[j].Nom);
                            }
                            else
                            {
                                if (awbb.Clubs[i].Equipes[j].Categorie == (cbCat.SelectedIndex+1))
                                {
                                    listEquipes.Add(awbb.Clubs[i].Equipes[j].Nom);
                                }
                            }
                            
                        }
                    }
                }

            }
           
        }

        // pour gerer la croix de base
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) 
        {
            e.Cancel = true;
            ResetChamp();
            this.Hide();
        }

        private void CbCat_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCat.SelectedItem != null && cbCat.SelectedItem is ComboBoxItem item)
            {
                listEquipes.Clear(); // supr tout les elem de la list

                // boucle pour ajouter les equipes dans la liste en fonction du niveau
                for (int i = 0; i < awbb.Clubs.Count; i++) // boucle tout les clubs dans la AWBB
                {
                    for (int j = 0;
                         j < awbb.Clubs[i].Equipes.Count;
                         j++) // pour chaque clubs dans la AWBB, BOUCLE toute les equipes du club
                    {
                        if (awbb.Clubs[i].Equipes[j].Niveau == cbNiveau.SelectedIndex) // si le niveau (poussin,P4,D3) == l'index selection
                        {
                            if (awbb.Clubs[i].Equipes[j].Categorie == 0)
                            {
                                listEquipes.Add(awbb.Clubs[i].Equipes[j].Nom);
                            }
                            else
                            {
                                if (awbb.Clubs[i].Equipes[j].Categorie == (cbCat.SelectedIndex + 1))
                                {
                                    listEquipes.Add(awbb.Clubs[i].Equipes[j].Nom);
                                }
                            }

                        }
                    }
                }
                
            }
        }

        private void BtnCreateChamp_OnClick(object sender, RoutedEventArgs e)
        {
            if (lvEquipe.SelectedItems.Count == 8)
            {
                List<string> selectedEquipes = new List<string>();
                foreach (var item in lvEquipe.SelectedItems)
                {
                    string equipe = item.ToString();
                    selectedEquipes.Add(equipe);
                }

                awbb.CreateChampionnat(tbNom.Text, cbNiveau.SelectedIndex, cbCat.SelectedIndex, selectedEquipes);
                
                ResetChamp();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner exactement 8 équipes.");
            }
        }

    }
}
