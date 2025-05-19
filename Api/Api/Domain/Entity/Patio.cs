using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Patios")]
    public class Patio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idPatio { get; set; }

        public string nome { get; set; }

        public int capacidade { get; set; }

        public int alocadas { get; set; }

        public Enderco enderco { get; set; }

        public List<Funcionario> funcionariosDaUnidade { get; set; }

    }
}