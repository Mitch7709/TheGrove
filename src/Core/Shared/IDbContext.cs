using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Shared;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity;

    Task<int> SaveChangesAsync();
}
