using JBleiloes.data.Leiloes;
using JBleiloes.data.Utilizadores;
using JBleiloes.DB;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using System.Text.RegularExpressions;


namespace JBleiloes.data
{
    public class JBLeiloes
    {
        private Database db;

        public JBLeiloes()
        {
            this.db = new Database();
        }

        public Utilizador getUtilizador(string username)
        {
            return db.getUtilizador(username);
        }

        public bool validarLogin(string username, string password)
        {
            return db.validateLoginData(username, password);   
        }

        public ICollection<Leilao> getLeilõesDecorrer()
        {
            return db.getLeiloesDecorrer();
        }

        public void registerUser(string username, string password, string nome, string email, int nº_cc, int NIF, string data_nascimento)
        {
            db.registerUser(username, password, nome, email, nº_cc, NIF, data_nascimento);
        }

        public Leilao getleilaobyid(int id)
        {
            return db.getLeilao(id);
        }

        public byte getUserTypeFromLeilao(string username)
        {
            return db.getUserTypeFromLeilao(username);
        }
        public void registaLeilaoEveiculo(string titulo, decimal valor_inicial, string vendedor, decimal valor_minimo, TimeSpan tempo_de_leilao, string Marca, string Modelo, int Ano, decimal Quilometragem)
        {
            db.registaLeilaoEVeiculo(titulo, valor_inicial,vendedor,valor_minimo,tempo_de_leilao, Marca, Modelo, Ano, Quilometragem);
            
        }
    }
}
