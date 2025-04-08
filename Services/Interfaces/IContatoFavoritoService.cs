using CooperativaAPI.Models.Entities;

namespace CooperativaAPI.Services.Interfaces
{
    public interface IContatoFavoritoService
    {
        Task<ContatoFavorito> GetByIdAsync(int id);
        Task<IEnumerable<ContatoFavorito>> GetAllAsync();
        Task<IEnumerable<ContatoFavorito>> GetByCooperadoIdAsync(int cooperadoId);
        Task<ContatoFavorito> CreateAsync(ContatoFavorito contato);
        Task UpdateAsync(ContatoFavorito contato);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}