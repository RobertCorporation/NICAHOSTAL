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
                if (objBusqueda.button == undefined)
                    objBusqueda.button = true;

                //asignar Valores
                objConfiguracionGlobal = objConfiguracion;
                objBusquedaGlobal = objBusqueda;
              
                contenido += `<div class="input-group mb-3">`

                contenido += `<input type="${objBusqueda.type}" class="form-control"
                                       id="${objBusqueda.id}"
                                       ${objBusqueda.button == true ? "" : "onkeyup='Buscar()'"}
                                       class="form-control"
                                       placeholder="${objBusqueda.placeholder}"
                                       />`
                if (objBusqueda.Button == true) {
                    contenido += `
                                       <button class="btn btn-primary"
                                        onclick="Buscar()"
                                        type="Button"
                                        id="btnnombreTipoHabitacion"> Buscar</button>`
                }
                
                contenido +=`</div>`
            }
            contenido += "<div id='divContenedor'>";
            contenido += GenerarTabla(objConfiguracion, res);
            contenido += "</div>"
            document.getElementById(objConfiguracion.id).innerHTML = contenido;
           
        })
}

function GenerarTabla(objConfiguracion, res) {
    var contenido = "";
    contenido += "<table class='table'>";
    contenido += "<tr>";
    for (var j = 0; j < objConfiguracion.cabeceras.length; j++) {
        contenido += "<th>" + objConfiguracion.cabeceras[j] + "</th>"
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
    return contenido;

}

function fetchGet(url, callback) {
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbsoluta = window.location.protocol + "//" +
        window.location.host + raiz + url;
    fetch(urlAbsoluta).then(res => res.json())
        .then(res => {
            callback(res)
        }).catch(err => {
            console.log(err);
        })
}

function Buscar() {
    var objconf = objConfiguracionGlobal;
    var objBus = objBusquedaGlobal;
    //id del control

    var valor = get(objBus.id)
    fetchGet(`${objBus.url}/?${objBus.nombreparametro}=` + valor, function (res) {
        var rpta = GenerarTabla(objconf, res);
        document.getElementById("divContenedor").innerHTML = rpta;
    })

    /*
    fetch(`${objBus.url}/?${objBus.nombreparametro}=` + valor)
        .then(res => res.json())
        .then(res => {
            var rpta = GenerarTabla(objconf, res);
            document.getElementById("divContenedor").innerHTML=rpta;
        })*/


    /*pintar({
        url: `${objBus.url}/?${objBus.nombreparametro}=` + valor,
        id: objconf.id,
        cabeceras: objconf.cabeceras,
        propiedades: objconf.propiedades
    }, objBus)*/
}