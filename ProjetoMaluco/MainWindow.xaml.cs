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
using ProjetoMaluco.Entities.BuscaContratos;




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
            BuscaContratos buscar = new BuscaContratos();
            buscar.ShowDialog();

            //Busca os dados da Windows BuscarContratos e Popular o dgContratos da MainWindow
            if(buscar.ResultadosPesquisa != null && buscar.ResultadosPesquisa.Count > 0)
            {
                dgContratos.ItemsSource = buscar.ResultadosPesquisa;
            }
        }
    }
}