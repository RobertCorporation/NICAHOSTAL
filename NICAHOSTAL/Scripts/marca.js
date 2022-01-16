window.onload = function () {
    ListarMarca();
    
}
function ListarMarca() {
    pintar({
        url:"Marca/ListarMarca",
            id:"divtabla",
        cabeceras:["ID Marca", "Nombre Marca","Descripcion"],
        propiedades: ["IdMarca", "NombreMarca", "Descripcion"]
    })
}

