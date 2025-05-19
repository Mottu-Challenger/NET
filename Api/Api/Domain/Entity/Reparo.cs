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
        public long idReparo { get; set; }

        public string descricaoProblema { get; set; }

        public int precoReparo { get; set; }

        public DateTime dataSolicitacao { get; set; }

        public DateTime dataConclusao { get; set; }

        public double custoEstimado { get; set; }

        public double custoFinal { get; set; }

        public string responsavel { get; set; }


        public Moto motos { get; set; }
        public TypeStatus status { get; set; }
        public Check check { get; set; }
        public List<TypePeca> listPecasParaReparo { get; set; }

    }
}