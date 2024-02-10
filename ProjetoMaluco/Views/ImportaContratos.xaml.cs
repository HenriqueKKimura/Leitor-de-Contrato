﻿using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Win32;
using System.Globalization;
using System.IO;
using System.Windows;
using ProjetoMaluco.Views;
using System.Text;
using ProjetoMaluco.Services;
using ProjetoMaluco.Entities.ArquivoImportado;
using System.Windows.Controls;

namespace ProjetoMaluco.Views
{
    /// <summary>
    /// Lógica interna para ImportaContratos.xaml
    /// </summary>
    public partial class ImportaContratos : Window
    {
        public ImportaContratos()
        {
            InitializeComponent();
        }

        private void BtnImportar_Click(object sender, RoutedEventArgs e)
        {
            PreencherDataGrid();
            #region Importação de Contratos (TESTE)
            //var dialog = new OpenFileDialog();
            //dialog.Filter = "Arquivos CSV (*.csv)|*.csv";

            //if (dialog.ShowDialog() == true)
            //{
            //    var filePath = dialog.FileName;
            //    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            //    {
            //        Delimiter = ";",
            //        HasHeaderRecord = false //Indica que o arquivo não tem linha de cabeçalho
            //    };

            //    // Ler o conteúdo do arquivo CSV
            //    using (var reader = new StreamReader(filePath))
            //    using (var csv = new CsvReader(reader, csvConfig))
            //    {
            //        // Mapear manualmente as colunas para as propriedades da classe ArquivoImportado
            //        csv.Context.RegisterClassMap<ArquivoImportadoMap>();

            //        var records = csv.GetRecords<ArquivoImportado>().ToList();

            //        // Loop pelos registros
            //        foreach (var record in records)
            //        {

            //            // Fazer algo com os dados
            //            //txtboxnome.Text = record.Nome;
            //            //txtboxcpf.Text = record.CPF.ToString();
            //            //txtboxcontrato.Text = record.NumContrato.ToString();
            //            //txtboxproduto.Text = record.Produto;
            //            //txtboxvalorcontrato.Text = record.Valor.ToString();
            //            //txtboxdatavencimento.Text = record.Vencimento.ToString();

            //        }
            //    }
            //}
            #endregion
        }

        private void PreencherDataGrid()
        {
            //Responsável por abrir o Explorador de Arquivos
            var dialog = new OpenFileDialog();
            dialog.Filter = "Arquivos CSV (*.csv)|*.csv";

            if (dialog.ShowDialog() == true)
            {
                //Pega o Caminho do Arquivo .csv
                var filePath = dialog.FileName;

                //Configuração do CsvHelper
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    HasHeaderRecord = true //Indica que o arquivo não tem linha de cabeçalho

                };

                // Ler o conteúdo do arquivo CSV
                using (var reader = new StreamReader(filePath, Encoding.UTF8))
                using (var csv = new CsvReader(reader, csvConfig))
                {
                    // Mapear manualmente as colunas para as propriedades da classe ArquivoImportado
                    csv.Context.RegisterClassMap<ArquivoImportadoMap>();

                    //Pega as informações do Mapeamento e Transforma em uma Lista
                    var records = csv.GetRecords<ArquivoImportado>().ToList();

                    //Lista está alimentando o DataGrid
                    dataGrid.ItemsSource = records;
                }
            }
            #region Popular Lista manualmente (TESTE DATAGRID)
            //List<ArquivoImportado> arquivos = new List<ArquivoImportado>
            //{
            //    new ArquivoImportado { Nome = "Kenzo", CPF = "123.456.789-10", NumeroContrato = 123456, Produto = "Produto A", ValorContrato = 25121,DataVencimento = DateTime.Now.AddDays(30) },
            //    new ArquivoImportado { Nome = "Kenzo", CPF = "221.331.441-12", NumeroContrato = 123456, Produto = "Produto A", ValorContrato = 25121,DataVencimento = DateTime.Now.AddDays(30) },
            //    new ArquivoImportado { Nome = "Kenzo", CPF = "441.441.442-44", NumeroContrato = 123456, Produto = "Produto A", ValorContrato = 25121,DataVencimento = DateTime.Now.AddDays(30) },
            //    new ArquivoImportado { Nome = "Kenzo", CPF = "555.555.541-61", NumeroContrato = 123456, Produto = "Produto A", ValorContrato = 25121,DataVencimento = DateTime.Now.AddDays(30) }
            //};
            //dataGrid.ItemsSource = arquivos;

            #endregion
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        
        {
            var itemsSource = dataGrid.ItemsSource as List<ArquivoImportado>;
            if (itemsSource != null)
            {
                foreach (var item in itemsSource)
                {
                    var nome = item.Nome;
                    var cpf = item.CPF;
                    var numeroContrato = item.NumeroContrato;
                    var produto = item.Produto;
                    var dataVencimento = item.DataVencimento;
                    var ValorContrato = item.ValorContrato;
                    var idFuncionario = item.IdFuncionario;

                    string insert = $"INSERT INTO db_contratos (db_nome, db_cpf, db_numcontrato, db_produto, db_vencimento, db_valor db_idfuncionario) " +
                                    $"VALUES ('{nome}', '{cpf}', '{numeroContrato}', '{produto}', '{dataVencimento}', '{ValorContrato}', '{idFuncionario}')";

                    bool gravouContrato = DataService.Insert(insert);
                    if (gravouContrato)
                    {
                        MessageBox.Show("'Sucesso' Contrato inserido no Banco de Dados", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                        dataGrid.ItemsSource = null;
                    }
                    else
                    {
                        MessageBox.Show("'ERROR!' Contactar o Administrador", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

        }
    }
}
