using Dapper;
using JBleiloes.data.Leiloes;
using JBleiloes.data;
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

        public Leilao[] GetHistoricoCompras(string cliente, JBLeiloes jb)
        {
            string query = $"SELECT id_leilao FROM [dbo].[Historico de compras] WHERE cliente = '{cliente}'";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    var leilaoIds = connection.Query<int>(query);

                    var leiloes = leilaoIds.Select(id => jb.getLeilaoId(id)).ToArray();

                    return leiloes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
