using ITDude.API.Enums;
using ITDude.API.Interfaces;
using ITDude.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITDude.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitController : ControllerBase
    {
        private readonly IHabitService _habitService;
        public HabitController(IHabitService habitService)
        {
            this._habitService = habitService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var habits = await this._habitService.GetAll();
            if (habits!=null)
                return Ok(habits);
            return NotFound();
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var habit = await this._habitService.GetById(id);
            if (habit != null)
                return Ok(habit);
            return NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Habit habit)
        {
            var result = await this._habitService.Create(habit);
            if (result == nameof(Constants.Passed))
                return Ok(result);
            return NotFound();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Habit habit, int id)
        {
            var result = await this._habitService.Update(habit,id);
            if (result == nameof(Constants.Passed))
                return Ok(result);
            return NotFound();
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await this._habitService.Delete(id);
            if (result == nameof(Constants.Passed))
                return Ok(result);
            return NotFound();
        }
    }
}
