window.onload = function () {
    ListarMarca();
    
}
function ListarMarca() {
    pintar({
        url:"Marca/ListarMarca",
            id:"divtabla",
        cabeceras:["ID Marca", "Nombre Marca","Descripcion"],
        propiedades: ["IdMarca", "NombreMarca", "Descripcion"]
    },
        {
            busqueda: true,
            url: "Marca/BuscarMarca",
            nombreparametro: "nombre",
            type: "text",
            button: false,
            id: "txtnombremarca",
        }
    )
}

