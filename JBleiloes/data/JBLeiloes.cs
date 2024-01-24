using JBleiloes.data.Leiloes;
using JBleiloes.data.Utilizadores;
using JBleiloes.data.Veiculos;
using JBleiloes.DB;
using JBleiloes.DB.Tabelas;


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

        public IEnumerable<Leilao> GetLeiloes()
        {
            return db.GetLeiloes();
        }
        
        public IEnumerable<Leilao> getLeiloesUtilizador(string username)
        {
            return db.getLeiloesUtilizador(username);
        }

        public IEnumerable<Leilao> GetLeiloesUtilizadorWatchList(string username)
        {
            return db.GetLeiloesUtilizadorWatchList(username);
        }

        public byte getUserTypeLeilao(string username)
        {
            return db.getUserTypeLeilao(username);
        }

        public Leilao getLeilaoId(int id)
        {
            return db.getLeilao(id);
        }

        public void AdicionarWatchlist(string username, int idLeilao)
        {
            db.AdicionarWatchlist(username, idLeilao);
        }

        public void removerWatchlist(string username, int idLeilao)
        {
            db.removerWatchlist(username, idLeilao);
        }

        public bool podeAdicionarWatchList(string username, int idLeilao)
        {
            return db.podeAdicionarWatchList(username, idLeilao); ;
        }

        public void registarLicitação(string licitador, decimal valor_licitacao, int id_leilao)
        {
            db.registarLicitação(licitador, valor_licitacao, id_leilao);
        }

        public void atualizarValorAtualLeilao(int id_leilao, decimal licitação)
        {
            db.atualizarValorAtualLeilao(id_leilao, licitação);
        }

        public void aprovaLeilao(int idLeilao)
        {
            db.aprovarLeilao(idLeilao);
        }

        public void registerUser(string username, string password, string nome, string email, int nº_cc, int NIF, DateOnly data_nascimento)
        {
            db.registerUser(username, password, nome, email, nº_cc, NIF, data_nascimento);
        }
        public void registaLeilaoEveiculo(string titulo, decimal valor_inicial, string vendedor, decimal valor_minimo, DateTime tempo_de_leilao, string Marca, string Modelo, int Ano, decimal Quilometragem)
        {
            db.registaLeilaoEVeiculo(titulo, valor_inicial, vendedor, valor_minimo, tempo_de_leilao, Marca, Modelo, Ano, Quilometragem);
        }
        public void addHistoricoVendas(string cliente, int id_leilao)
        {
            db.addHistoricoVendas(cliente, id_leilao);
        }

        public void addHistoricoCompras(string cliente, int id_leilao)
        {
            db.addHistoricoCompras(cliente, id_leilao);
        }

        public void updateDonoVeiculo(int id_veiculo, string new_owner)
        {
            db.updateDonoVeiculo(id_veiculo, new_owner);
        }

        public void defineComprador(int id_leilao, string comprador)
        {
            db.defineComprador(id_leilao, comprador);
        }

        public string getVencedorLeilao(int id_leilao)
        {
            return db.getVencedorLeilao(id_leilao);
        }

        public void removerA_Decorrer(int id_leilao)
        {
            db.removerA_Decorrer(id_leilao);
        }

        public Leilao[] GetHistoricoVendas(string cliente, JBLeiloes jb)
        {
            return db.GetHistoricoVendas(cliente, jb);
        }

        public Leilao[] GetHistoricoCompras(string cliente, JBLeiloes jb)
        {
            return db.GetHistoricoCompras (cliente, jb);    
        }

        public void registerFuncionario(string username, string password, string nome, string email, int nº_cc, int NIF, DateOnly data_nascimento)
        {
            db.addFuncionario(username, password, nome, email, nº_cc, NIF, data_nascimento);
        }
        public Veiculo getVeiculo(int id)
        {
            return db.getVeiculo(id);
        }
    }
}
