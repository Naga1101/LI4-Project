﻿using System.Data.SqlClient;
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
                throw new Exception($"Error retrieving user: {ex.Message}");
            }
            catch (Exception ex)
            {
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

        public void addUtilizador(string username, string password, string nome, string email, int nº_cc, int NIF, DateOnly data_nascimento)
        {

            string query = "INSERT INTO [dbo].[Utilizador] " +
                               "([username], [password], [nome], [email], [CC], [NIF], [data_nascimento], [tipo_utilizador]) " +
                               "VALUES " +
                               $"('{username}', '{password}', '{nome}', '{email}', {nº_cc}, {NIF}, CONVERT(date, '{data_nascimento}', 105), '1');";
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

        public void addFuncionario(string username, string password, string nome, string email, int nº_cc, int NIF, DateOnly data_nascimento)
        {
            string query = "INSERT INTO [dbo].[Utilizador] " +
                               "([username], [password], [nome], [email], [CC], [NIF], [data_nascimento], [tipo_utilizador]) " +
                               "VALUES " +
                               $"('{username}', '{password}', '{nome}', '{email}', {nº_cc}, {NIF}, CONVERT(date, '{data_nascimento}', 105), '2');";
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

        public bool podeAdicionarWatchList(string username, int idLeilao)
        {
            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();

                string selectQuery = "SELECT COUNT(*) FROM [dbo].[Watchlist] WHERE id_cliente = @IdCliente AND id_leilao = @IdLeilao";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@IdCliente", username);
                    command.Parameters.AddWithValue("@IdLeilao", idLeilao);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        public void removerWatchlist(string username, int idLeilao)
        {
            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM [dbo].[Watchlist] WHERE id_cliente = @IdCliente AND id_leilao = @IdLeilao";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@IdCliente", username);
                    command.Parameters.AddWithValue("@IdLeilao", idLeilao);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void AdicionarWatchlist(string username, int idLeilao)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO [dbo].[Watchlist] (id_cliente, id_leilao) VALUES (@IdCliente, @IdLeilao)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IdCliente", username);
                        command.Parameters.AddWithValue("@IdLeilao", idLeilao);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool UsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM dbo.Utilizador WHERE username = @Username";
            var parameters = new { Username = username };

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                int count = connection.QuerySingle<int>(query, parameters);
                return count > 0;
            }
        }

        public bool NIFExists(int nif)
        {
            string query = "SELECT COUNT(*) FROM dbo.Utilizador WHERE NIF = @NIF";
            var parameters = new { NIF = nif };

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                int count = connection.QuerySingle<int>(query, parameters);
                return count > 0;
            }
        }

        public bool CCExists(int cc)
        {
            string query = "SELECT COUNT(*) FROM dbo.Utilizador WHERE CC = @CC";
            var parameters = new { CC = cc };

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                int count = connection.QuerySingle<int>(query, parameters);
                return count > 0;
            }
        }

        public bool EmailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM dbo.Utilizador WHERE email = @Email";
            var parameters = new { Email = email };

            using (SqlConnection connection = new SqlConnection(DBConfig.Connection()))
            {
                connection.Open();
                int count = connection.QuerySingle<int>(query, parameters);
                return count > 0;
            }
        }
    }
}