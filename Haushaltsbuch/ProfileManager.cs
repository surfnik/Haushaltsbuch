using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows;

namespace Haushaltsbuch
{
    static internal class ProfileManager
    {
        public static Profile CurrentProfile { get; private set; }

        public static void CreateProfile(string name, decimal balance)
        {
            CurrentProfile = new Profile(name, balance);
            SaveProfile(CurrentProfile);
        }

        public static void SaveProfile(Profile profile)
        {
            string filepath = AppContext.BaseDirectory + profile.Name + ".prof";
            BinaryFormatter binFormatter = new BinaryFormatter();

            try
            {
                using (FileStream stream = new FileStream(filepath, FileMode.Create))
                {
                    binFormatter.Serialize(stream, profile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Speicherfehler", MessageBoxButton.OK, MessageBoxImage.Error);
                // MessageBox.Show("Fehler beim speichern des Profile.", "Speicherfehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void LoadProfile(string profilePath)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();

            try
            {
                using (FileStream stream = new FileStream(profilePath, FileMode.Open))
                {
                    CurrentProfile = (Profile)binFormatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dateifehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
