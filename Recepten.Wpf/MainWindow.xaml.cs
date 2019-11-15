using Microsoft.Win32;
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
using TextFileBeheer.Lib;

namespace Recepten.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int IndexFolder = 0;
        const int IndexFileName = 1;

        const string bestandenMap = @"../../Assets/";

        ReadFileService readService = new ReadFileService();

        string[] huidigBestand = new string[2];

        List<Encoding> karakterSet = new List<Encoding> { Encoding.Default, Encoding.UTF8, Encoding.GetEncoding("iso-8859-1") };
        List<string> karakterSetNamen = new List<string> { "Default", "UTF-8", "ANSI" };

        public MainWindow()
        {
            InitializeComponent();
        }

        void ToonMelding(string melding, bool isSucces = false)
        {
            tbkFeedback.Visibility = Visibility.Visible;
            tbkFeedback.Text = melding;
            tbkFeedback.Background = isSucces == true ?
                new SolidColorBrush(Color.FromRgb(0, 200, 0)) :
                new SolidColorBrush(Color.FromRgb(200, 0, 0));
        }

        void KoppelLijsten()
        {
            cmbEncoding.ItemsSource = karakterSetNamen;
        }

        private void BtnLeesBestand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string bestandsNaam = txtBestandsnaam.Text;
                txtTekst.Text = "";

                txtTekst.Text = readService.TextFileToString(bestandenMap, bestandsNaam);
                ToonMelding($"Bestand {bestandsNaam} werd succesvol gelezen", true);
            }
            catch (Exception ex)
            {
                ToonMelding(ex.Message);
            }
        }

        private void BtnKiesBestand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] gekozenBestand = readService.KiesBestand();
                txtTekst.Text = "";

                if (gekozenBestand != null)
                {
                    string bestandsInhoud = readService.TextFileToString(gekozenBestand[0], gekozenBestand[1]);

                    txtTekst.Text = bestandsInhoud;
                    txtBestandsnaam.Text = gekozenBestand[1];
                    huidigBestand = new string[] { gekozenBestand[0], gekozenBestand[1] };
                    ToonMelding($"Bestand {gekozenBestand[1]} werd succesvol gelezen", true);
                }
            }
            catch (Exception ex)
            {
                ToonMelding(ex.Message);
            }
        }

        private void BtnSchrijfBestand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tekst = txtTekst.Text;


            }
            catch (Exception ex)
            {
                ToonMelding(ex.Message);
            }
        }

        private void btnSchrijfBestandMetKeuze_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tekst = txtTekst.Text;

            }
            catch (Exception ex)
            {
                ToonMelding(ex.Message);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            KoppelLijsten();
            try
            {
                tbkFeedback.Visibility = Visibility.Hidden;
                txtTekst.Text = readService.TextFileToString(bestandenMap, "Le Maquis.txt");
                huidigBestand = new string[] { bestandenMap, "Le Maquis.txt" };
                txtBestandsnaam.Text = "Le Maquis ANSI.txt";

            }
            catch (Exception ex)
            {
                ToonMelding(ex.Message);
            }
        }
    }
}
