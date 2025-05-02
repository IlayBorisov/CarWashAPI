namespace DataAccess.Repositories.User;

public interface IUserRepository
{
    Task CreateUserAsync(Model.User user, CancellationToken cancellationToken = default);
    Task<Model.User?> GetByUserIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateUserAsync(Model.User user, CancellationToken cancellationToken = default);
    Task<Model.User?> GetUserByEmailAsync(string email);
    Task DeleteUserAsync(Model.User user, CancellationToken cancellationToken = default);
}