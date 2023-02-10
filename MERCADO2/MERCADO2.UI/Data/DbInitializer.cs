using MERCADO2.Core.Modelos;
namespace MERCADO2.UI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MERCADO2Context context)
        {
            // Look for any students.
            if (context.Producto.Any())
            {
                return; // DB has been seeded
            }
            var productos = new Producto[]
            {
                new Producto{NombreProducto="Sopa Instantanea",Precio="50",Cantidad="30"},
                new Producto{NombreProducto="Fideos",Precio="76",Cantidad="12"}
            };
            context.Producto.AddRange(productos);
            context.SaveChanges();

            var marcas = new Marca[]
            {
                new Marca{NombreMarca="Marolio",ProductoId=20},
                new Marca{NombreMarca="Arcor",ProductoId=29}
            };
            context.Marca.AddRange(marcas);
            context.SaveChanges();

            var proveedores = new Proveedor[]
            {
                new Proveedor{ProveedorId=02,NombreProveedor="Carrillo Mayorista",TelefonoProveedor="0303456",DireccionProveedor="Calle falsa 123"},
                new Proveedor{ProveedorId=02,NombreProveedor="SuperPrecios",TelefonoProveedor="03222226",DireccionProveedor="Avenida falsa 123"}
            };
            context.Proveedor.AddRange(proveedores);
            context.SaveChanges();
        }

    }
}
