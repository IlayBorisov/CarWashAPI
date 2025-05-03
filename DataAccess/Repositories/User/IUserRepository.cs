namespace DataAccess.Repositories.User;

public interface IUserRepository
{
    Task CreateUserAsync(Model.User user, CancellationToken cancellationToken = default);
    Task<Model.User?> GetByUserIdAsync(int id, CancellationToken cancellationToken = default);
    IQueryable<Model.User> GetAllUserAsync();
    Task<Model.User?> GetUserByEmailAsync(string email);
    Task UpdateUserAsync(Model.User user, CancellationToken cancellationToken = default);
    Task DeleteUserAsync(Model.User user, CancellationToken cancellationToken = default);
}