using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SimulaPay.Domain.Enum;
using SimulaPay.Domain.Validations;

namespace SimulaPay.Domain.Model
{
    public class CarteiraEntity
    {
        public int Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string CPFCNPJ { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public decimal SaldoDeConta { get; private set; }
        public TipoUsuario TipoUsuario { get; set; }

        public CarteiraEntity(string nomeCompleto, string cPFCNPJ, string email, string senha, TipoUsuario tipoUsuario, decimal saldoDeConta = 0)
        {
            Validate(nomeCompleto, cPFCNPJ, email, senha, saldoDeConta, tipoUsuario);
        }

        public void Validate(string nomeCompleto, string cPFCNPJ, string email, string senha, decimal saldoDeConta, TipoUsuario tipoUsuario)
        {
            NomeCompleto = nomeCompleto;
            CPFCNPJ = cPFCNPJ;
            Email = email;
            Senha = senha;
            SaldoDeConta = saldoDeConta;
            TipoUsuario = tipoUsuario;
        }

        public void Update(string nomeCompleto, string cPFCNPJ, string email, string senha, decimal saldoDeConta, TipoUsuario tipoUsuario)
        {
            Validate(nomeCompleto, cPFCNPJ, email, senha, saldoDeConta, tipoUsuario);
        }

        public void DebitarSaldo(decimal valor)
        {
            SaldoDeConta -= valor;
        }

        public void CreditarSaldo(decimal valor)
        {
            SaldoDeConta += valor;
        }
    }
}