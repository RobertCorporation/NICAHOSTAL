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