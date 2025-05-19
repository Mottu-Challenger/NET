using Api.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idFuncionario { get; set; }

        public string nomeFuncionario { get; set; }

        public string password { get; set; }

        public string UuerName { get; set; }

        public DateTime entradaFuncionario { get; set; }

        public DateTime saidaFuncionario { get; set; }

        public TypeCargo cargo { get; set; }

        public List<Moto> motosNaResponsabilidadeDoFuncionario { get; set; }

    }
}