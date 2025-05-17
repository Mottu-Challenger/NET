namespace Api.Domain.Enum
{
    public enum TypePeca
    {
        RETROVISORES,
        MOTOR,
        CABECOTE,
        CILINDRO,
        PISTAO,
        VIRABREQUIM,
        SISTEMA_DE_EMBREAGEM,
        CAMBIO,
        CORRENTE,
        COROA,
        PINHAO,
        CARBURADOR,
        INJECAO_ELETRONICA,
        FILTRO_DE_AR,
        BOMBA_DE_COMBUSTIVEL,
        RADIADOR,
        ALETAS,
        ESCAPAMENTO,
        BATERIA,
        ALTERNADOR,
        VELAS_DE_IGNICAO,
        CENTRAL_ELETRONICA,
        DISCOS_OU_TAMBORES,
        PINCAS_DE_FREIO,
        PASTILHAS,
        MANETE,
        PEDAL_DE_FREIO,
        GARFO_DIANTEIRO,
        AMORTECEDORES_TRASEIROS
    }

    public static class TypePecaExtensions
    {
        public static string GetDescricao(this TypePeca typePeca)
        {
            return typePeca switch
            {
                TypePeca.RETROVISORES => "Espelhos laterais",
                TypePeca.MOTOR => "Motor completo",
                TypePeca.CABECOTE => "Cabeçote do motor",
                TypePeca.CILINDRO => "Cilindro do motor",
                TypePeca.PISTAO => "Pistão do motor",
                TypePeca.VIRABREQUIM => "Virabrequim do motor",
                TypePeca.SISTEMA_DE_EMBREAGEM => "Conjunto da embreagem",
                TypePeca.CAMBIO => "Sistema de câmbio",
                TypePeca.CORRENTE => "Corrente de transmissão",
                TypePeca.COROA => "Coroa da transmissão",
                TypePeca.PINHAO => "Pinhão da transmissão",
                TypePeca.CARBURADOR => "Sistema de carburador",
                TypePeca.INJECAO_ELETRONICA => "Sistema de injeção eletrônica",
                TypePeca.FILTRO_DE_AR => "Filtro de ar do motor",
                TypePeca.BOMBA_DE_COMBUSTIVEL => "Bomba de combustível",
                TypePeca.RADIADOR => "Radiador de refrigeração",
                TypePeca.ALETAS => "Aletas de refrigeração",
                TypePeca.ESCAPAMENTO => "Sistema de escapamento",
                TypePeca.BATERIA => "Bateria da moto",
                TypePeca.ALTERNADOR => "Alternador",
                TypePeca.VELAS_DE_IGNICAO => "Velas de ignição",
                TypePeca.CENTRAL_ELETRONICA => "Central eletrônica (ECU)",
                TypePeca.DISCOS_OU_TAMBORES => "Discos ou tambores de freio",
                TypePeca.PINCAS_DE_FREIO => "Pinças de freio",
                TypePeca.PASTILHAS => "Pastilhas de freio",
                TypePeca.MANETE => "Manete de freio/embreagem",
                TypePeca.PEDAL_DE_FREIO => "Pedal de freio",
                TypePeca.GARFO_DIANTEIRO => "Garfo dianteiro",
                TypePeca.AMORTECEDORES_TRASEIROS => "Amortecedores traseiros",
                _ => "Peça desconhecida"
            };
        }

        public static double GetPreco(this TypePeca typePeca)
        {
            return typePeca switch
            {
                TypePeca.RETROVISORES => 120.00,
                TypePeca.MOTOR => 3500.00,
                TypePeca.CABECOTE => 800.00,
                TypePeca.CILINDRO => 600.00,
                TypePeca.PISTAO => 150.00,
                TypePeca.VIRABREQUIM => 700.00,
                TypePeca.SISTEMA_DE_EMBREAGEM => 900.00,
                TypePeca.CAMBIO => 1200.00,
                TypePeca.CORRENTE => 180.00,
                TypePeca.COROA => 160.00,
                TypePeca.PINHAO => 100.00,
                TypePeca.CARBURADOR => 450.00,
                TypePeca.INJECAO_ELETRONICA => 900.00,
                TypePeca.FILTRO_DE_AR => 80.00,
                TypePeca.BOMBA_DE_COMBUSTIVEL => 300.00,
                TypePeca.RADIADOR => 650.00,
                TypePeca.ALETAS => 100.00,
                TypePeca.ESCAPAMENTO => 700.00,
                TypePeca.BATERIA => 350.00,
                TypePeca.ALTERNADOR => 500.00,
                TypePeca.VELAS_DE_IGNICAO => 60.00,
                TypePeca.CENTRAL_ELETRONICA => 1000.00,
                TypePeca.DISCOS_OU_TAMBORES => 300.00,
                TypePeca.PINCAS_DE_FREIO => 250.00,
                TypePeca.PASTILHAS => 120.00,
                TypePeca.MANETE => 90.00,
                TypePeca.PEDAL_DE_FREIO => 110.00,
                TypePeca.GARFO_DIANTEIRO => 950.00,
                TypePeca.AMORTECEDORES_TRASEIROS => 880.00,
                _ => 0.00
            };
        }
    }
}