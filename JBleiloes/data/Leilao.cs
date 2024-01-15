namespace JBleiloes.data
{
    public class Leilao
    {
        private int id;
        private string titulo;
        private TimeSpan tempo_de_leilao;
        private decimal valor_inicial;
        private string vendedor;
        private decimal valor_minimo;
        private decimal valor_atual;
        private int veiculo; //chave estrangeira para o veiculo
        private byte aprovado;
        private byte a_decorrer;
        private string comprador;
        private string imagem; // mudar depois

        public Leilao(int id, string titulo, TimeSpan tempo_de_leilao, decimal valor_inicial, string vendedor, decimal valor_minimo, decimal valor_atual, int veiculo, byte aprovado, byte a_decorrer, string comprador, string imagem)
        {
            this.id = id;
            this.titulo = titulo;
            this.tempo_de_leilao = tempo_de_leilao;
            this.valor_inicial = valor_inicial;
            this.vendedor = vendedor;
            this.valor_minimo = valor_minimo;
            this.valor_atual = valor_atual;
            this.veiculo = veiculo;
            this.aprovado = aprovado;
            this.a_decorrer = a_decorrer;
            this.comprador = comprador;
            this.imagem = imagem;
        }

        public int getId() { return id; }
        public string getTitulo() {  return titulo; }
            
    }
}
