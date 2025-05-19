using Api.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    }
}
