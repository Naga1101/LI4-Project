using Dapper;
using JBleiloes.data.Licitacoes;
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

        public string GetVencedorLeilao(int id_leilao)
        {
            string query = $"SELECT id_licitador FROM Licitacao WHERE id_leilao = {id_leilao} AND id_licitacao = " +
                $"(SELECT MAX(id_licitacao) FROM Licitacao WHERE id_leilao = {id_leilao})";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    string winner = connection.QueryFirst<string>(query);

                    if (winner != null)
                    {
                        return winner;
                    }
                    else
                    {
                        return "null";
                    }
                }
            }
            catch (Exception ex)
            {
                return "null";
            }
        }

        public IEnumerable<Licitacao> getAllLicitacoesFromLeilao(int id_leilao)
        {
            string query = $"SELECT * FROM [dbo].[licitacao] WHERE id_leilao = {id_leilao}";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    return connection.Query<Licitacao>(query);
                }
            }
            catch(Exception ex) { return null; }
        }
    }
}
