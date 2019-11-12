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
        ReadFileService readFileService = new ReadFileService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLeesBestand_Click(object sender, RoutedEventArgs e)
        {
            string pad = @"../../Assets/" + txtBestandsnaam.Text;
            string tekst = readFileService.TextFile_To_String(pad, Encoding.GetEncoding("iso-8859-1"));
            txtArtikelen.Text = tekst;
            ToonFoutmelding();
        }

        private void BtnKiesBestand_Click(object sender, RoutedEventArgs e)
        {
            string pad = KiesBestand();
        }

        private void BtnSchrijfBestand_Click(object sender, RoutedEventArgs e)
        {
            string pad = @"../../Assets/Artikelen.csv";
            string bestandsNaam = txtBestandsnaam.Text;
            string tekst = txtArtikelen.Text;

        }

        private void btnSchrijfBestandMetKeuze_Click(object sender, RoutedEventArgs e)
        {
            string[] opslagInfo = new string[2];
            string pad = opslagInfo[0];
            string bestandsNaam = opslagInfo[1];
            string tekst = txtArtikelen.Text;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string pad = @"../../Assets/Artikelen.csv";
            string tekst = readFileService.TextFile_To_String(pad, Encoding.GetEncoding("iso-8859-1"));
            txtArtikelen.Text = tekst;
            txtBestandsnaam.Text = "personen.txt";
            ToonFoutmelding();
        }
        
        string KiesBestand(string filter = "Text documents (.txt)|*.txt|Comma seperated values (.csv)|*.csv")
        {
            string gekozenBestandsPad = "";
            OpenFileDialog kiesBestand = new OpenFileDialog { Filter = filter};
            bool? result = kiesBestand.ShowDialog();
            Console.WriteLine("Result: " + result);
            gekozenBestandsPad = kiesBestand.FileName;
            Console.WriteLine("Bestandsnaam: " + gekozenBestandsPad);
            return gekozenBestandsPad;
        }

        void ToonFoutmelding()
        {
            string foutmelding;
            foutmelding = readFileService.Foutmelding;
            tbkErrors.Visibility = Visibility.Hidden;
            if (!string.IsNullOrEmpty(foutmelding)) tbkErrors.Visibility = Visibility.Visible;
            tbkErrors.Text = foutmelding;

        }

        string[] GeefPadOmOpTeSlaan(string filter = "Text documents (.txt)|*.txt|Comma seperated values (.csv)|*.csv")
        {
            string[] bestandsInfo = new string[2];
            string pad, bestandsNaam, folder;

            return bestandsInfo;
        }



    }
}
