using System.Threading.Tasks;
using System.Collections.Generic;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.Shared.Database.Entities;
using PlanningPokerApi.Src.Shared.Business;
using PlanningPokerApi.Src.Shared.Helpers.Cryptography;

namespace PlanningPokerApi.Src.UseCases.V1.Users.Create
{
  public class UsersCreateBO : IBusiness<UsersCreateRequestDto, UsersCreateResponseDto>
  {

    private readonly IRepository<UserEntity> _repository;

    public UsersCreateBO(IRepository<UserEntity> repository)
    {
      _repository = repository;
    }

    public async Task<UsersCreateResponseDto> Execute(UsersCreateRequestDto dto)
    {
      var parameters = new Dictionary<string, object>()
      {
        { "Email", dto.Email }
      };
      var users = await _repository.ByParams(parameters);

      if (users.Count > 0)
      {
        throw new System.Exception("This email already use");
      }

      var entity = CreateEntityWith(dto);

      var result = await _repository.Create(entity);

      return CreateResponseWith(result);
    }

    private UserEntity CreateEntityWith(UsersCreateRequestDto dto)
    {
      var entity = new UserEntity();
      entity.Name = dto.Name;
      entity.Email = dto.Email;
      entity.Password = new HashHelper().GetCypher(dto.Password);
      return entity;
    }

    private UsersCreateResponseDto CreateResponseWith(UserEntity entity)
    {
      var dto = new UsersCreateResponseDto();
      dto.Id = entity.Id;
      dto.Name = entity.Name;
      dto.Email = entity.Email;
      return dto;
    }
  }
}