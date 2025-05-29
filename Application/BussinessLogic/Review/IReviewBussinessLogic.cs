using Application.DTO.Review;
using System.Linq.Expressions;

namespace Application.BussinessLogic.Review
{
  public interface IReviewBussinessLogic
  {
    Task<List<ReviewDto>> GetAllAsync(bool trackChanges);
    Task<ReviewDto> GetByIdAsync(Guid id, bool trackChanges);
    Task<Guid> CreateAsync(ReviewCreateWithIdDto dto);
    Task DeleteAsync(Guid reviewId);
    Task UpdateAsync(ReviewDto dto);
    List<ReviewDto> GetByCondition(Expression<Func<Domain.Models.Review, bool>> expression, bool trackChanges);
  }
}
