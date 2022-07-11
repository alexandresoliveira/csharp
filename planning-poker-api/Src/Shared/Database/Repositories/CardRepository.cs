using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanningPokerApi.Src.Shared.Database.Entities;

using PlanningPokerApi.Src.Shared.Database.Contexts;

namespace PlanningPokerApi.Src.Shared.Database.Repositories
{
  internal class CardRepository : IRepository<CardEntity>
  {

    private ApiContext _context;

    public CardRepository(ApiContext context)
    {
      _context = context;
    }

    public Task<List<CardEntity>> All()
    {
      throw new NotImplementedException();
    }

    public async Task<CardEntity> ById(Guid id)
    {
      var result = await _context.Cards.FindAsync(id);
      return result;
    }

    public Task<List<CardEntity>> ByParams(IDictionary<string, object> parameters)
    {
      throw new NotImplementedException();
    }

    public async Task<CardEntity> Create(CardEntity entity)
    {
      var result = await _context.Cards.AddAsync(entity);
      await _context.SaveChangesAsync();
      return result.Entity;
    }

    public Task Delete(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task Update(CardEntity entity)
    {
      throw new NotImplementedException();
    }
  }
}