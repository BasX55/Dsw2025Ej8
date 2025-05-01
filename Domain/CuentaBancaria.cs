namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    private decimal _limiteDeDescubierto;
    private decimal _comision;
    public string Numero { get; protected set; }
    public decimal Saldo { get; protected set; }

    public Estado Estado { get; protected set; }
    public decimal TasaDeInteres { get; init; }
    public decimal LimiteDeDescubierto { get { return _limiteDeDescubierto; } protected init { guardardecimal(ref value); } }
    public decimal Comision { get { return _comision; } protected set { guardardecimal(ref value); } }
    public string[] Titulares { get; protected set; }



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

    public CuentaBancaria(string numero, decimal saldo, string[] titulares )
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares ?? new String[0];
        Console.WriteLine("ingresar valor de Comision");
        _comision = decimal.Parse(Console.ReadLine());
        Console.WriteLine("ingresar valor de  el límite de descubierto");
        _limiteDeDescubierto = decimal.Parse(Console.ReadLine());
    }
    public abstract void Depositar(decimal monto);
    
    public abstract void Retirar(decimal monto);
    
}
