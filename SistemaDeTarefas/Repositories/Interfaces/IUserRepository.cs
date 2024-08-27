using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user, int id);
        Task<bool> DeleteUser(int id);
    }
}
