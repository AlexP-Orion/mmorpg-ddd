using Dominio.Abstracciones;

namespace Dominio.Partidas.Events;

public sealed record PartidaCreadaEventoDominio(
    Guid PartidaId
) : IEventoDominio;