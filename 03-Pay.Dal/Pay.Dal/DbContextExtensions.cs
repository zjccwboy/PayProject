using Pay.Base.Common.Enums.Utils;
using Pay.Dal;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

public static class DbContextExtensions
{
    public static Task AddOneAsync<TEntity>(this PaySystemContext dbContext, TEntity entity) where TEntity : BaseEntity
    {
        SetKeyValue(typeof(TEntity), entity);
        return dbContext.AddAsync(entity);
    }

    private static void SetKeyValue(Type type, object entity)
    {
        var propes = type.GetProperties();
        var prope = propes.Where(a => a.GetCustomAttribute(typeof(KeyAttribute)) != null).FirstOrDefault();
        var value = (long)prope.GetValue(entity);
        if (value == 0)
        {
            value = KeyCreator.CreateKey();
            prope.SetValue(entity, value);
        }
    }
}