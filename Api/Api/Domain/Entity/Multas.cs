using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Multas")]
    public class Multas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdMultas { get; set; }

        public string PlacaMoto { get; set; }

        public string Descricao { get; set; }

        public double Valor { get; set; }

        public DateTime DataMulta { get; set; }

        public bool Paga { get; set; }

        public string Moto { get; set; }

    }
}