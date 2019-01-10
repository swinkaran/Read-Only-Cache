using System;

namespace Azure.CachedStorage.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
