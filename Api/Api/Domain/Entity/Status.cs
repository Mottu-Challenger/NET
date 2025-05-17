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
        public long IDStatus { get; set; }

        public TypeStatus StatusTipo { get; set; }

        public string Motos { get; set; }

        public string Reparo { get; set; }

    }
}