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
        public long IDPlano { get; set; }

        public double PrecoSemanal { get; set; }

        public double PrecoMensal { get; set; }

        public bool IncluiSeguro { get; set; }

        public bool IncluiManutencao { get; set; }

        public bool PermiteTrocaDeMoto { get; set; }

        public bool IncluiAssistencia24h { get; set; }

        public bool PermiteCompraFutura { get; set; }

        public TypePlano Planos { get; set; }

        public TypeMoto TypeMoto { get; set; }

        public string Moto { get; set; }

    }
}