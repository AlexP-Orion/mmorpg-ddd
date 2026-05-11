using Dominio.Abstracciones;
using Dominio.Jugadores;
using Dominio.Partidas.Events;

namespace Dominio.Partidas;

public sealed class Partida : Entidad
{
    private readonly List<Jugador> jugadores = [];

    private Partida(
        List<Jugador> jugadores,
        EstadoPartida estado)
    {
        this.jugadores = jugadores;
        Estado = estado;
    }

    public IReadOnlyCollection<Jugador> Jugadores => jugadores.ToList();

    public EstadoPartida Estado { get; private set; }

    public static Resultado<Partida> Crear(
        List<Jugador> jugadores)
    {
        if (jugadores.Count != 10)
        {
            return Resultado.Fallo<Partida>(
                ErroresPartida.CantidadJugadoresInvalida
            );
        }

        var partida = new Partida(
            jugadores,
            EstadoPartida.EnEspera
        );

        partida.RegistrarEventoDominio(
            new PartidaCreadaEventoDominio(partida.Id)
        );

        return Resultado.Exito(partida);
    }
}