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
    LimpiarDatos("frmTipoHabitacion")
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

function Editar(id) {
    //fetchGet("TipoHabitacion/BuscarPorId/?id=" + id, function (res) {
    //    setParametros("Id", res.Id)
    //    setParametros("Nombre", res.Nombre)
    //    setParametros("Descripcion", res.Descripcion)
    //})

    RecuperarGenerico("TipoHabitacion/BuscarPorId/?id=" + id, "frmTipoHabitacion");
}

function Eliminar(id) {
    Confirmacion("¿Desea Eliminar el Tipo Habitacion?", "Confirmar eliminar", function (res) {
        fetchGetText("TipoHabitacion/EliminarDatos/?Id=" + id, function (rpta) {
            if (rpta == "1") {
                Correcto("Se Eliminó Correctamente");
                listarTipoHabitacion();

            }
        })
    })
}