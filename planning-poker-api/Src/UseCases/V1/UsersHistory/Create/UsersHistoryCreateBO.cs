using System.Threading.Tasks;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.Shared.Database.Entities;
using PlanningPokerApi.Src.Shared.Business;

namespace PlanningPokerApi.Src.UseCases.V1.UsersHistory.Create
{
  public class UsersHistoryCreateBO : IBusiness<UsersHistoryCreateRequestDto, UsersHistoryCreateResponseDto>
  {

    private IRepository<UsersHistoryEntity> _repository;

    public UsersHistoryCreateBO(IRepository<UsersHistoryEntity> repository)
    {
      _repository = repository;
    }

    public async Task<UsersHistoryCreateResponseDto> Execute(UsersHistoryCreateRequestDto requestDto)
    {
      var entity = CreateEntityWith(requestDto);
      var result = await _repository.Create(entity);
      return CreateResponseWith(result);
    }

    private UsersHistoryEntity CreateEntityWith(UsersHistoryCreateRequestDto dto)
    {
      var entity = new UsersHistoryEntity();
      entity.Description = dto.Description;
      return entity;
    }

    private UsersHistoryCreateResponseDto CreateResponseWith(UsersHistoryEntity entity)
    {
      var dto = new UsersHistoryCreateResponseDto();
      dto.Id = entity.Id;
      dto.Description = entity.Description;
      return dto;
    }
  }
}