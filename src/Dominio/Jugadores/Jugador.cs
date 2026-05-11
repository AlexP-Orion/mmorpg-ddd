  using Dominio.Abstracciones;
  using Dominio.Compartido;
  
  namespace Dominio.Jugadores;
  
  public sealed class Jugador : Entidad
  {
      private Jugador(
          NombreJugador nombre,
          Oro oro,
          int nivel)
      {
          Nombre = nombre;
          Oro = oro;
          Nivel = nivel;
      }
  
      public NombreJugador Nombre { get; private set; }
  
      public Oro Oro { get; private set; }
  
      public int Nivel { get; private set; }
  
      public static Resultado<Jugador> Crear(
          NombreJugador nombre)
      {
          var jugador = new Jugador(
              nombre,
              new Oro(500),
              1);
  
          return Resultado.Exito(jugador);
      }
  
      public void DescontarOro(Oro costo)
      {
          Oro -= costo;
      }
  }