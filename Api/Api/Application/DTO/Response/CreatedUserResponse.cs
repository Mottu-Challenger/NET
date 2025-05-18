namespace Api.Application.DTO.Response
{
    public class CreatedUserResponse
    {
        public long IDUser { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public DateOnly DtaNasc { get; set; }

        public int NumeroDeCadastro { get; set; }

        public bool Ativo { get; set; }

        public string Nacionalidade { get; set; }

        public string Carteira { get; set; }

        public string Enderco { get; set; }

        public string Contato { get; set; }

        public string Plano { get; set; }

        public long MotoId { get; set; }
    }
}