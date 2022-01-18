function get(id) {
    return document.getElementById(id).value;
}

var objConfiguracionGlobal;
var objBusquedaGlobal;
function pintar(objConfiguracion, objBusqueda) {
    //URL Absoluta  https://localhost ...
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbsolute = window.location.protocol + "//" +
        window.host + raiz + objConfiguracion.url;

    //Controles // Accion     Trabajando con URL Relativa 
    fetch(objConfiguracion.url)
        .then(res => res.json())
        .then(res => {
            var contenido = "";
            if (objBusqueda != undefined && objBusqueda.busqueda == true) {
                if (objBusqueda.placeholder == undefined)
                    objBusqueda.placeholder = "Ingrese un Valor"
                if (objBusqueda.id == undefined) 
                    objBusqueda.id = "txtbusqueda"
                if (objConfiguracion.id == undefined)
                    objConfiguracion.id == "divtabla"

                //asignar Valores
                objConfiguracionGlobal = objConfiguracion;
                objBusquedaGlobal = objBusqueda;
              
                contenido += `<div class="input-group mb-3">`
                contenido += `<input type="${objBusqueda.type}"
                                       id="${objBusqueda.id}"
                                       class="form-control"
                                       placeholder="${objBusqueda.placeholder}"
                                       />`
                contenido +=`
                                <button class="btn btn-primary"
                                        onclick="Buscar()"
                                        type="button"
                                        id="btnnombreTipoHabitacion"> Buscar</button>
                            </div>`
            }
            contenido += "<table class='table'>";
            contenido += "<tr>";
            for (var j = 0; j < objConfiguracion.cabeceras.length; j++) {
                contenido+="<th>"+objConfiguracion.cabeceras[j]+"</th>"
            }
            contenido += "</tr>";
            var fila;
            var propiedadActual;
            for (var i = 0; i < res.length; i++) {
                fila = res[i]
                contenido += "<tr>";
                for (var j = 0; j < objConfiguracion.propiedades.length; j++) {
                    propiedadActual = objConfiguracion.propiedades[j]
                    contenido += "<td>" + fila[propiedadActual] + "</td>";
                }
                //contenido += "<td>" + fila.Id + "</td>";
                //contenido += "<td>" + fila.Nombre + "</td>";
                //contenido += "<td>" + fila.Descripcion + "</td>";
                contenido += "</tr>";
            }
            contenido += "</table>"
            document.getElementById("divtabla").innerHTML = contenido;
           
        })
}

function Buscar() {
    var objconf = objConfiguracionGlobal;
    var objBus = objBusquedaGlobal;
    //id del control

    var valor = get(objBus.id)
    pintar({
        url: `${objBus.url}/?${objBus.nombreparametro}=` + valor,
        id: objconf.id,
        cabeceras: objconf.cabeceras,
        propiedades: objconf.propiedades

    })
}