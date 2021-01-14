using System;
using System.Windows;

namespace Practica1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener valores del formulario
            string productName = txtBxName.Text;
            string productSize = txtBxSize.Text;
            string productType = cmbBoxType.SelectedIndex >= 0 ? cmbBoxType.Text : "";
            string firstAddress = chckBoxPrincipal.IsChecked == true ? "Calle de la Rosa n. 28 " : "";
            string secondAddress = chckBoxSecondary.IsChecked == true ? "Calle Alcazabilla n. 3" : "";
            string distributor = "";
            if (rdBtn1.IsChecked == true)
            {
                distributor = rdBtn1.Content.ToString();
            }
            else if (rdBtn2.IsChecked == true)
            {
                distributor = rdBtn2.Content.ToString();
            }
            else if (rdBtn3.IsChecked == true)
            {
                distributor = rdBtn3.Content.ToString();
            }
            Console.WriteLine("productName->"+productName);
            Console.WriteLine("productSize->" + productSize);
            Console.WriteLine("productType->" + productType);
            Console.WriteLine("address->" + firstAddress + secondAddress);
            Console.WriteLine("distributor->" + distributor);
            //Window1 window1 = new Window1();
            //window1.Show();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtBxName.Clear();
            txtBxSize.Clear();
            cmbBoxType.SelectedIndex = -1;
            chckBoxPrincipal.IsChecked = false;
            chckBoxSecondary.IsChecked = false;
            rdBtn1.IsChecked = false;
            rdBtn2.IsChecked = false;
            rdBtn3.IsChecked = false;
        }
    }
}
