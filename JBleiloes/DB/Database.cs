using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using JBleiloes.data;
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
        private DBLicitacao DBLicitacao;
        private DBHistorico_de_compras DBHistorico_de_compras;
        private DBHistorico_de_vendas DBHistorico_de_vendas;


        public Database()
        {
            DBUtilizador = DBUtilizador.getInstance();
            DBLeilao = DBLeilao.getInstance();
            DBVeiculo = DBVeiculo.getInstance();
            DBLicitacao = DBLicitacao.getInstance();
            DBHistorico_de_compras = DBHistorico_de_compras.getInstance();
            DBHistorico_de_vendas = DBHistorico_de_vendas.getInstance();

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
                List<Leilao> leiloes = this.DBLeilao.GetLeiloesDecorrerEAprovados();

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

        public Leilao getLeilao(int idLeilao)
        {
            return DBLeilao.getLeilao(idLeilao);
        }

        public List<Leilao> getLeiloesDecorrer()
        {
            return this.DBLeilao.GetLeiloesDecorrerEAprovados();
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

        public void aprovarLeilao(int id_leilao)
        {
            DBLeilao.aprovarLeilao(id_leilao);
        }

        public IEnumerable<Leilao> getAllUserLeiloes()
        {
            return DBLeilao.getAllUserLeiloes();
        }
        public void atualizarValorAtualLeilao(int id_leilao, decimal licitação)
        {
            DBLeilao.atualizarValorAtualLeilao(id_leilao, licitação);
        }
        public void defineComprador(int id_leilao, string comprador)
        {
            DBLeilao.defineComprador(id_leilao, comprador);
        }

        public void registarLicitação(string licitador, decimal valor_licitacao, int id_leilao)
        {
            DBLicitacao.registarLicitação(licitador, valor_licitacao, id_leilao);
        }

        public void addHistoricoVendas(string cliente, int id_leilao)
        {
            DBHistorico_de_vendas.addHistoricoVendas(cliente, id_leilao);
        }

        public void addHistoricoCompras(string cliente, int id_leilao)
        {
            DBHistorico_de_compras.addHistoricoCompras(cliente, id_leilao);
        }

        public void updateDonoVeiculo(int id_veiculo, string new_owner)
        {
            DBVeiculo.updateDonoVeiculo(id_veiculo, new_owner);
        }

        public void registaLeilaoEVeiculo(string titulo, decimal valor_inicial, string vendedor, decimal valor_minimo, DateTime tempo_de_leilao, string Marca, string Modelo, int Ano, decimal Quilometragem)
        {
            int id_veiculo = DBVeiculo.RegistaVeiculo(Marca, Modelo, Ano, Quilometragem, vendedor);
            DBLeilao.registaLeilao(titulo, valor_inicial, vendedor, valor_minimo, tempo_de_leilao, id_veiculo);
        }

        public string getVencedorLeilao(int id_leilao)
        {
            return DBLicitacao.GetVencedorLeilao(id_leilao);
        }

        public void removerA_Decorrer(int id_leilao)
        {
            DBLeilao.removerA_Decorrer(id_leilao);
        }

        public Leilao[] GetHistoricoVendas(string cliente, JBLeiloes jb)
        {
            return DBHistorico_de_vendas.GetHistoricoVendas(cliente, jb);
        }

        public Leilao[] GetHistoricoCompras(string cliente, JBLeiloes jb)
        {
            return DBHistorico_de_compras.GetHistoricoCompras (cliente, jb);
        }



    }
}
