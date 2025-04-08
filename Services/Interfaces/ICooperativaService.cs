using CooperativaAPI.Models.Entities;

namespace CooperativaAPI.Services.Interfaces
{
    public interface ICooperativaService
    {
        Task<Cooperativa> GetByIdAsync(int id);
        Task<IEnumerable<Cooperativa>> GetAllAsync();
        Task<Cooperativa> CreateAsync(Cooperativa cooperativa);
        Task UpdateAsync(Cooperativa cooperativa);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}