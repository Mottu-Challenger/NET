using Api.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Reparos")]
    public class Reparo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IDReparo { get; set; }

        public string DescricaoProblema { get; set; }

        public int PrecoReparo { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public DateTime DataConclusao { get; set; }

        public double CustoEstimado { get; set; }

        public double CustoFinal { get; set; }

        public string Responsavel { get; set; }


        public string Motos { get; set; }


        public string Status { get; set; }

        public string Check { get; set; }

        // Enum múltiplo - poderá exigir tratamento especial no EF
        public List<TypePeca> ListPecasParaReparo { get; set; }

    }
}