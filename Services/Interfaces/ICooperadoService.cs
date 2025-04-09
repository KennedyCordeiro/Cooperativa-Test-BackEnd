using System.Collections.Generic;
using System.Threading.Tasks;
using CooperativaAPI.Models.Entities;

namespace CooperativaAPI.Services.Interfaces
{
    public interface ICooperadoService
    {
        Task<IEnumerable<Cooperado>> GetAllAsync();
        Task<Cooperado> GetByIdAsync(int id);
        Task<Cooperado> CreateAsync(string nome, string contaCorrente, int cooperativaId);
        Task UpdateAsync(Cooperado cooperado);
        Task DeleteAsync(int id);
        Task<IEnumerable<Cooperado>> GetByContaCorrenteAsync(string contaCorrente);
        Task<IEnumerable<Cooperado>> GetByNomeAsync(string nome);
    }
}
