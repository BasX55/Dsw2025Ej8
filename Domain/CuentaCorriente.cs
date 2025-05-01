using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria 
    {
        public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares) { }
        public override void Depositar(decimal monto)
        {
            guardardecimal(ref monto);
            monto -= monto * _comision;
            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            guardardecimal(ref monto);
            if (Saldo - monto >= -_limiteDeDescubierto)
            {
                Saldo -= monto;
            }
            if (Saldo < 0)
            {
                Estado = Estado.Suspendida;
            }
        }
    }
}
