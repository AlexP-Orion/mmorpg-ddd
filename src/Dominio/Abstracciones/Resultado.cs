namespace Dominio.Abstracciones;

public class Resultado
{
    protected Resultado(
        bool esExitoso,
        ErrorDominio error)
    {
        if (esExitoso && error != ErrorDominio.Ninguno)
        {
            throw new InvalidOperationException();
        }

        if (!esExitoso && error == ErrorDominio.Ninguno)
        {
            throw new InvalidOperationException();
        }

        EsExitoso = esExitoso;
        Error = error;
    }

    public bool EsExitoso { get; }

    public bool EsFallo => !EsExitoso;

    public ErrorDominio Error { get; }

    public static Resultado Exito() =>
        new(true, ErrorDominio.Ninguno);

    public static Resultado Fallo(
        ErrorDominio error) =>
        new(false, error);

    public static Resultado<TValor> Exito<TValor>(
        TValor valor)
    {
        return new Resultado<TValor>(
            valor,
            true,
            ErrorDominio.Ninguno
        );
    }

    public static Resultado<TValor> Fallo<TValor>(
        ErrorDominio error)
    {
        return new Resultado<TValor>(
            default,
            false,
            error
        );
    }
}

public class Resultado<TValor> : Resultado
{
    private readonly TValor? valor;

    protected internal Resultado(
        TValor? valor,
        bool esExitoso,
        ErrorDominio error)
        : base(esExitoso, error)
    {
        this.valor = valor;
    }

    public TValor Valor =>
        EsExitoso
            ? valor!
            : throw new InvalidOperationException(
                "El valor de un resultado fallido no puede ser accedido"
            );
}