using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Multas")]
    public class Multas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idMultas { get; set; }

        public string placaMoto { get; set; }

        public string descricao { get; set; }

        public double valor { get; set; }

        public DateTime dataMulta { get; set; }

        public bool paga { get; set; }

        public Moto moto { get; set; }

    }
}