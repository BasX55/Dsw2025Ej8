using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public CajaDeAhorro(string numero, decimal saldo, string[]? titulares = null) : base(numero, saldo, titulares) { }
        
        public override void Depositar(decimal monto)
        {
            guardardecimal(ref monto);
            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            guardardecimal(ref monto);
            Saldo -= monto;
        }

        public void AplicarInteres() 
        {
            Saldo += Saldo * TasaDeInteres / 100;
        }
    }
}
