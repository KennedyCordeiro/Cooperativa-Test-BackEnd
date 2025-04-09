using System.ComponentModel.DataAnnotations;

namespace CooperativaAPI.Models.DTOs
{
    public class CreateCooperativaDto
    {
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public bool Ativo { get; set; } = true;
    }
}