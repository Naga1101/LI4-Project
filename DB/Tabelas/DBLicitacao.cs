using Dapper;
using System.Data.SqlClient;

namespace JBleiloes.DB.Tabelas
{
    public class DBLicitacao
    {
        private static DBLicitacao? singleton = null;

        private DBLicitacao() { }

        public static DBLicitacao getInstance()
        {
            if (singleton == null)
            {
                singleton = new DBLicitacao();
            }
            return singleton;
        }

        public void registarLicitação(string licitador, decimal valor_licitacao, int id_leilao)
        {
            string query = "INSERT INTO dbo.Licitacao (id_licitador, valor_licitacao, id_leilao) " +
                           "VALUES (@IdLicitador, @ValorLicitacao, @IdLeilao)";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();

                    var parameters = new
                    {
                        IdLicitador = licitador,
                        ValorLicitacao = valor_licitacao,
                        IdLeilao = id_leilao
                    };

                    connection.Execute(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
