using System.Threading.Tasks;

namespace PlanningPokerApi.Src.Shared.Business
{
  public interface IBusiness<I, O>
  {
    Task<O> Execute(I dto);
  }
}