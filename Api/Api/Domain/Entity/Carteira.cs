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
        public long IDCarteira { get; set; }

        public int NumeroDaCNH { get; set; }

        public DateTime DataDaHabilitacaoInicial { get; set; }

        public DateTime DataDeEmissao { get; set; }

        public string Filiacao { get; set; }

        public string Assinatura { get; set; }

        public string Observacao { get; set; }

        public string Local { get; set; }

        public string AssinaturaDoEmissor { get; set; }

        public string FotoDaCNH { get; set; }

        public TypeEstado Estado { get; set; }

        public TypeCategoriaCarteira TypeCategoriaCarteira { get; set; }
        
        public string User {get; set;}
    }
}
