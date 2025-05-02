using BusinessLogic.DTO.User;
using DataAccess.Repositories.User;

namespace BusinessLogic.Services.User;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var user = new DataAccess.Model.User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Patronymic = request.Patronymic,
            Email = request.Email,
            IsSendNotify = request.IsSendNotify
        };
        await userRepository.CreateUserAsync(user, cancellationToken);
    }

    public async Task<UserResponse> GetByUserIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByUserIdAsync(id, cancellationToken);
        if (user is null)
            throw new Exception("User not found");

        return new UserResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Patronymic = user.Patronymic,
            Email = user.Email,
            IsSendNotify = user.IsSendNotify,
            CreatedAt = user.CreatedAt.ToString("dd.MM.yyyy HH:mm"),
        };
    }

    public async Task UpdateUserAsync(int id, CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByUserIdAsync(id, cancellationToken);
        if (user is null)
            throw new Exception("User not found");

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Patronymic = request.Patronymic;
        user.Email = request.Email;
        user.IsSendNotify = request.IsSendNotify;

        await userRepository.UpdateUserAsync(user, cancellationToken);
    }

    public async Task DeleteUserAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByUserIdAsync(id, cancellationToken);
        if (user is null)
            throw new Exception("User not found");

        await userRepository.DeleteUserAsync(user, cancellationToken);
    }
}