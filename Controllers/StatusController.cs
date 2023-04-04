using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Entities;
using TaskManager.Repositories.StatusRepository.Interface;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(EntityStatus entityStatus)
        {
            if (entityStatus == null)
            {
                return BadRequest($"{entityStatus} não pode ser nulo");
            }

            await this.statusRepository.Insert(entityStatus);
            return Ok("Usuário inserido com sucesso!");
        }

        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            var status = await this.statusRepository.GetAll();
            return Ok(status.ToList());
        }

        [HttpGet("GetStatusById/{Id}")]
        public async Task<IActionResult> GetStatusById(int Id)
        {
            var result = await this.statusRepository.GetById(Id);

            if (result == null)
            {
                return NotFound($"O registro {Id}, não foi encontrado!");
            }

            return Ok(result);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await this.statusRepository.GetById(Id);

            if (result == null)
            {
                return NotFound($"O registro {Id}, não foi encontrado!");
            }
            await this.statusRepository.Delete(Id);

            return Ok($"O registro {Id}, foi excluído com sucesso!");
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(int Id, EntityStatus entityStatus)
        {
            if (Id != entityStatus.Id)
            {
                return BadRequest($"O registro {Id}, não foi encontrado!");
            }

            try
            {
                await this.statusRepository.Update(Id, entityStatus);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }

            return Ok("Dados atualizados com sucesso!");
        }
    }
}
