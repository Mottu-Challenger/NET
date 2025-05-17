using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Checks")]
    public class Check
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IDCheck { get; set; }

        //Date
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        
        // Relacionamentos
        public string Moto { get; set; }
        public string Funcionario { get; set; }
        
    }
}