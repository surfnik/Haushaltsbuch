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

namespace Haushaltsbuch
{
    /// <summary>
    /// Interaktionslogik für NewProfile.xaml
    /// </summary>
    public partial class NewProfile : Window
    {
        public NewProfile()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string name = "";
            decimal balance = 0;
            bool inputOk = true;
            try
            {
            name = txtName.Text;
                if (name == "") 
                { 
                    MessageBox.Show("Name darf nicht leer sein!", "Leerer Name", MessageBoxButton.OK, MessageBoxImage.Error); 
                    inputOk = false;
                }
            balance = Convert.ToDecimal(txtAmmount.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Speicherfehler", MessageBoxButton.OK, MessageBoxImage.Error);
                inputOk = false;
            }
            ProfileManager.CreateProfile(name, balance);

            if (inputOk)
            {
            this.Close();
            }
        }
    }
}
