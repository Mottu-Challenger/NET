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
        public long idUser { get; set; }

        public string nome { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public DateTime dtaNasc { get; set; }
        public int numeroDeCadastro { get; set; }
        public bool ativo { get; set; }
        
        public string nacionalidade { get; set; }
        public string carteira { get; set; }
        public string enderco { get; set; }
        public string contato { get; set; }
        public string plano { get; set; }
        
        public Moto motos { get; set; }

        public User(long idUser, string nome, string email, string cpf, string rg, DateTime dtaNasc, int numeroDeCadastro, bool ativo, string nacionalidade, string carteira, string enderco, string contato, string plano, Moto motos)
        {
            this.idUser = idUser;
            this.nome = nome;
            this.email = email;
            this.cpf = cpf;
            this.rg = rg;
            this.dtaNasc = dtaNasc;
            this.numeroDeCadastro = numeroDeCadastro;
            this.ativo = ativo;
            this.nacionalidade = nacionalidade;
            this.carteira = carteira;
            this.enderco = enderco;
            this.contato = contato;
            this.plano = plano;
            this.motos = motos;
        }

        public User()
        {
        }

        private void ValidadorDeRg(string rg)
        {
            if (string.IsNullOrEmpty(rg))
                throw new DomainException("RG não pode ser vazio.");

            string rgNumeros = Regex.Replace(rg, @"[^\d]", "");

            if (rgNumeros.Length != 9)
                throw new DomainException("RG deve conter exatamente 9 dígitos.");

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

        internal static User Create(long idUser, string nome, string email, string cpf, string rg, DateTime dtaNasc, int numeroDeCadastro, bool ativo, string nacionalidade, string carteira, string enderco, string contato, string plano, Moto motos)
        {
            return new User(idUser, nome, email, cpf, rg, dtaNasc, numeroDeCadastro, ativo, nacionalidade, carteira, enderco, contato, plano, motos);
        }
    }
}