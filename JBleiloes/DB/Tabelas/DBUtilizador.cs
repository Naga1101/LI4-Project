using System.Data.SqlClient;
using Dapper;
using JBleiloes.data.Utilizadores;
using Microsoft.AspNetCore.Http;

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

        public Utilizador? getUser(string username)
        {
            Utilizador? user = null;
            string query = "SELECT * FROM dbo.Utilizador WHERE username = @Username";
            var parameters = new { Username = username };

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    user = connection.QueryFirstOrDefault<Utilizador>(query, parameters);
                }
            }
            catch (SqlException ex)
            {
                // Handle specific SQL exceptions if needed
                throw new Exception($"Error retrieving user: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new Exception($"Unexpected error: {ex.Message}");
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


        public void addUtilizador(string username, string password, string nome, string email, int nº_cc, int NIF, string data_nascimento)
        {
            DateTime parsedDate = DateTime.Parse(data_nascimento);

            string query = "INSERT INTO [dbo].[Utilizador] " +
                               "([username], [password], [nome], [email], [nº_CC], [NIF], [data_nascimento], [tipo_utilizador]) " +
                               "VALUES " +
                               $"('{username}', '{password}', '{nome}', '{email}', {nº_cc}, {NIF}, '{parsedDate}', '0');";
            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    connection.Query(query);
                }
            }

            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool validateLoginInfo(string username, string password)
        {
            string query= $"SELECT COUNT(*) as UserCount FROM [dbo].[Utilizador] WHERE [username] = '{username}' AND [password] = '{password}'";

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();
                    int res = connection.QuerySingle<int>(query);

                    if (res == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}