using CooperativaAPI.Models.Entities;

public interface ICooperadoService
{
    Task<Cooperado> GetByIdAsync(int id);
    Task<IEnumerable<Cooperado>> GetAllAsync();
    Task<IEnumerable<Cooperado>> GetByContaCorrenteAsync(string contaCorrente);
    Task<IEnumerable<Cooperado>> GetByNomeAsync(string nome);
    Task<Cooperado> CreateAsync(Cooperado cooperado);
    Task UpdateAsync(Cooperado cooperado);
    Task DeleteAsync(int id);
}