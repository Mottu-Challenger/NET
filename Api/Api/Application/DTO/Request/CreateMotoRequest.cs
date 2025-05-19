namespace Api.Application.DTO.Request
{
    public class CreateMotoRequest
    {
        public DateOnly anoDeLancamento { get; set; }

        public int quilometragem { get; set; }

        public int anoDeFabricacao { get; set; }

        public string placa { get; set; }

        public string tagDaMoto { get; set; }

        public string chassi { get; set; }

        public string observacao { get; set; }

        public string fotoDaMoto { get; set; }

        public bool ipva { get; set; }

        public bool licenciamento { get; set; }

        public bool dpvat { get; set; }

        public int combustivel { get; set; }

        public int typeMotos { get; set; }

        public string patioAtual { get; set; }

        public string planoAssociado { get; set; }

        public string multas { get; set; }

        public string historicoDeReparos { get; set; }

        public string historicoDeChecks { get; set; }

        public long userId { get; set; }
    }
}