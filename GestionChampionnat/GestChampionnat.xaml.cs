using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace GestionChampionnat
{
    /// <summary>
    /// Interaction logic for GestChampionnat.xaml
    /// </summary>
    public partial class GestChampionnat : Window
    {
        private AWBB awbb = null;
        private readonly Settings set1 = new Settings();
        public GestChampionnat()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing); // pour gerer la croix de base
            set1.SettingCompleted += SettingForm_SettingCompleted;
            DataContext = awbb;
        }
        public GestChampionnat(AWBB a)
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing); // pour gerer la croix de base
            set1.SettingCompleted += SettingForm_SettingCompleted;
            awbb = a;
            DataContext = awbb;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) // pour gerer la croix de base
        {
            ResetChamp();
            e.Cancel = true;
            this.Hide();
        }

        private void BtnQuitter_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
            ResetChamp();
        }
        private void BtnBackSelectChamp_OnClick(object sender, RoutedEventArgs e)
        {
            ResetChamp();
            Hide();
        }
        private void SettingForm_SettingCompleted(object sender, OptionEventArgs e)
        {
            if (sender is Settings)
            {
                dgClassement.FontSize = e.Taille;
                dgMatch.FontSize = e.Taille;
                gridMain.Background = new SolidColorBrush(Color.FromRgb(e.Color.R, e.Color.G, e.Color.B));
            }
        }
        private void BtnAccess_OnClick(object sender, RoutedEventArgs e)
        {
            set1.ShowDialog();
            set1.Focus();
        }

        private void BtnJouer_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgMatch.SelectedItem != null && Int32.Parse(tbScoreLocal.Text) >= 0 && Int32.Parse(tbScoreExterieur.Text) >= 0 && !awbb.CurrentChampionnat.CurrentMatch.Played)
                {
                    awbb.CurrentChampionnat.PlayMatch(awbb.CurrentChampionnat.CurrentMatch, Int32.Parse(tbScoreLocal.Text), Int32.Parse(tbScoreExterieur.Text));
                    ResetChamp();
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un match qui n\'a pas encore été joué et mettre des informations correctes.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez entrez des données correctes", "Erreur d'encodage", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            
        }

        // pour verifier que l'utilisateur ne tape que des chiffres dans les textbox des scores
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!char.IsDigit(ch))
                {
                    e.Handled = true; // Bloque les caractères non numériques
                    break;
                }
            }
        }

        private void ResetChamp()
        {
            tbScoreLocal.Text = "";
            tbScoreExterieur.Text = "";
        }

    }
}
