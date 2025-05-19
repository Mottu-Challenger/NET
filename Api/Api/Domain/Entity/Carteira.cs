using Api.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Carteiras")]
    public class Carteira
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idCarteira { get; set; }

        public int numeroDaCNH { get; set; }

        public DateTime dataDaHabilitacaoInicial { get; set; }

        public DateTime dataDeEmissao { get; set; }

        public string filiacao { get; set; }

        public string assinatura { get; set; }

        public string observacao { get; set; }

        public Enderco local { get; set; }

        public string assinaturaDoEmissor { get; set; }

        public string fotoDaCNH { get; set; }

        public TypeEstado estado { get; set; }

        public TypeCategoriaCarteira typeCategoriaCarteira { get; set; }
        
        public User user {get; set;}
    }
}
