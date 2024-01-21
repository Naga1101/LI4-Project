using Dapper;
using System.Data.SqlClient;

namespace JBleiloes.DB.Tabelas
{
    public class DBHistorico_de_compras
    {
        private static DBHistorico_de_compras? singleton = null;

        private DBHistorico_de_compras() { }

        public static DBHistorico_de_compras getInstance()
        {
            if (singleton == null)
            {
                singleton = new DBHistorico_de_compras();
            }
            return singleton;
        }

        public void addHistoricoCompras(string cliente, int id_leilao)
        {
            string query = $"INSERT INTO [dbo].[Historico de compras] (cliente, id_leilao)" +
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
