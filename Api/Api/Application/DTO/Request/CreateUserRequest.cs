namespace Api.Application.DTO.Request
{
    public class CreateUserRequest
    {
        public string nome { get; set; }

        public string email { get; set; }

        public string cpf { get; set; }

        public string rg { get; set; }

        public DateOnly dtaNasc { get; set; }

        public int numeroDeCadastro { get; set; }

        public bool ativo { get; set; }

        public string nacionalidade { get; set; }

        public string carteira { get; set; }

        public string enderco { get; set; }

        public string contato { get; set; }

        public string plano { get; set; }

        public long motoId { get; set; }
    }
}