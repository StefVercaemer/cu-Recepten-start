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
        public string Foutmelding { get; private set; }

        public string TextFile_To_String(string bestandsPad, Encoding karakterSet = null)
        {
            string bestandsInhoud = "";
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
                Foutmelding = "";
            }
            catch (FileNotFoundException)
            {
                Foutmelding = $"Het bestand {bestandsPad} is niet gevonden.";
            }
            catch (IOException)
            {
                Foutmelding = $"Het bestand {bestandsPad} kan niet geopend worden.\n" +
                              $"Probeer het te sluiten.";
            }
            catch (Exception e)
            {
                Foutmelding = $"Er is een fout opgetreden. {e.Message}";
            }


            return bestandsInhoud;
        }
    }
}
