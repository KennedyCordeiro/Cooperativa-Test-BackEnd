using CooperativaAPI.Data;
using CooperativaAPI.Models.Entities;
using CooperativaAPI.Services.Interfaces; // Adicione esta linha
using Microsoft.EntityFrameworkCore;

namespace CooperativaAPI.Services.Implementations

{
    public class CooperativaService : ICooperativaService
    {
        private readonly AppDbContext _context;

        public CooperativaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cooperativa> CreateAsync(Cooperativa cooperativa)
        {
            if (string.IsNullOrWhiteSpace(cooperativa.Descricao))
                throw new ArgumentException("Descrição é obrigatória");

            if (await _context.Cooperativas.AnyAsync(c => c.Descricao == cooperativa.Descricao))
                throw new ArgumentException("Já existe uma cooperativa com esta descrição");

            _context.Cooperativas.Add(cooperativa);
            await _context.SaveChangesAsync();
            return cooperativa;
        }

        public async Task DeleteAsync(int id)
        {
            var cooperativa = await _context.Cooperativas.FindAsync(id);
            if (cooperativa != null)
            {
                // Exclusão lógica (alternativa à física)
                cooperativa.Ativo = false;
                _context.Entry(cooperativa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }



        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Cooperativas.AnyAsync(c => c.Id == id && c.Ativo);
        }

        public async Task<IEnumerable<Cooperativa>> GetAllAsync()
        {
            return await _context.Cooperativas.Where(c => c.Ativo).ToListAsync();
        }

        public async Task<Cooperativa> GetByIdAsync(int id)
        {
            return await _context.Cooperativas.FirstOrDefaultAsync(c => c.Id == id && c.Ativo);
        }

        public async Task UpdateAsync(Cooperativa cooperativa)
        {
            _context.Entry(cooperativa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}