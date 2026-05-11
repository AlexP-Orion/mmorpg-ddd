using Dominio.Jugadores;
using Dominio.Partidas;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "API MMORPG DDD funcionando");

app.MapGet("/partida", () =>
{
    var jugadores = new List<Jugador>();

    for (int i = 1; i <= 10; i++)
    {
        var resultadoJugador = Jugador.Crear(
            new NombreJugador($"Jugador{i}")
        );

        jugadores.Add(resultadoJugador.Valor);
    }

    var resultadoPartida = Partida.Crear(jugadores);

    if (resultadoPartida.EsFallo)
    {
        return Results.BadRequest(
            resultadoPartida.Error
        );
    }

    return Results.Ok(new
    {
        PartidaId = resultadoPartida.Valor.Id,
        Estado = resultadoPartida.Valor.Estado.Nombre,
        Jugadores = resultadoPartida.Valor.Jugadores.Count
    });
});

app.Run();