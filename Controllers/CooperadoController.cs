using System.Collections.Generic;
using System.Threading.Tasks;
using CooperativaAPI.Models.Entities;
using CooperativaAPI.Models.DTOs;
using CooperativaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CooperativaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CooperadosController : ControllerBase
    {
        private readonly ICooperadoService _service;

        public CooperadosController(ICooperadoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Cooperado>> CreateCooperado(
            [FromBody] CreateCooperadoDto dto
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cooperado = await _service.CreateAsync(
                    dto.Nome,
                    dto.ContaCorrente,
                    dto.CooperativaId
                );

                return CreatedAtAction(nameof(GetById), new { id = cooperado.Id }, cooperado);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Erro ao criar cooperado: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cooperado>> GetById(int id)
        {
            var cooperado = await _service.GetByIdAsync(id);

            if (cooperado == null)
            {
                return NotFound();
            }

            return cooperado;
        }

        [HttpGet("por-conta/{contaCorrente}")]
        public async Task<ActionResult<IEnumerable<Cooperado>>> GetByContaCorrente(
            string contaCorrente
        )
        {
            return Ok(await _service.GetByContaCorrenteAsync(contaCorrente));
        }

        [HttpGet("por-nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Cooperado>>> GetByNome(string nome)
        {
            return Ok(await _service.GetByNomeAsync(nome));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cooperado>>> GetAll()
        {
            var cooperados = await _service.GetAllAsync();
            return Ok(cooperados);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCooperado(int id, [FromBody] UpdateCooperadoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cooperado = await _service.GetByIdAsync(id);
            if (cooperado == null)
            {
                return NotFound();
            }

            cooperado.Nome = dto.Nome;
            cooperado.ContaCorrente = dto.ContaCorrente;
            cooperado.CooperativaId = dto.CooperativaId;
            cooperado.Ativo = dto.Ativo;

            try
            {
                await _service.UpdateAsync(cooperado);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar cooperado: {ex.Message}");
            }
        }
    }
}
