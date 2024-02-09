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
            string usuario = TxtBoxUser.Text;
            usuario = usuario.Trim();
            string senha = TxtBoxPass.Password;

            //Chamar Função de Validação
            bool loginValido = ValidaLogin(usuario, senha);
            if (loginValido)
            {
                Close();
            }

        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {

        }


        //Função Validação Login
        public bool ValidaLogin(string usuario, string senha)
        {
            // Validações de campo vazio
            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("'Usuário' é de preenchimento obrigatório", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("'Senha' é de preenchimento obrigatório", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Validação de login
            if (usuario == "teste" && senha == "1234")
            {
                return true;
            }
            else
            {
                MessageBox.Show("'Senha ou Usuário' não são válidos, preencha com Usuário e Senha válidos", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


        }



    }
}
