using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Checks")]
    public class Check
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idCheck { get; set; }
        
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        
        public Moto moto { get; set; }
        public Funcionario funcionario { get; set; }
        
    }
}