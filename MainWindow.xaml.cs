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

            // Validar que el formulario este lleno con todos los campos.
            string commonInputError = "Por favor ingresar un valor.";
            string commonSelectionError = "Por favor seleccione un valor.";
            string errorName = string.IsNullOrEmpty(productName) ? commonInputError : "";
            lblErrorName.Content = errorName;
            string errorSize = string.IsNullOrEmpty(productSize) ? commonInputError : "";
            lblErrorSize.Content = errorSize;
            string errorType = string.IsNullOrEmpty(productType) ? commonSelectionError : "";
            lblErrorType.Content = errorType;
            string errorDistributor = string.IsNullOrEmpty(distributor) ? commonSelectionError : "";
            lblErrorDistributor.Content = errorDistributor;
            string errorDeliverAddress = (chckBoxPrincipal.IsChecked == true || chckBoxSecondary.IsChecked == true) ? "" : commonSelectionError;
            lblErrorDeliverAddress.Content = errorDeliverAddress;

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
            lblErrorName.Content = "";
            lblErrorSize.Content = "";
            lblErrorType.Content = "";
            lblErrorDistributor.Content = "";
            lblErrorDeliverAddress.Content = "";
        }
    }
}
