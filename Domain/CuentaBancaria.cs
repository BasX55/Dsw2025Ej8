namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public TipoCuenta _tipo{ get { return _tipo; } private set { _tipo = value; } }
    public string _numero { get { return _numero; } private set { _numero = value; } }
    public decimal _saldo { get { return _saldo } private set { _saldo = value; } }

    public Estado _estado { get { return _estado; } private set { _estado = value; } }
    public decimal _tasaDeInteres { get { return _tasaDeInteres; } private set { guardardecimal(ref value); } }
    public decimal _limiteDeDescubierto { get { return _limiteDeDescubierto; } private set { guardardecimal(ref value); } }
    public decimal _comision { get { return _comision; } private set { guardardecimal(ref value); } }
    public string[] _titulares { get { return _titulares; } private set { _titulares = value; } }



    public void guardardecimal(ref decimal valor)
    {
        if (valor >= 0)
        {
            _saldo = valor;
        }
        else
        {
            throw new ArgumentException("El valor ingresado no es valido");
        }
    }

    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _tipo = tipo;
        _estado = Estado.Activa;
        _titulares = titulares;
    }
 
    public void Depositar(decimal monto)
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            monto -= monto * _comision;
            _saldo += monto;
        }
    }

    public void Retirar(decimal monto)
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo -= monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            if (_saldo - monto >= -_limiteDeDescubierto)
            {
                _saldo -= monto;
            }
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
            }
        }
    }

    public void AplicarInteres()
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }
}
