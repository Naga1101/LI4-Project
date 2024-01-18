using Dapper;
using JBleiloes.Components.Pages.Leilões;
using JBleiloes.data.Leiloes;
using JBleiloes.DB;
using System.Data.SqlClient;

namespace JBleiloes.DB.Tabelas
{
    public class DBLeilao
    {
        private static DBLeilao? singleton = null;

        private DBLeilao() { }

        public static DBLeilao getInstance()
        {
            if (singleton == null)
            {
                singleton = new DBLeilao();
            }
            return singleton;
        }

        public Leilao getLeilao(int idLeilao)
        {
            Leilao? leilao = null;
            string query = "SELECT * FROM [dbo].[Leilão] WHERE id = @Id";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    leilao = connection.QueryFirst<Leilao>(query, new { Id = idLeilao });
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            return leilao;
        }

        public List<Leilao> GetLeiloesDecorrer()
        {
            List<Leilao> leiloes = new List<Leilao>();
            string query = "SELECT * FROM dbo.Leilão WHERE a_decorrer = 1"; // Filter auctions in progress

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    IEnumerable<Leilao> result = connection.Query<Leilao>(query);
                    leiloes.AddRange(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return leiloes;
        }



        public IEnumerable<Leilao> GetLeiloes()
        {
            string query = "SELECT * FROM [dbo].[Leilão]";

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                return connection.Query<Leilao>(query);
            }
        }
    }      
}

public class LeilaoRepository
{
    public IEnumerable<Leilao> GetAllLeiloes()
    {
        string query = "SELECT * FROM [dbo].[Leilão]";

        using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
        {
            connection.Open();
            return connection.Query<Leilao>(query);
        }
    }


    public IEnumerable<Leilao> getLeiloesUtilizador(string username)
    {
        string query = $"SELECT * FROM [dbo].[Leilão] where vendedor = '{username}'";

        using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
        {
            connection.Open();
            var leiloes = connection.Query<Leilao>(query);

            foreach (var leilao in leiloes)
            {
                yield return leilao;
            }
        }
    }
}