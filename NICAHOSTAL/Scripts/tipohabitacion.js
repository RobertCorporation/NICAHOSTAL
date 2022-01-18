window.onload = function () {
    listarTipoHabitacion();
}
function listarTipoHabitacion() {
    pintar({
        url: "TipoHabitacion/ListAll", id: "divtabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["Id", "Nombre", "Descripcion"]
    });

   
   
}

function Buscar() {
    var nombreTipoHabitacion = get("txtnombreTipoHabiacion")
    pintar({
        url: "TipoHabitacion/FiltrarTipoHabitacionPorNombre/?nombreHabitacion=" + nombreTipoHabitacion,
        id: "divtabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["Id", "Nombre", "Descripcion"]
        
    })
}