using System.Windows;
using ProjetoMaluco.Entities;
using ProjetoMaluco.Views;



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
    }
}