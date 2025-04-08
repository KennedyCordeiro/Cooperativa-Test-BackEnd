// Controllers/ContatosFavoritosController.cs
using CooperativaAPI.Models.Entities;
using CooperativaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CooperativaAPI.Controllers
{
    [ApiController]
    [Route("api/cooperados/{cooperadoId}/[controller]")]
    public class ContatosFavoritosController : ControllerBase
    {
        private readonly IContatoFavoritoService _contatoService;
        private readonly ICooperadoService _cooperadoService;

        public ContatosFavoritosController(
            IContatoFavoritoService contatoService,
            ICooperadoService cooperadoService)
        {
            _contatoService = contatoService;
            _cooperadoService = cooperadoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int cooperadoId)
        {
            if (await _cooperadoService.GetByIdAsync(cooperadoId) == null)
                return NotFound("Cooperado não encontrado");

            var contatos = await _contatoService.GetByCooperadoIdAsync(cooperadoId);
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int cooperadoId, int id)
        {
            var contato = await _contatoService.GetByIdAsync(id);
            
            if (contato == null || contato.CooperadoId != cooperadoId)
                return NotFound();
                
            return Ok(contato);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int cooperadoId, [FromBody] ContatoFavorito contato)
        {
            if (await _cooperadoService.GetByIdAsync(cooperadoId) == null)
                return NotFound("Cooperado não encontrado");

            contato.CooperadoId = cooperadoId;
            
            try
            {
                var created = await _contatoService.CreateAsync(contato);
                return CreatedAtAction(
                    nameof(GetById), 
                    new { cooperadoId, id = created.Id }, 
                    created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int cooperadoId, int id, [FromBody] ContatoFavorito contato)
        {
            if (id != contato.Id || cooperadoId != contato.CooperadoId)
                return BadRequest();
                
            if (!await _contatoService.ExistsAsync(id))
                return NotFound();

            try
            {
                await _contatoService.UpdateAsync(contato);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int cooperadoId, int id)
        {
            var contato = await _contatoService.GetByIdAsync(id);
            if (contato == null || contato.CooperadoId != cooperadoId)
                return NotFound();

            await _contatoService.DeleteAsync(id);
            return NoContent();
        }
    }
}