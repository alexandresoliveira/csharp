using Microsoft.Extensions.DependencyInjection;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.Shared.Database.Entities;
using PlanningPokerApi.Src.Shared.Business;
using PlanningPokerApi.Src.UseCases.V1.Votes.Create;

namespace PlanningPokerApi.Src.Shared.Injects
{
  public class VotesCreateInject
  {
    public void Invoke(IServiceCollection services)
    {
      services.AddScoped<IRepository<VoteEntity>, VotesRepository>();
      services.AddScoped<IBusiness<VotesCreateRequestDto, VotesCreateResponseDto>, VotesCreateBO>();
    }
  }
}