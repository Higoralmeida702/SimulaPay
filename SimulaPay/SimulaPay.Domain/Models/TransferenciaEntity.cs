using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulaPay.Domain.Models
{
    public class TransferenciaEntity
    {
        [Key]
        public Guid TransferenciaId { get; set; }

        [ForeignKey("Receptor")]
        public int ReceptorId { get; set; }
        public CarteiraEntity Receptor { get; set; }

        [ForeignKey("Remetente")]
        public int RemetenteId { get; set; }
        public CarteiraEntity Remetente { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        public TransferenciaEntity(int receptorId, int remetenteId, decimal valor)
        {
            TransferenciaId = Guid.NewGuid();
            ReceptorId = receptorId;
            RemetenteId = remetenteId;
            Valor = valor;
        }
    }
}
