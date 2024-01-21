namespace JBleiloes.data.Licitacoes
{
    public class Licitacao
    {
        public int id { get; set; }
        public string id_licitador { get; set; }
        public decimal valor_licitacao { get; set; }
        public int id_leilao { get; set; }

        public Licitacao() { }

        public Licitacao(int id, string id_licitador, decimal valor_licitacao, int id_leilao)
        {
            this.id = id;
            this.id_licitador = id_licitador;
            this.valor_licitacao = valor_licitacao;
            this.id_leilao = id_leilao;
        }
    }
}
