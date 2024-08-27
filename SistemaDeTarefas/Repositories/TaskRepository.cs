using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksSystemDbContext _dbContext;
        public TaskRepository(TasksSystemDbContext tasksSystemDbContext) { 
            _dbContext = tasksSystemDbContext;
        }
        public async Task<Models.Task> AddTask(Models.Task task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
           
            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            Models.Task actTask = await GetTaskById(id);

            if (actTask == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrada!");
            }

            _dbContext.Remove(actTask);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Models.Task> GetTaskById(int id)
        {
            return await _dbContext.Tasks.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Models.Task>> GetTasks()
        {
            return await _dbContext.Tasks.Include(x => x.User).ToListAsync();
        }

        public async Task<Models.Task> UpdateTask(Models.Task task, int id)
        {
            Models.Task actTask = await GetTaskById(id);

            if (actTask == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrada!");
            }

            actTask.Name = task.Name;
            actTask.Description = task.Description;
            actTask.Status = task.Status;
            actTask.UserId = task.UserId;
            

            _dbContext.Tasks.Update(actTask);
            await _dbContext.SaveChangesAsync();

            return actTask;

        }
    }
}
