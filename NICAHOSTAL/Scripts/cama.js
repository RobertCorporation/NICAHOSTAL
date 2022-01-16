window.onload = function () {
    ListarCama();
}

function ListarCama() {
    pintar({
        url: "Cama/ListarCama",
        id:"divtabla",
        cabeceras: ["ID Cama", "Nombre", "Descripcion"],
        propiedades: ["IdCama", "Nombre", "Descripcion"]
    })
}
