namespace Api.Application.DTO.Response
{
    public class CreatedMotoResponse
    {
        public long IDMoto { get; set; }

        public DateOnly AnoDelançamento { get; set; }

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

        public string Combustivel { get; set; }

        public string TypeMotos { get; set; }

        public string PatioAtual { get; set; }

        public string PlanoAssociado { get; set; }

        public string Multas { get; set; }

        public string HistoricoDeReparos { get; set; }

        public string HistoricoDeChecks { get; set; }

        public long UserId { get; set; }
    }
}