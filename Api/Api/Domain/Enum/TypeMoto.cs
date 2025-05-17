namespace Api.Domain.Enum;

public enum TypeMoto
{
    SPORT_ESD,
    SPORT,
    E_MAX

}

public static class MyClass
{
    public static String getDescricao(this TypeMoto typeMoto)
    {
        return typeMoto switch
        {
            TypeMoto.SPORT_ESD => "Moto esportiva",
            TypeMoto.SPORT => "Moto esportiva",
            TypeMoto.E_MAX => "Scooter elétrica E-Max"

        };
    }
}