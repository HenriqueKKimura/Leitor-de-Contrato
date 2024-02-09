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

namespace ProjetoMaluco.Views
{
    /// <summary>
    /// Lógica interna para LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
            _ = TxtBoxUser.Focus();
        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            //Tratamento de Usuário e Senha
            string Usuario = TxtBoxUser.Text;
            Usuario = Usuario.Trim();
            string Senha = TxtBoxPass.Password;

            if (string.IsNullOrWhiteSpace(Usuario))
            {
                MessageBox.Show("'Usuário' é de preenchimento obrigatório", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(Senha))
            {
                MessageBox.Show("'Senha' é de preenchimento obrigatório", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Validação de Logon
            if (Usuario == "teste" & Senha == "1234")
            {
                Close();
            }
            else
            {
                MessageBox.Show("'Senha ou Usuário' não são válidos, preencha com Usuário e Senha validos", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
