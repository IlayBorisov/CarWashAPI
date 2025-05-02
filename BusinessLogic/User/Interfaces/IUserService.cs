using BusinessLogic.User.Dtos;
using BusinessLogic.User.Requests;

namespace BusinessLogic.User.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken = default);
    Task<UserResponse> GetByUserIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateUserAsync(int id, CreateUserRequest request, CancellationToken cancellationToken = default);
    Task DeleteUserAsync(int id, CancellationToken cancellationToken = default);
}