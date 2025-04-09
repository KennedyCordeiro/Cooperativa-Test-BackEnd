using System.ComponentModel.DataAnnotations;

namespace CooperativaAPI.Models.DTOs
{
    public class UpdateCooperadoDto
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(20)]
        public string ContaCorrente { get; set; }

        [Required]
        public int CooperativaId { get; set; }

        public bool Ativo { get; set; }
    }
}