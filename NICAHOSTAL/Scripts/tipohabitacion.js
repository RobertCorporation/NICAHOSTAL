window.onload = function () {
    listarTipoHabitacion();
}
function listarTipoHabitacion() {
    pintar({
        url: "TipoHabitacion/ListAll", id: "divtabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["Id", "Nombre", "Descripcion"],
        editar: true,
        eliminar: true,
        propiedadId : "Id"
    });
}

function Buscar() {
    var nombreTipoHabitacion = get("txtnombreTipoHabiacion")
    pintar({
        url: "TipoHabitacion/FiltrarTipoHabitacionPorNombre/?nombreHabitacion=" + nombreTipoHabitacion,
        id: "divtabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["Id", "Nombre", "Descripcion"],
        editar: true,
        eliminar: true,
        propiedadId: "Id"
        
    })
}

function Limpiar() {
    //setParametros("Id", "")
    //setParametros("Nombre", "")
    //setParametros("Descripcion", "")
    LimpiarDatos("frmTipoHabitacion", ["Id"])
    //Correcto("Funciono mi alerta")
}

function GuardarDatos() {
    var frmTipoHabitacion = document.getElementById("frmTipoHabitacion");
    var frm = new FormData(frmTipoHabitacion);
    fetchPostText("TipoHabitacion/GuardarDatos", frm, function (res) {
        if (res == "1") {
            listarTipoHabitacion();
            Limpiar();
        }
    })


    /*fetch("TipoHabitacion/GuardarDatos", {
        method: "POST",
        body: frm
    }).then(res => res.text())
        .then(res => {
            if (res=="1") {
                listarTipoHabitacion();
            }
        })*/
}

function Editar() {
    fetchGet("TipoHabitacion/BuscarPorId/?Id=" + id, function (res) {
        setN("Id")
        setN("Nombre")
        setN("Descripcion")
    })
}