using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Exceptiones;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria 
    {
        public CuentaCorriente(string numero, decimal saldo, string[]? titulares = null) : base(numero, saldo, titulares) { }
        public override void Depositar(decimal monto)
        {
            guardardecimal(ref monto);
            monto -= monto * Comision;
            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            VerificarCuentaActiva();

            guardardecimal(ref monto);
            if (Saldo - monto >= -LimiteDeDescubierto)
            {
                Saldo -= monto;
            }
            if (Saldo < 0)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }
        }
    }
}
