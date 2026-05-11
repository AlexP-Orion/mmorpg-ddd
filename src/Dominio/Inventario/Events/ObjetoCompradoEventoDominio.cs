using Dominio.Abstracciones;

namespace Dominio.Inventario.Events;

public sealed record ObjetoCompradoEventoDominio(
    Guid InventarioId,
    Guid ObjetoId
) : IEventoDominio;