window.onload = function () {
    ListarProducto();
}

function ListarProducto() {
    pintar({
        url: "Producto/ListarProducto",
        id: "divtabla",
        cabeceras: ["Id Productos", "Nombre", "Precio","NombreMarca", "Stock", "Denominacion"],
        propiedades: ["IdProducto", "NombreProducto", "NombreMarca", "PrecioVenta", "Stock", "Denominacion" ]
    })
}

function Buscar() {
    var nombreProducto = get("txtnombreProducto")
    pintar({
        url: "Producto/BuscarProducto/?nombre=" + nombreProducto,
        id: "divtabla",
        cabeceras: ["Id Productos", "Nombre", "Precio", "NombreMarca", "Stock", "Denominacion"],
        propiedades: ["IdProducto", "NombreProducto", "NombreMarca", "PrecioVenta", "Stock", "Denominacion"]
    })
}
 