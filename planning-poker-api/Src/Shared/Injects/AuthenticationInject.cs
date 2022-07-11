using Microsoft.Extensions.DependencyInjection;
using PlanningPokerApi.Src.Shared.Business;
using PlanningPokerApi.Src.UseCases.V1.Authentication.Login;

namespace PlanningPokerApi.Src.Shared.Injects
{
  public class AuthenticationInject
  {
    public void Invoke(IServiceCollection services)
    {
      services.AddScoped<IBusiness<AuthenticationLoginRequestDto, AuthenticationLoginResponseDto>, AuthenticationLoginBusiness>();
    }
  }
}