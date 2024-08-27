using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) { 
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers(){
            List<User> users = await _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsersById(int id)
        {
            User user = await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
           User newUser =  await _userRepository.AddUser(user);

            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user, int id)
        {
            user.Id = id;
            User updtUser = await _userRepository.UpdateUser(user, id);

            return Ok(updtUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            bool deleted = await _userRepository.DeleteUser(id);

            return Ok(deleted);
        }

    }
}
