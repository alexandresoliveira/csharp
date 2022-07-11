using Microsoft.Extensions.DependencyInjection;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.Shared.Database.Entities;
using PlanningPokerApi.Src.Shared.Business;
using PlanningPokerApi.Src.UseCases.V1.UsersHistory.Create;

namespace PlanningPokerApi.Src.Shared.Injects
{
  public class UsersHistoryCreateInject
  {
    public void Invoke(IServiceCollection services)
    {
      services.AddScoped<IRepository<UsersHistoryEntity>, UsersHistoryRepository>();
      services.AddScoped<IBusiness<UsersHistoryCreateRequestDto, UsersHistoryCreateResponseDto>, UsersHistoryCreateBO>();
    }
  }
}