using BootCampProject.Entities;
using BootCampProject.Repositories.Interfaces;
using BootCampProject.Entities;
using Microsoft.AspNetCore.Mvc;
using BootCampProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            return instructor != null ? Ok(instructor) : NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var instructors = await _instructorRepository.GetAllAsync();
            return Ok(instructors);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Instructor instructor)
        {
            if (instructor == null)
                return BadRequest();
            await _instructorRepository.AddAsync(instructor);
            return CreatedAtAction(nameof(Get), new { id = instructor.Id }, instructor);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Instructor instructor)
        {
            if (id != instructor.Id)
                return BadRequest();
            await _instructorRepository.UpdateAsync(instructor);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            if (instructor == null)
                return NotFound();
            await _instructorRepository.DeleteAsync(instructor);
            return NoContent();
        }
    }
}