namespace Dominio.Compartido;

public record Oro(decimal Cantidad)
{
    public static Oro operator +(Oro primero, Oro segundo)
    {
        return new Oro(primero.Cantidad + segundo.Cantidad);
    }

    public static Oro operator -(Oro primero, Oro segundo)
    {
        return new Oro(primero.Cantidad - segundo.Cantidad);
    }

    public bool EsSuficiente(Oro costo)
    {
        return Cantidad >= costo.Cantidad;
    }
}