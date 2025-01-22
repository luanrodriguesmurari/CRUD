using CRUD.Interfaces;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemService _service;

        public TaskItemController(ITaskItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var taskItem = await _service.GetById(id);
            if (taskItem == null)
                return NotFound();

            return Ok(taskItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskItemDto taskItemDto)
        {
            if (taskItemDto == null)
                return BadRequest("TaskItem cannot be null.");

            await _service.Create(taskItemDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskItem updatedTaskItem)
        {
            if (updatedTaskItem == null)
                return BadRequest("Updated TaskItem cannot be null.");

            await _service.Update(id, updatedTaskItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.Delete(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
