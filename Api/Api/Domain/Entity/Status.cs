using Api.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Status")]
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idStatus { get; set; }

        public TypeStatus statusTipo { get; set; }

        public Moto motos { get; set; }

        public Reparo reparo { get; set; }

    }
}