using Api.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Planos")]
    public class Plano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idPlano { get; set; }

        public double precoSemanal { get; set; }

        public double precoMensal { get; set; }

        public bool incluiSeguro { get; set; }

        public bool incluiManutencao { get; set; }

        public bool permiteTrocaDeMoto { get; set; }

        public bool incluiAssistencia24h { get; set; }

        public bool permiteCompraFutura { get; set; }

        public TypePlano planos { get; set; }

        public TypeMoto typeMoto { get; set; }

        public Moto moto { get; set; }

    }
}