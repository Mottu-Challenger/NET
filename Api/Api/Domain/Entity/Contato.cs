using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Contatos")]
    public class Contato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdContato { get; set; }

        public string Ddi { get; set; }

        public string Ddd { get; set; }

        public string Numero { get; set; }

    }
}