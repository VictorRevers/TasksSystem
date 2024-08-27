using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Models.Task>> GetTasks();
        Task<Models.Task> GetTaskById(int id);
        Task<Models.Task> AddTask(Models.Task task);
        Task<Models.Task> UpdateTask(Models.Task task, int id);
        Task<bool> DeleteTask(int id);
    }
}
