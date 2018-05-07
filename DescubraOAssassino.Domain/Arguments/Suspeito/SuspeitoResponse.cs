namespace DescubraOAssassino.Domain.Arguments.Suspeito
{
    public class SuspeitoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator SuspeitoResponse(Entities.Suspeito v)
        {
            return new SuspeitoResponse
            {
                Id = v.Id,
                Nome = v.Nome
            };
        }
    }
}
