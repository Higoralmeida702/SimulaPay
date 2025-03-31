using System;
using System.ComponentModel.DataAnnotations;
using SimulaPay.Domain.Enum;
using SimulaPay.Domain.Validations;

namespace SimulaPay.Domain.Models
{
    public class CarteiraEntity
    {
        [Key]
        public int Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string CPFCNPJ { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public decimal SaldoDeConta { get; private set; }
        public TipoUsuario TipoUsuario { get; set; }


        public void CreditarSaldo(decimal valor)
        {
            SaldoDeConta += valor;
        }

        public void DebitarSaldo(decimal valor)
        {
            SaldoDeConta -= valor;
        }

        public CarteiraEntity(string nomeCompleto, string cPFCNPJ, string email, string senha, TipoUsuario tipoUsuario, decimal saldoDeConta = 0)
        {
            Validate(nomeCompleto, cPFCNPJ, email, senha, tipoUsuario, saldoDeConta);
        }

        public void Validate(string nomeCompleto, string cPFCNPJ, string email, string senha, TipoUsuario tipoUsuario, decimal saldoDeConta)
        {
            NomeCompleto = nomeCompleto;
            CPFCNPJ = cPFCNPJ;
            Email = email;
            Senha = senha;
            SaldoDeConta = saldoDeConta;
            TipoUsuario = tipoUsuario;
        }

        public void Update(string nomeCompleto, string cPFCNPJ, string email, string senha, TipoUsuario tipoUsuario, decimal saldoDeConta)
        {
            Validate(nomeCompleto, cPFCNPJ, email, senha, tipoUsuario, saldoDeConta);
        }
    }
}
