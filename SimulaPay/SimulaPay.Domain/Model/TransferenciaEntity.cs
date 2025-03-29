using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulaPay.Domain.Model
{
    public class TransferenciaEntity
    {
        public Guid TransferenciaId { get; private set; }

        public int RemetenteId { get; private set; }
        public CarteiraEntity Remetente { get; set; }

        public int ReceptorId { get; private set; }
        public CarteiraEntity Receptor { get; set; }
        public decimal Valor { get; private set; }

        public TransferenciaEntity(int remetenteId, int receptorId, decimal valor = 0)
        {
            TransferenciaId = Guid.NewGuid();
            Validate(receptorId, remetenteId, valor);
        }



        public void Validate(int idRemetente, int receptorId, decimal valor)
        {
            RemetenteId = idRemetente;
            ReceptorId = receptorId;
            Valor = valor;
        }

        public void Update(int remetenteId, int receptorId, decimal valor)
        {
            Validate(receptorId, remetenteId, valor);

        }

    }
}