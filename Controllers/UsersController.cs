using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using TaskManager.Entities;
using TaskManager.Repositories.UsersRepository.Interface;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(EntityUsers entityUsers)
        {
            if (entityUsers == null)
            {
                return BadRequest($"{entityUsers} não pode ser nulo");
            }

            await this.usersRepository.Insert(entityUsers);
            return Ok("Usuário inserido com sucesso!");
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await this.usersRepository.GetAll();
            return Ok(users.ToList());
        }

        [HttpGet("GetUserById/{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var result = await this.usersRepository.GetById(Id);

            if (result == null)
            {
                return NotFound($"O registro {Id}, não foi encontrado!");
            }

            return Ok(result);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await this.usersRepository.GetById(Id);

            if (result == null)
            {
                return NotFound($"O registro {Id}, não foi encontrado!");
            }
            await this.usersRepository.Delete(Id);

            return Ok($"O registro {Id}, foi excluído com sucesso!");
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(int Id, EntityUsers entityUsers)
        {
            if(Id != entityUsers.Id)
            {
                return BadRequest($"O registro { Id}, não foi encontrado!");
            }

            try
            {
                await this.usersRepository.Update(Id, entityUsers);
            } catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }

            return Ok("Dados atualizados com sucesso!");
        }
    }
}
