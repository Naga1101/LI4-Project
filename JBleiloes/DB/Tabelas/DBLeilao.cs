using Dapper;
using JBleiloes.data;


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
            string query = $"SELECT * FROM dbo.Leilão WHERE id = '{idLeilao}'";

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
    }
}
