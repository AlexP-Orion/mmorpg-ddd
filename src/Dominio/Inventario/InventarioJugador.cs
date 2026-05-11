using Dominio.Abstracciones;
using Dominio.Jugadores;
using Dominio.Objetos;
using Dominio.Inventario.Events;

namespace Dominio.Inventario;

public sealed class InventarioJugador : Entidad
{
    private readonly List<ObjetoJuego> objetos = [];

    private InventarioJugador(Jugador jugador)
    {
        Jugador = jugador;
    }

    public Jugador Jugador { get; private set; }

    public IReadOnlyCollection<ObjetoJuego> Objetos => objetos.ToList();

    public static Resultado<InventarioJugador> Crear(
        Jugador jugador)
    {
        var inventario = new InventarioJugador(jugador);

        return Resultado.Exito(inventario);
    }

    public Resultado ComprarObjeto(ObjetoJuego objeto)
    {
        if (!Jugador.Oro.EsSuficiente(objeto.Precio))
        {
            return Resultado.Fallo(
                ErroresInventario.OroInsuficiente
            );
        }

        Jugador.DescontarOro(objeto.Precio);

        objetos.Add(objeto);

        RegistrarEventoDominio(
            new ObjetoCompradoEventoDominio(Id, objeto.Id)
        );

        return Resultado.Exito();
    }
}