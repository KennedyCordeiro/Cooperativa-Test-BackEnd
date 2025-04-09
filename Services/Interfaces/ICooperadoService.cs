using System.Collections.Generic;
using System.Threading.Tasks;
using CooperativaAPI.Models.Entities;

namespace CooperativaAPI.Services.Interfaces
{
    public interface ICooperadoService
    {
        Task<IEnumerable<Cooperado>> GetAllAsync();
        Task<Cooperado> GetByIdAsync(int id);
        Task<Cooperado> CreateAsync(Cooperado cooperado);
        Task UpdateAsync(Cooperado cooperado);
        Task DeleteAsync(int id);
        Task<IEnumerable<Cooperado>> GetByContaCorrenteAsync(string conta);
        Task<IEnumerable<Cooperado>> GetByNomeAsync(string nome);
    }
}
