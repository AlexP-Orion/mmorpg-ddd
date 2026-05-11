using Dominio.Abstracciones;

namespace Dominio.Inventario;

public static class ErroresInventario
{
    public static ErrorDominio OroInsuficiente = new(
        "Inventario.OroInsuficiente",
        "El jugador no tiene suficiente oro"
    );
}