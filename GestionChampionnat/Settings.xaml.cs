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
using ClasseBasket;
using Microsoft.Win32;


namespace GestionChampionnat
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private const string RegistryKeyPath = "Software\\WindowPositionApp";

        public delegate void notify(object sender, OptionEventArgs e);
        public event notify SettingCompleted;
        public Settings()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing); // pour gerer la croix de base

        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) // pour gerer la croix de base
        {
            ResetChamp();
            e.Cancel = true;
            this.Hide();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void OnSettingChange(object sender, OptionEventArgs e)
        {
            SettingCompleted(this, e);
        }

        private bool SettingEvent()
        {
            try
            {
                if (SettingCompleted != null)
                {
                    OnSettingChange(this, new OptionEventArgs(int.Parse(TextBoxPolice.Text), new RGB(byte.Parse(TextBoxRouge.Text), byte.Parse(TextBoxVert.Text), byte.Parse(TextBoxBleue.Text))));
                }
                return true;
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Veuillez saisir une taille et une couleur correctes !");
            }
            return false;
        }

        private void BtnApply_OnClick(object sender, RoutedEventArgs e)
        {
            SettingEvent();
        }

        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            SettingEvent();
            Hide();
        }

        private void ResetChamp()
        {
            TextBoxRouge.Text = "";
            TextBoxVert.Text = "";
            TextBoxBleue.Text = "";
            tbCheminAcces.Text = "";
            TextBoxPolice.Text = "";
        }

        private void BtnChoisirChemin_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers XML (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == true)
            {
                // Chemin du fichier sélectionné
                string cheminFichier = openFileDialog.FileName;

                // Enregistrement du chemin dans l'éditeur de registre
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey(RegistryKeyPath);
                if (regKey != null)
                {
                    regKey.SetValue("CheminFichier", cheminFichier);
                }
                

                tbCheminAcces.Text = cheminFichier;
            }
        }

            /* Version "propre" mais marche pas car connais pas System.Windows.Forms

            private void BtnChoisirChemin_OnClick(object sender, RoutedEventArgs e)
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Répertoire sélectionné par l'utilisateur
                    string cheminRepertoire = folderBrowserDialog.SelectedPath;

                    // Chemin complet du fichier "awbb.xml"
                    string cheminFichier = Path.Combine(cheminRepertoire, "awbb.xml");

                    // Enregistrement du chemin dans l'éditeur de registre
                    RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                    regKey = regKey.CreateSubKey("MonApplication");
                    regKey.SetValue("CheminFichier", cheminFichier);

                    System.Windows.MessageBox.Show("Répertoire de stockage enregistré avec succès !");
                }
            }

            */


    }
}
