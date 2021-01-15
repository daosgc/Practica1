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

            // Validar que el dato ingresado en la casilla de cantidad sea el un entero positivo
            int totalProduct = 0;
            try
            {
                totalProduct = Int32.Parse(productSize);
                errorSize = totalProduct <= 0 ? "Ingresar un número mayor o igual a 1" : "";
                lblErrorSize.Content = errorSize;
            }
            catch (FormatException)
            {
                lblErrorSize.Content = "Número Invalido, solo se permiten enteros positivos.";
            }

            if (string.IsNullOrEmpty(errorName) && string.IsNullOrEmpty(errorSize)
                && string.IsNullOrEmpty(errorType) && string.IsNullOrEmpty(errorDistributor)
                && string.IsNullOrEmpty(errorDeliverAddress))
            {
                // Formateo de la data de pedido
                string windowTitle = "Pedido al distribuidor " + distributor;
                string unitFormat = totalProduct == 1 ? "unidad" : "unidades";
                string orderSummary = totalProduct + " " + unitFormat + " del " + productType + " " + productName;
                string fullAddress = "Para la farmacia situada en " + firstAddress;
                fullAddress = (chckBoxSecondary.IsChecked == true) ? fullAddress + " y la situada en " + secondAddress : fullAddress;

                // Abrimos la ventana del detalle del pedido
                Window1 window1 = new Window1(orderSummary, fullAddress);
                window1.Title = windowTitle;
                window1.Show();
            }
            
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
