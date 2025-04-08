namespace CooperativaAPI.Models.Entities
{
    public class ContatoFavorito
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoChavePix TipoChavePix { get; set; }
        public string ChavePix { get; set; }
        
        public int CooperadoId { get; set; }
        public Cooperado Cooperado { get; set; }
    }

    public enum TipoChavePix
    {
        CPF,
        CNPJ,
        Email,
        Telefone,
        Aleatoria
    }
}