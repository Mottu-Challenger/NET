using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Api.Domain.Exceptions;

namespace Api.Domain.Entity
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IDUser { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public int CPF { get; set; }
        public string RG { get; set; }
        public DateTime DtaNasc { get; set; }
        public int NumeroDeCadastro { get; set; }
        public bool Ativo { get; set; }

        // Representações simples como strings (pode ser substituído por FK depois)
        public string Nacionalidade { get; set; }
        public string Carteira { get; set; }
        public string Enderco { get; set; }
        public string Contato { get; set; }
        public string Plano { get; set; }

        // Relacionamento direto com a moto associada
        public Moto Motos { get; set; }

        public User(long idUser, string nome, string email, int cpf, string rg, DateTime dtaNasc, int numeroDeCadastro, bool ativo, string nacionalidade, string carteira, string enderco, string contato, string plano, Moto motos)
        {
            ValidadorDeRg(rg);
            ValidadorDeCPF(cpf);
            IDUser = idUser;
            Nome = nome;
            Email = email;
            CPF = cpf;
            RG = rg;
            DtaNasc = dtaNasc;
            NumeroDeCadastro = numeroDeCadastro;
            Ativo = ativo;
            Nacionalidade = nacionalidade;
            Carteira = carteira;
            Enderco = enderco;
            Contato = contato;
            Plano = plano;
            Motos = motos;
        }

        public User()
        {
        }

        private void ValidadorDeRg(string rg)
        {
            if (string.IsNullOrEmpty(rg))
                throw new DomainException("RG não pode ser vazio.");

            // Remove tudo que não for número
            string rgNumeros = Regex.Replace(rg, @"[^\d]", "");

            // Verifica se tem exatamente 9 dígitos
            if (rgNumeros.Length != 9)
                throw new DomainException("RG deve conter exatamente 9 dígitos.");

            // Verifica se todos os números são iguais (ex: 111111111)
            if (new string(rgNumeros[0], 9) == rgNumeros)
                throw new DomainException("RG inválido.");
        }

        public static void ValidadorDeCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                throw new DomainException("CPF não pode ser vazio.");
            
            cpf = Regex.Replace(cpf, @"[^\d]", "");

            if (cpf.Length != 11)
                throw new DomainException("CPF deve conter 11 dígitos.");

            if (new string(cpf[0], 11) == cpf)
                throw new DomainException("CPF inválido.");

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int resto = soma % 11;
            int digito1 = (resto < 2) ? 0 : 11 - resto;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            resto = soma % 11;
            int digito2 = (resto < 2) ? 0 : 11 - resto;

            if (digito1 != (cpf[9] - '0') || digito2 != (cpf[10] - '0'))
                throw new DomainException("CPF inválido.");
        }

        internal static User Create(long idUser, string nome, string email, int cpf, string rg, DateTime dtaNasc, int numeroDeCadastro, bool ativo, string nacionalidade, string carteira, string enderco, string contato, string plano, Moto motos)
        {
            return new User(idUser, nome, email, cpf, rg, dtaNasc, numeroDeCadastro, ativo, nacionalidade, carteira, enderco, contato, plano, motos);
        }
    }
}