using System;

public abstract class BaseEntity
{
    public long? CreateBy { get; set; }
    public DateTime? CreateTime { get; set; }
    public long? UpdateBy { get; set; }
    public DateTime? UpdateTime { get; set; }
}

public static class EntityExtensions
{
    public static void SetCreator<TEntity>(this TEntity entity, long creatorId) where TEntity : BaseEntity
    {
        entity.CreateBy = creatorId;
        entity.CreateTime = DateTime.UtcNow;
    }

    public static void SetUpdater<TEntity>(this TEntity entity, long creatorId) where TEntity : BaseEntity
    {
        entity.UpdateBy = creatorId;
        entity.UpdateTime = DateTime.UtcNow;
    }
}