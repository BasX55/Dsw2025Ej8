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
            if(monto <=0)
            {
                throw new MontoNoValido();
            }
            else if (Estado != Estado.Activa)
            {
                throw new CuentaNoActiva(Estado.ToString());
            }
            else
            {
                monto -= monto * Comision;
                Console.WriteLine($"Se le resta por comision del {(double)Comision * 100}% quedando asi ${monto} para depositar");
                Saldo += monto;
                Console.WriteLine($"Numero de cuenta: {Numero}; Tipo de cuenta: Caja Corriente; Saldo actual: ${Saldo}");
            }
                
            

        }

        public override void Retirar(decimal monto)
        {
            if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            else if (Estado != Estado.Activa)
            {
                throw new CuentaNoActiva(Estado.ToString());
            }
            if (Saldo - monto >= -LimiteDeDescubierto)
            {
                Saldo -= monto;
                Console.WriteLine($"Numero de cuenta: {Numero}; Tipo de cuenta: Caja Corriente; Saldo actual: ${Saldo}");
                return;
            }
            if (Saldo < 0)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }
        }
    }
}
