using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoMaluco.Services
{
    public static class DataService
    {
        public static string ConexaoBD()
        {
            //Ambiente 1 = Homologação
            //Ambiente 2 = Produção
            int ambiente = 1;
            switch (ambiente)
            {
                case 1:
                    return "Data Source=KENZO\\SQLSERVER2022;Initial Catalog=Concilig;Integrated Security=True";
                case 2:
                    return "Ambiente Produção";
                default:
                    return "";
            }
        }
        private static bool ExecutaQuery(string query)
        {
            // Inicia o comando
            var command = new SqlCommand(query);

            // Inicia a conexão
            using (var connection = new SqlConnection(ConexaoBD()))
            {
                // Atribui o comando à conexão
                command.Connection = connection;
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Executa o comando
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("ROWS: " + rowsAffected);

                    // Retorna verdadeiro se tiver afetado algum registro, caso contrário, falso
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao executar comando SQL: " + ex.Message);
                    // Em caso de erro, retorna falso
                    return false;
                }
            }
        }
        public static bool Insert(string insert)
        {
            return ExecutaQuery(insert);
        }
        public static List<T> Select<T>(string select)
        {
            {
                // Inicia o comando
                var command = new SqlCommand(select);

                // Inicia a conexão (será fechada no fim do 'using')
                using (var connection = new SqlConnection(ConexaoBD()))
                {
                    // Inicia a lista
                    var list = new List<T>();

                    // Atribui a conexão ao comando
                    command.Connection = connection;

                    // Abre a conexão
                    connection.Open();

                    // Executa o comando em formato de leitor
                    var reader = command.ExecuteReader();

                    // Inicia uma tabela genérica do C#
                    var dataTable = new DataTable();

                    // Carrega o leitor na tabela
                    dataTable.Load(reader);

                    // Para cada linha da tabela
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        // Recupera o tipo do model informado no <T> do método
                        var tipo = typeof(T);

                        // Cria uma instância do model
                        var objeto = Activator.CreateInstance<T>();

                        // Para cada coluna na linha atual
                        foreach (DataColumn column in dataRow.Table.Columns)
                        {
                            // Para cada propriedade do model
                            foreach (var pro in tipo.GetProperties())
                            {
                                // Se o nome da propriedade for igual ao nome da coluna
                                if (pro.Name.ToLower() == column.ColumnName.ToLower())
                                {
                                    // Se o valor da coluna na linha atual não for nulo
                                    if (dataRow[column.ColumnName] != DBNull.Value)
                                    {
                                        // Recupera o valor da coluna atual da linha atual
                                        object value = dataRow[column.ColumnName];

                                        // Atribui o valor a propriedade do model
                                        pro.SetValue(objeto, value, null);
                                    }
                                }
                                else
                                {
                                    // Se o nome não for igual, passa pro próximo
                                    continue;
                                }
                            }
                        }

                        // Adiciona o objeto a lista
                        list.Add(objeto);
                    }

                    // Retorna a lista
                    return list;
                }
            }
        }
        public static bool Update(string update)
        {
            return ExecutaQuery(update);
        }

    }
}
