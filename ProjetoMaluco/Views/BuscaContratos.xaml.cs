using ProjetoMaluco.Services;
using System.Windows;
using ProjetoMaluco.Entities;
using ProjetoMaluco.Entities.BuscaContratos;
using System.Windows.Controls;

namespace ProjetoMaluco.Views
{
    /// <summary>
    /// Lógica interna para BuscaContratos.xaml
    /// </summary>
    public partial class BuscaContratos : Window
    {
        public List<BuscaContrato> ResultadosPesquisa { get; private set; }
        public BuscaContratos()
        {
            InitializeComponent();
            
        }

       

        private void BtnConfirmar_Click(object sender, RoutedEventArgs e)
        {


            ResultadosPesquisa = DataService.Select<BuscaContrato>($"SELECT db_nome,db_cpf,db_numcontrato,db_produto,db_vencimento,db_valor FROM db_contratos WHERE db_cpf= '{txtboxCpf.Text.Trim()}'");
            Close();
        }

        private void BtncSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
