using Microsoft.Extensions.DependencyInjection;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.Shared.Database.Entities;
using PlanningPokerApi.Src.Shared.Business;
using PlanningPokerApi.Src.UseCases.V1.Cards.Create;

namespace PlanningPokerApi.Src.Shared.Injects
{
  public class CardsCreateInject
  {
    public void Invoke(IServiceCollection services)
    {
      services.AddScoped<IRepository<CardEntity>, CardRepository>();
      services.AddScoped<IBusiness<CardsCreateRequestDto, CardsCreateResponseDto>, CardsCreateBO>();
    }
  }
}