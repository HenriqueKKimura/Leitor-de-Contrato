using System.Windows;
using ProjetoMaluco.Views;
using CsvHelper;
using Microsoft.Win32;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
using System.Windows.Controls;
using ProjetoMaluco.Services;
using ProjetoMaluco.Entities.ArquivoImportado;




namespace ProjetoMaluco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            LoginScreen loginscren = new LoginScreen();
            loginscren.ShowDialog();

            InitializeComponent();
        }

        private void BtnImportar_Click(object sender, RoutedEventArgs e)
        {
            ImportaContratos importacontratos = new ImportaContratos();
            importacontratos.ShowDialog();
        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtboxcpf.Text))
            {

                var Contrato = DataService.Select<ArquivoImportado>($"SELECT * FROM db_contratos WHERE db_cpf= '{txtboxcpf.Text}'").FirstOrDefault(); 
            }
        }
    }
}