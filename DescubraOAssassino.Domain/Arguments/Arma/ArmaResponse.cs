namespace DescubraOAssassino.Domain.Arguments.Arma
{
    public class ArmaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator ArmaResponse(Entities.Arma v)
        {
            return new ArmaResponse
            {
                Id = v.Id,
                Nome = v.Nome
            };
        }
    }
}
