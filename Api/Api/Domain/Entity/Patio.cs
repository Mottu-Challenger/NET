using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Patios")]
    public class Patio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IDPatio { get; set; }

        public string Nome { get; set; }

        public int Capacidade { get; set; }

        public int Alocadas { get; set; }

        public string Enderco { get; set; }

        public List<Funcionario> FuncionariosDaUnidade { get; set; }

    }
}