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
            string query = $"SELECT * FROM [dbo].[Leilão] WHERE id = '{idLeilao}'";

            try
            {
                using(SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    leilao = connection.QueryFirst<Leilao>(query);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            return leilao;
        }

        public ICollection<Leilao> getLeiloesDecorrer()
        {
            ICollection<Leilao> leiloes = new HashSet<Leilao>();
            string query = "SELECT * FROM dbo.Leilão";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    IEnumerable<Leilao> aux = connection.Query<Leilao>(query);
                    foreach (Leilao l in aux)
                    {
                        leiloes.Add(l);
                    }

                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return leiloes;
        }
    }
}

public class LeilaoRepository
{
    public IEnumerable<Leilao> GetLeiloes()
    {
        string query = "SELECT * FROM [dbo].[Leilão]";

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

    public Leilao getLeilaoById(int id)
    {
        string query = $"SELECT * FROM [dbo].[Leilão] where id = '{id}'";

        using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
        {
            connection.Open();
            Leilao l = connection.QueryFirst<Leilao>(query);

            return l;
        }
    }
}