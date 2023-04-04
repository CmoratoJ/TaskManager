using Microsoft.AspNetCore.Mvc;
using TaskManager.Entities;
using TaskManager.Repositories.TasksRepository.Interface;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepository tasksRepository;

        public TasksController(ITasksRepository tasksRepository)
        {
            this.tasksRepository = tasksRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(EntityTasks entityTasks)
        {
            if (entityTasks == null)
            {
                return BadRequest($"{entityTasks} não pode ser nulo");
            }

            await this.tasksRepository.Insert(entityTasks);
            return Ok("Tarefa registrada com sucesso!");
        }

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await this.tasksRepository.GetAll();
            return Ok(tasks.ToList());
        }

        [HttpGet("GetTaskById/{Id}")]
        public async Task<IActionResult> GetTaskById(int Id)
        {
            var result = await this.tasksRepository.GetById(Id);

            if (result == null)
            {
                return NotFound($"O registro {Id}, não foi encontrado!");
            }

            return Ok(result);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await this.tasksRepository.GetById(Id);

            if (result == null)
            {
                return NotFound($"O registro {Id}, não foi encontrado!");
            }
            await this.tasksRepository.Delete(Id);

            return Ok($"O registro {Id}, foi excluído com sucesso!");
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(int Id, EntityTasks entityTasks)
        {
            var result = await this.tasksRepository.GetById(Id);
            result.StatusId = entityTasks.StatusId;

            if (entityTasks.StatusId == 3 && result.StatusId == 2)
            {
                result.DateScheduleFinal = DateTime.Now;
                TimeSpan date = Convert.ToDateTime(result.DateScheduleFinal) - Convert.ToDateTime(result.DateScheduleInitial);
                var dateStr = Convert.ToString(date);
                dateStr = dateStr.Substring(4, 5);
                result.ServiceTime = dateStr;                
            }

            await this.tasksRepository.Update(Id, result);

            return Ok("Dados atualizados com sucesso!");
        }
    }
}
