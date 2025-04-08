using CooperativaAPI.Models.Entities;
using CooperativaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace CooperativaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class CooperativasController : ControllerBase
    {
        private readonly ICooperativaService _service;

        public CooperativasController(ICooperativaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cooperativas = await _service.GetAllAsync();
            return Ok(cooperativas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cooperativa = await _service.GetByIdAsync(id);
            if (cooperativa == null) return NotFound();
            return Ok(cooperativa);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cooperativa cooperativa)
        {
            var created = await _service.CreateAsync(cooperativa);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cooperativa cooperativa)
        {
            if (id != cooperativa.Id) return BadRequest();

            try
            {
                await _service.UpdateAsync(cooperativa);
                return NoContent();
            }
            catch (Exception)
            {
                if (!await _service.ExistsAsync(id))
                    return NotFound();
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}