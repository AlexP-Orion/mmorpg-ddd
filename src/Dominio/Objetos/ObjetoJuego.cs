using Dominio.Abstracciones;
using Dominio.Compartido;

namespace Dominio.Objetos;

public sealed class ObjetoJuego : Entidad
{
    private ObjetoJuego(
        string nombre,
        Oro precio)
    {
        Nombre = nombre;
        Precio = precio;
    }

    public string Nombre { get; private set; }

    public Oro Precio { get; private set; }

    public static Resultado<ObjetoJuego> Crear(
        string nombre,
        Oro precio)
    {
        var objeto = new ObjetoJuego(nombre, precio);

        return Resultado.Exito(objeto);
    }
}