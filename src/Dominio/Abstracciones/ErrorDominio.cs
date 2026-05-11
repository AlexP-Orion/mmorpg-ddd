namespace Dominio.Abstracciones;

public record ErrorDominio(string Codigo, string Nombre)
{
    public static ErrorDominio Ninguno = new(
        string.Empty,
        string.Empty
    );

    public static ErrorDominio ValorNulo = new(
        "Error.ValorNulo",
        "Se proporcionó un valor nulo"
    );
}