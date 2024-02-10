using ProjetoMaluco.Entities.Usuarios;
using ProjetoMaluco.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        //Flag Controle de Validação
        bool flag;
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
            else
            {
                MessageBox.Show("'Senha ou Usuário' não são válidos, preencha com Usuário e Senha válidos", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
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
            if (string.IsNullOrEmpty(TxtBoxUser.Text) || string.IsNullOrEmpty(TxtBoxPass.Password))
            {
                MessageBox.Show("'Senha ou Usuário' não são válidos, preencha com Usuário e Senha válidos", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                
                var logon = DataService.Select<Usuario>($"SELECT id_user,db_user,db_passwd FROM db_users WHERE db_user='{TxtBoxUser.Text}' AND db_passwd='{TxtBoxPass.Password}'");
                
                if (logon.Count > 0)
                {
                    flag = true;
                    
                }
                return flag;
            }
        }
        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja Sair?", "Atenção", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
            else
            {
                TxtBoxUser.Text = string.Empty;
                TxtBoxPass.Password = string.Empty;
            }
        }
    }
}

