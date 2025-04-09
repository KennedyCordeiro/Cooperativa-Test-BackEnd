using System.ComponentModel.DataAnnotations;

namespace CooperativaAPI.Models.DTOs
{
    public class UpdateCooperativaDto
    {
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}