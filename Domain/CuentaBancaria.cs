using static Dsw2025Ej8.Domain.Exceptiones;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    
    public string Numero { get; protected set; }
    public decimal Saldo { get; protected set; }

    public Estado Estado { get; protected set; }
    public decimal TasaDeInteres { get; protected init; }
    public decimal LimiteDeDescubierto { get; protected init;  }
    public decimal Comision { get; protected init; }
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

    protected void VerificarCuentaActiva()
    {
        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActiva(Estado.ToString());
        }
    }
    public abstract void Depositar(decimal monto);
    
    public abstract void Retirar(decimal monto);
    
}
