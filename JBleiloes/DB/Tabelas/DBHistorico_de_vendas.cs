using Dapper;
using JBleiloes.data.Leiloes;
using JBleiloes.data;
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
                    connection.Query(query);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Leilao[] GetHistoricoVendas(string cliente, JBLeiloes jb)
        {
            string query = $"SELECT id_leilao FROM [dbo].[Historico de vendas] WHERE cliente = '{cliente}'";

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
