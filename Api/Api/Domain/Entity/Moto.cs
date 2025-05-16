using Api.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entity
{
    [Table("Motos")]
    public class Moto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IDMoto { get; set; }

        public DateTime AnoDelançamento { get; set; }

        public int Quilometragem { get; set; }

        public int AnoDeFabricacao { get; set; }

        public string Placa { get; set; }

        public string TagDaMoto { get; set; }

        public string Chassi { get; set; }

        public string Observacao { get; set; }

        public string FotoDaMoto { get; set; }

        public bool IPVA { get; set; }

        public bool Licenciamento { get; set; }

        public bool DPVAT { get; set; }

        public TypeCombustivel Combustivel { get; set; }

        public TypeMoto TypeMoto { get; set; }

        // Relação N:1 com User
        public User User { get; set; }

        public string PatioAtual { get; set; }

        public string PlanoAssociado { get; set; }

        public string Multas { get; set; }

        public string HistoricoDeReparos { get; set; }

        public string HistoricoDeChecks { get; set; }

    }
}
