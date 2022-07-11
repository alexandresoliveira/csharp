using System.Threading.Tasks;
using System.Collections.Generic;
using PlanningPokerApi.Src.Shared.Business;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.Shared.Database.Entities;
using PlanningPokerApi.Src.Shared.Helpers.Jwt;
using PlanningPokerApi.Src.Shared.Helpers.Cryptography;

namespace PlanningPokerApi.Src.UseCases.V1.Authentication.Login
{
  public class AuthenticationLoginBusiness : IBusiness<AuthenticationLoginRequestDto, AuthenticationLoginResponseDto>
  {

    private readonly IRepository<UserEntity> _repository;
    private readonly JwtHelper _jwtHelper;

    public AuthenticationLoginBusiness(IRepository<UserEntity> repository, JwtHelper jwtHelper)
    {
      _repository = repository;
      _jwtHelper = jwtHelper;
    }

    public async Task<AuthenticationLoginResponseDto> Execute(AuthenticationLoginRequestDto dto)
    {
      var parameters = new Dictionary<string, object>()
      {
          { "Email", dto.Email },
          { "Password", new HashHelper().GetCypher(dto.Password) }
      };

      var users = await _repository.ByParams(parameters);

      if (users.Count == 0)
      {
        throw new System.Exception("Invalid credentials!");
      }

      return CreateDtoWith(users[0]);
    }

    private AuthenticationLoginResponseDto CreateDtoWith(UserEntity userEntity)
    {
      var response = new AuthenticationLoginResponseDto();
      response.Name = userEntity.Name;
      response.Token = _jwtHelper.GenerateToken(userEntity);
      return response;
    }

  }
}
