using Dsw2025Ej8.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8
{
    internal class Iniciar
    {
        public static void Prueba() {
            
            CajaDeAhorro cajaDeAhorro1 = new CajaDeAhorro("10",500,new[] { "Pablo Perez", "Maria Gerez" });
            Console.WriteLine($"{cajaDeAhorro1.Titulares[0]} y {cajaDeAhorro1.Titulares[1]} tienen ${cajaDeAhorro1.Saldo}");
            cajaDeAhorro1.Depositar(400);
            Console.WriteLine($"Se deposito {cajaDeAhorro1.Saldo}");
            cajaDeAhorro1.Retirar(2100);
            Console.WriteLine($"{cajaDeAhorro1.Titulares[0]} tiene ${cajaDeAhorro1.Saldo}");
            Console.WriteLine($"La taza de interes es: {cajaDeAhorro1.TasaDeInteres}. \nEstado de la cuenta: {cajaDeAhorro1.Estado}");
            Console.WriteLine($"La comision es: {cajaDeAhorro1.Comision}");
            Console.WriteLine($"La limite de descubierto es: {cajaDeAhorro1.LimiteDeDescubierto}");


            CajaDeAhorro cajaDeAhorro2 = new CajaDeAhorro("200", 10000);
            cajaDeAhorro2.Depositar(cajaDeAhorro1.Saldo);

            Console.WriteLine($"Saldo de caja2 es: {cajaDeAhorro2.Saldo}");


        }
    }
}
