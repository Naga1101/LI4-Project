using Dapper;

namespace JBleiloes.data.Leiloes
{
    public class Leilao
    {
        public int id { get; private set; }
        public string? titulo { get; private set; }
        public decimal valor_inicial { get; private set; }
        public string? vendedor { get; private set; }
        public decimal valor_minimo { get; private set; }
        public decimal valor_atual { get; set; }
        public int veiculo { get; private set; }
        public bool aprovado { get; private set; }
        public bool a_decorrer { get; private set; }
        public string? comprador { get; private set; }
        public DateTime tempo_de_leilao { get; set; }
        public string? imagem { get; private set; }
        public bool Pago { get; private set; }

        public Leilao(SqlMapper.GridReader reader)
        {
            var result = reader.Read().SingleOrDefault();

            if (result != null)
            {
                id = (int)result.id;
                titulo = (string)result.titulo;
                valor_inicial = (decimal)result.valor_inicial;
                vendedor = (string)result.vendedor;
                valor_minimo = (decimal)result.valor_minimo;
                valor_atual = (decimal)result.valor_atual;
                veiculo = (int)result.veiculo;
                aprovado = (bool)result.aprovado;
                a_decorrer = (bool)result.a_decorrer;
                comprador = (string)result.comprador;
                if (result.tempo_de_leilao != null && result.tempo_de_leilao != DBNull.Value)
                {
                    tempo_de_leilao = (DateTime)result.tempo_de_leilao;
                }
                imagem = (string)result.imagem;
                Pago = (bool)result.pago;
            }
        }

        public Leilao() { } 
    }
}