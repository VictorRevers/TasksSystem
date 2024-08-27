using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository) { 
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Task>>> GetTasks(){
            List<Models.Task> tasks = await _taskRepository.GetTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> GetTasksById(int id)
        {
            Models.Task task = await _taskRepository.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddTask([FromBody] Models.Task task)
        {
            Models.Task newTask =  await _taskRepository.AddTask(task);

            return Ok(newTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Models.Task>> UpdateTask([FromBody] Models.Task task, int id)
        {
            task.Id = id;
            Models.Task updtTask = await _taskRepository.UpdateTask(task, id);

            return Ok(updtTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Task>> DeleteTask(int id)
        {
            bool deleted = await _taskRepository.DeleteTask(id);

            return Ok(deleted);
        }

    }
}
