using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Exceptiones;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public CajaDeAhorro(string numero, decimal saldo, string[]? titulares = null) : base(numero, saldo, titulares) { }
        
        public override void Depositar(decimal monto)
        {
            if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            else if(Estado != Estado.Activa){
                throw new CuentaNoActiva(Estado.ToString());
            }
            else
            {
                Saldo += monto;
                Console.WriteLine($"Numero de cuenta: {Numero}; Tipo de cuenta: Caja de Ahorro; Saldo actual: ${Saldo}");
            }
                
            

        }

        public override void Retirar(decimal monto)
        {
            if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            else if (monto > Saldo)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }
            else if (Estado != Estado.Activa)
            {
                throw new CuentaNoActiva(Estado.ToString());
            }
            else
            {
                Saldo -= monto;
                Console.WriteLine($"Numero de cuenta: {Numero}; Tipo de cuenta: Caja de Ahorro; Saldo actual: ${Saldo}");
            }
        }

        public void AplicarInteres() 
        {
            Saldo += Saldo * TasaDeInteres / 100;
        }
    }
}
