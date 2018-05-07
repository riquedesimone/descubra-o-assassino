namespace DescubraOAssassino.Domain.Arguments.Local
{
    public class LocalResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator LocalResponse(Entities.Local v)
        {
            return new LocalResponse
            {
                Id = v.Id,
                Nome = v.Nome
            };
        }
    }
}
