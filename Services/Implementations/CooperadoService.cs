using CooperativaAPI.Data;
using CooperativaAPI.Models.Entities;
using CooperativaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CooperativaAPI.Services.Implementations
{
    public class CooperadoService : ICooperadoService
    {
        private readonly AppDbContext _context;

        public CooperadoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cooperado>> GetAllAsync()
        {
            return await _context.Cooperados.ToListAsync();
        }

        public async Task<Cooperado> GetByIdAsync(int id)
        {
            return await _context.Cooperados.FindAsync(id);
        }

        public async Task<Cooperado> CreateAsync(string nome, string contaCorrente, int cooperativaId)
        {
            var cooperado = new Cooperado
            {
                Nome = nome,
                ContaCorrente = contaCorrente,
                CooperativaId = cooperativaId
            };

            _context.Cooperados.Add(cooperado);
            await _context.SaveChangesAsync();
            return cooperado;
        }

        public async Task UpdateAsync(Cooperado cooperado)
        {
            _context.Entry(cooperado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cooperado = await GetByIdAsync(id);
            if (cooperado != null)
            {
                _context.Cooperados.Remove(cooperado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cooperado>> GetByContaCorrenteAsync(string contaCorrente)
        {
            return await _context.Cooperados
                .Where(c => c.ContaCorrente == contaCorrente)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cooperado>> GetByNomeAsync(string nome)
        {
            return await _context.Cooperados
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();
        }
    }
}
