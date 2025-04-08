using Microsoft.AspNetCore.Mvc;
using CooperativaAPI.Models.Entities;
using CooperativaAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class CooperadosController : ControllerBase
{
    private readonly ICooperadoService _service;

    public CooperadosController(ICooperadoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cooperados = await _service.GetAllAsync();
        return Ok(cooperados);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cooperado = await _service.GetByIdAsync(id);
        if (cooperado == null) return NotFound();
        return Ok(cooperado);
    }

    [HttpGet("por-conta/{contaCorrente}")]
    public async Task<IActionResult> GetByContaCorrente(string contaCorrente)
    {
        var cooperados = await _service.GetByContaCorrenteAsync(contaCorrente);
        return Ok(cooperados);
    }

    [HttpGet("por-nome/{nome}")]
    public async Task<IActionResult> GetByNome(string nome)
    {
        var cooperados = await _service.GetByNomeAsync(nome);
        return Ok(cooperados);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Cooperado cooperado)
    {
        var created = await _service.CreateAsync(cooperado);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Cooperado cooperado)
    {
        if (id != cooperado.Id) return BadRequest();
        await _service.UpdateAsync(cooperado);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}