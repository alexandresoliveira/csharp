using System;
using System.Threading.Tasks;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.Shared.Database.Entities;
using PlanningPokerApi.Src.Shared.Business;
using PlanningPokerApi.Src.Shared.Hubs;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace PlanningPokerApi.Src.UseCases.V1.Votes.Create
{
  public class VotesCreateBO : IBusiness<VotesCreateRequestDto, VotesCreateResponseDto>
  {

    private IRepository<VoteEntity> _votesRepository;
    private IRepository<UserEntity> _userRepository;
    private IRepository<UsersHistoryEntity> _usersHistoryRepository;
    private IRepository<CardEntity> _cardRepository;
    private IHubContext<VoteHub> _hubContext;

    public VotesCreateBO(
      IRepository<VoteEntity> votesRepository,
      IRepository<UserEntity> userRepository,
      IRepository<UsersHistoryEntity> usersHistoryRepository,
      IRepository<CardEntity> cardRepository,
      IHubContext<VoteHub> hubContext)
    {
      _votesRepository = votesRepository;
      _userRepository = userRepository;
      _usersHistoryRepository = usersHistoryRepository;
      _cardRepository = cardRepository;
      _hubContext = hubContext;
    }

    public async Task<VotesCreateResponseDto> Execute(VotesCreateRequestDto dto)
    {
      var userEntity = await _userRepository.ById(dto.UserId);
      if (userEntity == null) throw new System.Exception("User not found");

      var usersHistoryEntity = await _usersHistoryRepository.ById(dto.UsersHistoryId);
      if (usersHistoryEntity == null) throw new System.Exception("User History not found");

      var cardEntity = await _cardRepository.ById(dto.CardId);
      if (cardEntity == null) throw new System.Exception("Card not found");

      var entity = CreateEntityWith(userEntity, usersHistoryEntity, cardEntity);
      var result = await _votesRepository.Create(entity);

      await _hubContext.Clients.All.SendAsync("Notify", $"Vote registed {DateTime.Now}");

      PublishVote(result);

      return CreateResponseWith(result);
    }

    private void PublishVote(VoteEntity entity)
    {
      var ampqUrl = "amqps://vinhwvmu:TrVbEHtFn1xtNac9K0OA0OFV_EY7nUxK@orangutan.rmq.cloudamqp.com/vinhwvmu";
      var factory = new ConnectionFactory() { Uri = new Uri(ampqUrl) };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        channel.ExchangeDeclare(exchange: "AllVotes", type: "direct", durable: true);
        var message = JsonSerializer.Serialize(entity);
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "AllVotes",
                routingKey: entity.Id.ToString(),
                basicProperties: null,
                body: body);
      }
    }

    private VoteEntity CreateEntityWith(
      UserEntity userEntity,
      UsersHistoryEntity usersHistoryEntity,
      CardEntity cardEntity)
    {
      var entity = new VoteEntity();
      entity.User = userEntity;
      entity.UsersHistory = usersHistoryEntity;
      entity.Card = cardEntity;
      return entity;
    }

    private VotesCreateResponseDto CreateResponseWith(VoteEntity entity)
    {
      var dto = new VotesCreateResponseDto();
      dto.Id = entity.Id;
      dto.UserName = entity.User.Name;
      dto.UsersHistoryDescription = entity.UsersHistory.Description;
      dto.CardValue = entity.Card.Value;
      return dto;
    }

  }
}