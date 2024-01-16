using System.Data.SqlClient;
using Dapper;
using JBleiloes.data.Utilizadores;

namespace JBleiloes.DB.Tabelas
{
    public class DBUtilizador
    {
        private static DBUtilizador? singleton = null;

        private DBUtilizador() { }

        public static DBUtilizador getInstance()
        {
            if (singleton == null)
            {
                singleton = new DBUtilizador();
            }
            return singleton;
        }

        public Utilizador getUser(string username)
        {
            Utilizador? user = null;
            string query = $"SELECT * FROM dbo.Utilizador where username = '{username}'";
            try
            {
                using(SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    user = connection.QueryFirst<Utilizador>(query);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public IEnumerable<Utilizador> getAllUsers()
        {
            IEnumerable<Utilizador>? users = null;
            string query = "SELECT * FROM dbo.Utilizador";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    users = connection.Query<Utilizador>(query);
                }
            }

            catch (Exception ex) { throw new Exception(ex.Message); }

            return users;
        }
    }
}