namespace CooperativaAPI.Models.Entities
{
    public class Cooperado
    {
        public int Id { get; set; }
        public string ContaCorrente { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        
        // Relacionamento
        public int CooperativaId { get; set; }
        public Cooperativa Cooperativa { get; set; }
        
        public ICollection<ContatoFavorito> ContatosFavoritos { get; set; }
    }
}