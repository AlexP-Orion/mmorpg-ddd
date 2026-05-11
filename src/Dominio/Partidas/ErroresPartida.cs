using Dominio.Abstracciones;

namespace Dominio.Partidas;

public static class ErroresPartida
{
    public static ErrorDominio CantidadJugadoresInvalida = new(
        "Partida.CantidadJugadoresInvalida",
        "La partida requiere exactamente 10 jugadores"
    );
}