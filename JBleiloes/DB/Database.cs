using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using JBleiloes.data.Leiloes;
using JBleiloes.data.Utilizadores;
using JBleiloes.DB.Tabelas;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JBleiloes.DB
{
    public class Database
    {
        private DBUtilizador DBUtilizador;
        private DBLeilao DBLeilao;
        private DBVeiculo DBVeiculo;

        public Database()
        {
            this.DBUtilizador = DBUtilizador.getInstance();
            this.DBLeilao = DBLeilao.getInstance();

            // Check if tables were loaded successfully
            if (CheckTablesLoaded())
            {
                Console.WriteLine("Tables loaded successfully.");
            }
            else
            {
                Console.WriteLine("Error loading tables.");
            }
        }

        private bool CheckTablesLoaded()
        {
            try
            {
                // You can perform additional checks here if needed
                // For now, just check if getUser and getLeiloesDecorrer methods return non-null values
                Utilizador user = this.DBUtilizador.getUser("sampleUsername");
                List<Leilao> leiloes = this.DBLeilao.GetLeiloesDecorrer();

                return user != null && leiloes != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking tables: {ex.Message}");
                return false;
            }
        }

        public bool validateLoginData(string username, string password)
        {
            return DBUtilizador.validateLoginInfo(username, password);
        }

        public Utilizador getUtilizador(string username)
        {
            return this.DBUtilizador.getUser(username);
        }

        public Leilao getLeilao(int idLeilao)
        {
            return this.DBLeilao.getLeilao(idLeilao);
        }

        public List<Leilao> getLeiloesDecorrer()
        {
            return this.DBLeilao.GetLeiloesDecorrer();
        }
        public IEnumerable<Leilao> getLeiloesUtilizador(string username)
        {
            return this.DBLeilao.getLeiloesUtilizador(username);
        }
        public IEnumerable<Leilao> GetLeiloesUtilizadorWatchList(string username)
        {
            return DBLeilao.GetLeiloesUtilizadorWatchList(username);
        }
        public byte getUserTypeLeilao(string username)
        {
            return this.DBLeilao.getUserTypeLeilao(username);
        }

        public IEnumerable<Leilao> GetLeiloes()
        {
            return DBLeilao.GetLeiloes();
        }

        public void AdicionarWatchlist(string username, int idLeilao)
        {
            DBUtilizador.AdicionarWatchlist(username, idLeilao);
        }
        public void removerWatchlist(string username, int idLeilao)
        {
            DBUtilizador.removerWatchlist(username, idLeilao);
        }
        public bool podeAdicionarWatchList(string username, int idLeilao)
        {
            return DBUtilizador.podeAdicionarWatchList(username, idLeilao);
        }
        public void registerUser(string username, string password, string nome, string email, int nº_cc, int NIF, string data_nascimento)
        {
            DBUtilizador.addUtilizador(username, password, nome, email, nº_cc, NIF, data_nascimento);
        }

        public void registaLeilaoEVeiculo(string titulo, decimal valor_inicial, string vendedor, decimal valor_minimo, TimeSpan tempo_de_leilao, string Marca, string Modelo, int Ano, decimal Quilometragem)
        {
            DBVeiculo.registaVeiculo(Marca, Modelo, Ano, Quilometragem, vendedor);
            DBLeilao.registaLeilao(titulo, valor_inicial, vendedor, valor_minimo, tempo_de_leilao);
        }
    }
}
