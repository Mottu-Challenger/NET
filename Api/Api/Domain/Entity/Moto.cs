using Api.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Api.Domain.Exceptions;

namespace Api.Domain.Entity
{
    [Table("Motos")]
    public class Moto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idMoto { get; set; }

        public DateTime anoDeLancamento { get; set; }

        public int quilometragem { get; set; }

        public int anoDeFabricacao { get; set; }

        public string placa { get; set; }

        public string tagDaMoto { get; set; }

        public string chassi { get; set; }

        public string observacao { get; set; }

        public string fotoDaMoto { get; set; }

        public bool ipva { get; set; }

        public bool licenciamento { get; set; }

        public bool dpvat { get; set; }

        public TypeCombustivel combustivel { get; set; }

        public TypeMoto typeMoto { get; set; }

        public User user { get; set; }

        public string patioAtual { get; set; }

        public string planoAssociado { get; set; }

        public string multas { get; set; }

        public string historicoDeReparos { get; set; }

        public string historicoDeChecks { get; set; }

        public Moto(long idMoto, DateTime anoDeLancamento, int quilometragem, int anoDeFabricacao, string placa, string tagDaMoto, string chassi, string observacao, string fotoDaMoto, bool ipva, bool licenciamento, bool dpvat, TypeCombustivel combustivel, TypeMoto typeMoto, User user, string patioAtual, string planoAssociado, string multas, string historicoDeReparos, string historicoDeChecks)
        {
            
            ValidarPlaca(placa);
            ValidarChassi(chassi);
            this.idMoto = idMoto;
            this.anoDeLancamento = anoDeLancamento;
            this.quilometragem = quilometragem;
            this.anoDeFabricacao = anoDeFabricacao;
            this.placa = placa;
            this.tagDaMoto = tagDaMoto;
            this.chassi = chassi;
            this.observacao = observacao;
            this.fotoDaMoto = fotoDaMoto;
            this.ipva = ipva;
            this.licenciamento = licenciamento;
            this.dpvat = dpvat;
            this.combustivel = combustivel;
            this.typeMoto = typeMoto;
            this.user = user;
            this.patioAtual = patioAtual;
            this.planoAssociado = planoAssociado;
            this.multas = multas;
            this.historicoDeReparos = historicoDeReparos;
            this.historicoDeChecks = historicoDeChecks;
        }

        public Moto()
        {
        }

        private void ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                throw new DomainException("Placa não pode ser vazia.");

            placa = placa.ToUpper().Trim();

            var regex = new Regex(@"^[A-Z]{3}\d[A-Z]\d{2}$");

            if (!regex.IsMatch(placa))
                throw new DomainException("Placa inválida. O formato correto é ABC1D23.");
        }

        private void ValidarChassi(string chassi)
        {
            if (string.IsNullOrWhiteSpace(chassi))
                throw new DomainException("Chassi não pode ser vazio.");

            chassi = chassi.Trim().ToUpper();

            var regex = new Regex(@"^[A-HJ-NPR-Z0-9]{17}$");

            if (!regex.IsMatch(chassi))
                throw new DomainException("Chassi inválido. Deve ter 17 caracteres e não pode conter I, O ou Q.");
        }

    }
}
