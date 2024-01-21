using Dapper;
using System.Data.SqlClient;

namespace JBleiloes.DB.Tabelas
{
    public class DBHistorico_de_vendas
    {
        private static DBHistorico_de_vendas? singleton = null;

        private DBHistorico_de_vendas() { }

        public static DBHistorico_de_vendas getInstance()
        {
            if (singleton == null)
            {
                singleton = new DBHistorico_de_vendas();
            }
            return singleton;
        }

        public void addHistoricoVendas(string cliente, int id_leilao)
        {
            string query = $"INSERT INTO [dbo].[Historico de vendas] (cliente, id_leilao)" +
                          $"VALUES ('{cliente}', {id_leilao})";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    connection.Execute(query);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
