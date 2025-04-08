using System.Text.RegularExpressions;
using CooperativaAPI.Data;
using CooperativaAPI.Models.Entities;
using CooperativaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CooperativaAPI.Services.Implementations
{
    public class ContatoFavoritoService : IContatoFavoritoService
    {
        private readonly AppDbContext _context;

        public ContatoFavoritoService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ContatoFavorito> CreateAsync(ContatoFavorito contato)
        {
            if (!Enum.IsDefined(typeof(TipoChavePix), contato.TipoChavePix))
                throw new ArgumentException("Tipo de chave PIX inválido");

            _context.ContatosFavoritos.Add(contato);
            await _context.SaveChangesAsync();
            return contato;
        }

        public async Task DeleteAsync(int id)
        {
            var contato = await _context.ContatosFavoritos.FindAsync(id);
            if (contato != null)
            {
                _context.ContatosFavoritos.Remove(contato);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.ContatosFavoritos.AnyAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<ContatoFavorito>> GetAllAsync()
        {
            return await _context.ContatosFavoritos.ToListAsync();
        }

        public async Task<ContatoFavorito> GetByIdAsync(int id)
        {
            return await _context.ContatosFavoritos.FindAsync(id);
        }

        public async Task<IEnumerable<ContatoFavorito>> GetByCooperadoIdAsync(int cooperadoId)
        {
            return await _context.ContatosFavoritos
                .Where(c => c.CooperadoId == cooperadoId)
                .ToListAsync();
        }

        public async Task UpdateAsync(ContatoFavorito contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

    // Adicione este método no ContatoFavoritoService.cs

}



