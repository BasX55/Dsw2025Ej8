using static Dsw2025Ej8.Domain.Exceptiones;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    
    public string Numero { get; protected set; }
    public decimal Saldo { get; protected set; }

    public Estado Estado { get; protected set; }
    public decimal TasaDeInteres { get; init; }
    public decimal LimiteDeDescubierto { get; init;  }
    public decimal Comision { get; init; }
    public string[] Titulares { get; protected set; }



    public void guardardecimal(ref decimal valor)
    {
        if (valor >= 0)
        {
            Saldo = valor;
        }
        else
        {
            throw new MontoNoValido();
        }
    }

    public CuentaBancaria(string numero, decimal saldo, string[]? titulares )
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares ?? [];
    }

    
    public abstract void Depositar(decimal monto);
    
    public abstract void Retirar(decimal monto);
    
}
