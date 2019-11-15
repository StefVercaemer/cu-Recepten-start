using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TextFileBeheer.Lib
{
    public class ReadFileService
    {

        public static string RootPad { get; } = AppDomain.CurrentDomain.BaseDirectory;
        public static string MyDocs { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public string TextFileToString(string bestandsMap, string bestandsNaam, Encoding karakterSet = null)
        {
            string bestandsInhoud = "";

            string bestandsPad = bestandsMap + "\\" + bestandsNaam;
            if (karakterSet == null)
            {
                karakterSet = Encoding.UTF8;
                // karakterSet = Encoding.GetEncoding("iso-8859-1");
                // karakterSet = Encoding.Default;
            }
            try
            {
                using (StreamReader sr = new StreamReader(bestandsPad, karakterSet))
                {
                    bestandsInhoud = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException($"Het bestand {bestandsPad} is niet gevonden.");
            }
            catch (IOException)
            {
                throw new IOException($"Het bestand {bestandsPad} kan niet geopend worden.\n" +
                              $"Probeer het te sluiten.");
            }
            catch (Exception e)
            {
                throw new Exception($"Er is een fout opgetreden. {e.Message}");
            }


            return bestandsInhoud;
        }

        public string[] KiesBestand(string filter = "Text documents (.txt)|*.txt|Comma seperated values (.csv)|*.csv")
        {
            string[] gekozenBestandsInfo = new string[2];
            string gekozenBestandsPad;
            int lastBackslashIndex;
            OpenFileDialog kiesBestand = new OpenFileDialog();
            //Enkel de bestanden met de doorgegeven extensie(s) worden getoond
            kiesBestand.Filter = filter;

            // Toon het dialoogvenster
            bool? result = kiesBestand.ShowDialog();
            //bool? betekent dat de boolean naast true en false ook de waarde null kan bevatten

            gekozenBestandsPad = kiesBestand.FileName;

            if (string.IsNullOrEmpty(gekozenBestandsPad.Trim()))
            {
                throw new Exception("Er is geen bestand gekozen");
            }
            else
            {
                lastBackslashIndex = gekozenBestandsPad.LastIndexOf('\\');
                gekozenBestandsInfo[0] = gekozenBestandsPad.Substring(0, lastBackslashIndex);
                gekozenBestandsInfo[1] = gekozenBestandsPad.Substring(lastBackslashIndex + 1);
            }

            return gekozenBestandsInfo;
        }
    }
}
