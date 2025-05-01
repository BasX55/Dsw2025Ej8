using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new CuentaCorriente("20",40);
            Console.WriteLine($"la comision es {a?.Comision}");
        }
    }
}
