using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CooperativaAPI.Models.Entities
{
    public class Cooperado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(20)]
        public string ContaCorrente { get; set; }

        [Required]
        public int CooperativaId { get; set; }

        public bool Ativo { get; set; } = true;

        [ForeignKey("CooperativaId")]
        public virtual Cooperativa Cooperativa { get; set; }
    }
}
