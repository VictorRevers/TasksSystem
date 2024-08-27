using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TasksSystemDbContext _dbContext;
        public UserRepository(TasksSystemDbContext tasksSystemDbContext) { 
            _dbContext = tasksSystemDbContext;
        }
        public async Task<User> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
           
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            User actUser = await GetUserById(id);

            if (actUser == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado!");
            }

            _dbContext.Remove(actUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User user, int id)
        {
            User actUser = await GetUserById(id);

            if (actUser == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado!");
            }

            actUser.Name = user.Name;
            actUser.Email = user.Email;

            _dbContext.Users.Update(actUser);
            await _dbContext.SaveChangesAsync();

            return actUser;

        }
    }
}
