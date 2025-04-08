namespace CooperativaAPI.Models.Entities
{
    public class Cooperativa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; } = true;
        
        public ICollection<Cooperado> Cooperados { get; set; }
    }
}