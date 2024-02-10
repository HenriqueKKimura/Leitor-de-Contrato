using System.Windows;
using ProjetoMaluco.Entities;
using ProjetoMaluco.Views;
using CsvHelper;
using Microsoft.Win32;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
using System.Windows.Controls;




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
    }
}