using Dapper;

namespace JBleiloes.data.Leiloes
{
    public class Leilao
    {
        public int Id { get; private set; }
        public string? Titulo { get; private set; }
        public decimal ValorInicial { get; private set; }
        public string? VendedorUsername { get; private set; }
        public decimal ValorMinimo { get; private set; }
        public decimal ValorAtual { get; private set; }
        public int VeiculoId { get; private set; }
        public bool Aprovado { get; private set; }
        public bool ADecorrer { get; private set; }
        public string? Comprador { get; private set; }
        public TimeSpan TempoDeLeilao { get; private set; }
        public string? Imagem { get; private set; }

        public Leilao(int id, string titulo, decimal valorInicial, string vendedorUsername, decimal valorMinimo, decimal valorAtual, int veiculoId, bool aprovado, bool aDecorrer, string comprador, TimeSpan tempoDeLeilao, string imagem)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.ValorInicial = valorInicial;
            this.VendedorUsername = vendedorUsername;
            this.ValorMinimo = valorMinimo;
            this.ValorAtual = valorAtual;
            this.VeiculoId = veiculoId;
            this.Aprovado = aprovado;
            this.ADecorrer = aDecorrer;
            this.Comprador = comprador ?? string.Empty;
            this.TempoDeLeilao = tempoDeLeilao;
            this.Imagem = imagem;
        }

        public Leilao(SqlMapper.GridReader reader)
        {
            var result = reader.Read().SingleOrDefault();

            if (result != null)
            {
                Id = (int)result.id;
                Titulo = (string)result.titulo;
                ValorInicial = (decimal)result.valor_inicial;
                VendedorUsername = (string)result.vendedor;
                ValorMinimo = (decimal)result.valor_minimo;
                ValorAtual = (decimal)result.valor_atual;
                VeiculoId = (int)result.veiculo;
                Aprovado = (bool)result.aprovado;
                ADecorrer = (bool)result.a_decorrer;
                Comprador = (string)result.comprador;
                if (result.tempo_de_leilao != null && result.tempo_de_leilao != DBNull.Value)
                {
                    TempoDeLeilao = (TimeSpan)result.tempo_de_leilao;
                }
                Imagem = (string)result.imagem;
            }
        }

        public Leilao() { } 
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