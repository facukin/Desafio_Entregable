public class Usuario
{
    private string _id;
    private string _nombre;
    private string _apellido;
    private int nombreusuario;
    private string _contraseña;
    private int _mail;
    private string _domicilio;
}

public class Producto
{
    private string _id;
    private string _descripcion;
    private int _costo;
    private int _precioventa;
    private int _stock;
    private string idUsuario;
}

public class ProductoVendido
{
    private string _id;
    private string _idProducto;
    private int _stock;
    private string _idVenta;
}

public class Venta
{
    private string _id;
    private string _comentarios;
}