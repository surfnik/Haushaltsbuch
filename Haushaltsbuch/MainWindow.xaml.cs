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

namespace Haushaltsbuch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mnuNew_Click(object sender, RoutedEventArgs e)
        {
            lbl1.Content = "Neu";
        }

        private void mnuOpen_Click(object sender, RoutedEventArgs e)
        {
            //https://docs.microsoft.com/de-de/dotnet/desktop/wpf/windows/how-to-open-common-system-dialog-box?view=netdesktop-6.0
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            //dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".prof"; // Default file extension
            dialog.Filter = "Benutzerprofile (.prof)|*.prof"; // Filter files by extension
            // dialog.InitialDirectory ist noch zu 

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
            }
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
