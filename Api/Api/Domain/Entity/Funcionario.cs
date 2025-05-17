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
        public long IDFuncionario { get; set; }

        public string NomeFuncionario { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public DateTime EntradaFuncionario { get; set; }

        public DateTime SaidaFuncionario { get; set; }

        public TypeCargo Cargo { get; set; }

        // Relacionamento 1:N com Moto
        public List<Moto> MotosNaResponsabilidadeDoFuncionario { get; set; }

    }
}