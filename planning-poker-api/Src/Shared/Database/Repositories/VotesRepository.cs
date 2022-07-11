using System;
using System.Collections.Generic;
using PlanningPokerApi.Src.Shared.Database.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanningPokerApi.Src.Shared.Database.Contexts;

namespace PlanningPokerApi.Src.Shared.Database.Repositories
{
  internal class VotesRepository : IRepository<VoteEntity>
  {

    private ApiContext _context;

    public VotesRepository(ApiContext context)
    {
      _context = context;
    }

    public Task<List<VoteEntity>> All()
    {
      throw new NotImplementedException();
    }

    public Task<VoteEntity> ById(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<List<VoteEntity>> ByParams(IDictionary<string, object> parameters)
    {
      throw new NotImplementedException();
    }

    public async Task<VoteEntity> Create(VoteEntity entity)
    {
      var result = await _context.Votes.AddAsync(entity);
      await _context.SaveChangesAsync();
      return result.Entity;
    }

    public Task Delete(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task Update(VoteEntity entity)
    {
      throw new NotImplementedException();
    }
  }
}