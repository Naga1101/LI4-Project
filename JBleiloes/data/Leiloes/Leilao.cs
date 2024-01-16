namespace JBleiloes.data.Leiloes
{
    public class Leilao
    {
        private int Id;
        private string Titulo;
        private DateOnly TempoDeLeilao;
        private decimal ValorInicial;
        private string VendedorUsername;
        private decimal ValorMinimo;
        private decimal ValorAtual;
        private int VeiculoId;
        private bool Aprovado;
        private bool ADecorrer;
        private string Imagem;

        public Leilao(int id, string titulo, DateOnly tempoDeLeilao, decimal valorInicial, string vendedorUsername, decimal valorMinimo, decimal valorAtual, int veiculoId, bool aprovado, bool aDecorrer, string imagem)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.TempoDeLeilao = tempoDeLeilao;
            this.ValorInicial = valorInicial;
            this.VendedorUsername = vendedorUsername;
            this.ValorMinimo = valorMinimo;
            this.ValorAtual = valorAtual;
            this.VeiculoId = veiculoId;
            this.Aprovado = aprovado;
            this.ADecorrer = aDecorrer;
            this.Imagem = imagem;
        }                                    

        public Leilao() { } 

        public int getId() { return this.Id; }
        public string getTitulo() { return this.Titulo; }

        public decimal getValorMini() { return this.ValorMinimo; }

        public DateOnly getTempoDeLeilao() { return this.TempoDeLeilao; }
    }
}


/*namespace JBleiloes.data.Leiloes
{
    public class Leilao
    {
        public int Id { get; private set; }
        public string Titulo;
        public TimeSpan TempoDeLeilao { get; private set; }
        public decimal ValorInicial { get; private set; }
        public string VendedorUsername { get; private set; }
        public decimal ValorMinimo { get; private set; }
        public decimal ValorAtual { get; private set; }
        public int VeiculoId { get; private set; }
        public bool Aprovado { get; private set; }
        public bool ADecorrer { get; private set; }
        public string? CompradorUsername { get; private set; }
        public string? Imagem { get; private set; }

        public Leilao(int id, string titulo, TimeSpan tempo_de_leilao, decimal valor_inicial, string vendedor, decimal valor_minimo, decimal valor_atual, int veiculo, bool aprovado, bool a_decorrer, string comprador, string imagem)
        {
            Id = id;
            this.Titulo = titulo;
            TempoDeLeilao = tempo_de_leilao;
            ValorInicial = valor_inicial;
            VendedorUsername = vendedor;
            ValorMinimo = valor_minimo;
            ValorAtual = valor_atual;
            VeiculoId = veiculo;
            Aprovado = aprovado;
            ADecorrer = a_decorrer;
            CompradorUsername = comprador;
            Imagem = imagem;
        }

        public Leilao() { } 

        public int getId() { return Id; }
        public string getTitulo() { return Titulo; }

        public decimal getValorMini() { return ValorMinimo; }
    }
}
*/