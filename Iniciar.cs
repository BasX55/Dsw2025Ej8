using Dsw2025Ej8.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Exceptiones;

namespace Dsw2025Ej8
{
    internal class Iniciar
    {
        public static void Prueba() {
            CajaDeAhorro cajaDeAhorro1 = new CajaDeAhorro("10", 500, new[] { "Pablo Perez", "Maria Gerez" })
            {
                TasaDeInteres = 8m
            };
            CajaDeAhorro cajaDeAhorro2 = new CajaDeAhorro("200", 10000)
            {
                TasaDeInteres = 50m
            };
            CuentaCorriente cuentaCor1 = new CuentaCorriente("59", 2000) 
            {
                LimiteDeDescubierto = 5000,
                Comision = 0.05m
            };

            try
            {
                Console.WriteLine($"{cajaDeAhorro1.Titulares[0]} y {cajaDeAhorro1.Titulares[1]} tienen ${cajaDeAhorro1.Saldo} en la cuenta con número {cajaDeAhorro1.Numero}. Estado de la cuenta: {cajaDeAhorro1.Estado}");
                Console.WriteLine("\nQuiere ingresar $400 a la cuenta");
                cajaDeAhorro1.Depositar(400);
                cajaDeAhorro1.AplicarInteres();
                Console.WriteLine($"\nSe aplican intereses a la cuenta del {cajaDeAhorro1.TasaDeInteres}%, quedando de esta manera: ${cajaDeAhorro1.Saldo}");
                Console.WriteLine("\nQuiere retirar $2100 en la cuenta");
                cajaDeAhorro1.Retirar(2100);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine($"\nEn la cuenta de numero: {cajaDeAhorro2.Numero}, tiene de saldo: ${cajaDeAhorro2.Saldo}. Estado de la cuenta: {cajaDeAhorro2.Estado}");
                Console.WriteLine("\nQuiere depositar $10000 a la cuenta"); 
                cajaDeAhorro2.Depositar(cajaDeAhorro2.Saldo);
                cajaDeAhorro2.AplicarInteres();
                Console.WriteLine($"\nSe aplican intereses a la cuenta del {cajaDeAhorro2.TasaDeInteres}%, quedando de esta manera: ${cajaDeAhorro2.Saldo}");
                Console.WriteLine("\nQuiere retirar $2100 en la cuenta");
                cajaDeAhorro2.Retirar(2100);
                Console.WriteLine("\nQuiere depositar -$500 en la cuenta");
                cajaDeAhorro2.Depositar(-500);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine($"\nEn la cuenta de numero: {cuentaCor1.Numero}, tiene de saldo: ${cuentaCor1.Saldo}. Estado de la cuenta: {cuentaCor1.Estado}. Limite de descubierto: -${cuentaCor1.LimiteDeDescubierto}");
                Console.WriteLine("\nQuiere depositar $5000 a la cuenta");
                cuentaCor1.Depositar(5000);
                Console.WriteLine("\nQuiere retirar $8000 en la cuenta");
                cuentaCor1.Retirar(8000);
                Console.WriteLine("\nQuiere retirar $8000 en la cuenta");
                cuentaCor1.Retirar(8000);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
