using Dominio.Abstracciones;

namespace Dominio.Partidas;

public sealed record EstadoPartida : Enumerador
{
    public static readonly EstadoPartida EnEspera = new(
        "En Espera",
        1
    );

    public static readonly EstadoPartida Activa = new(
        "Activa",
        2
    );

    public static readonly EstadoPartida Finalizada = new(
        "Finalizada",
        3
    );

    private EstadoPartida(string nombre, int valor)
        : base(nombre, valor)
    {
    }
}