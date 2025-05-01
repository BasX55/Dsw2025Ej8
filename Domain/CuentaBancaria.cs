namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    
    public string Numero { get; protected set; }
    public decimal Saldo { get; protected set; }

    public Estado Estado { get; protected set; }
    public decimal _tasaDeInteres { get; init; }
    public decimal _limiteDeDescubierto { get { return _limiteDeDescubierto; } protected set { guardardecimal(ref value); } }
    public decimal _comision { get { return _comision; } protected set { guardardecimal(ref value); } }
    public string[] _titulares { get; protected set; }



    public void guardardecimal(ref decimal valor)
    {
        if (valor >= 0)
        {
            Saldo = valor;
        }
        else
        {
            throw new ArgumentException("El valor ingresado no es valido");
        }
    }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        _titulares = titulares;
    }
    public abstract void Depositar(decimal monto);
    
    public abstract void Retirar(decimal monto);
    
}
