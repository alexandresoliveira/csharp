using System;
using System.Collections.Generic;
using PlanningPokerApi.Src.Shared.Database.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanningPokerApi.Src.Shared.Database.Contexts;

namespace PlanningPokerApi.Src.Shared.Database.Repositories
{
  internal class UsersHistoryRepository : IRepository<UsersHistoryEntity>
  {

    private readonly ApiContext _context;

    public UsersHistoryRepository(ApiContext context)
    {
      _context = context;
    }

    public async Task<List<UsersHistoryEntity>> All()
    {
      var users = await _context.UsersHistories.ToListAsync();
      return users;
    }

    public async Task<UsersHistoryEntity> ById(Guid id)
    {
      var user = await _context.UsersHistories.FindAsync(id);
      return user;
    }

    public Task<List<UsersHistoryEntity>> ByParams(IDictionary<string, object> parameters)
    {
      throw new NotImplementedException();
    }

    public async Task<UsersHistoryEntity> Create(UsersHistoryEntity entity)
    {
      var result = _context.UsersHistories.Add(entity);
      await _context.SaveChangesAsync();
      return result.Entity;
    }

    public async Task Delete(Guid id)
    {
      var entity = await _context.UsersHistories.FindAsync(id);
      if (entity == null) throw new Exception("Entity not found!");
      _context.UsersHistories.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Update(UsersHistoryEntity entity)
    {
      _context.UsersHistories.Update(entity);
      await _context.SaveChangesAsync();
    }
  }
}