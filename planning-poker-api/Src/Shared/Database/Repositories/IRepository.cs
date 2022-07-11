using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningPokerApi.Src.Shared.Database.Repositories
{
  public interface IRepository<T>
  {
    Task<List<T>> All();

    Task<List<T>> ByParams(IDictionary<string, object> parameters);

    Task<T> ById(Guid id);

    Task<T> Create(T entity);

    Task Update(T entity);

    Task Delete(Guid id);
  }
}