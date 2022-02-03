function get(id) {
    return document.getElementById(id).value;
}

function Error(texto="Ocurrio un Error") {
    Swal.fire({
        icon: 'error',
        title: 'Error',
        text: text
        
    })
}

function Correcto(texto="Se realizó correctamente") {
    Swal.fire({
        position: 'top-center',
        icon: 'success',
        title: texto,
        showConfirmButton: false,
        timer: 1500
    })
}


function Confirmacion(texto="¿Desea Guardar los Cambios?", title="Confirmacion", callback) {
  return  Swal.fire({
        title: title,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
      confirmButtonText: 'Si',
      cancelButtonText: 'No'
    }).then((result) => {
        if (result.isConfirmed) {
            callback();
        }
    })
}


function set(Id, valor) {
    return document.getElementById(Id).value = valor;
}

function setParametros(Id, valor) {
    return document.getElementsByName(Id)[0].value = valor;
}

var objConfiguracionGlobal;
var objBusquedaGlobal;
function pintar(objConfiguracion, objBusqueda, objFormulario) {
    //URL Absoluta  https://localhost ...
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbsolute = window.location.protocol + "//" +
        window.host + raiz + objConfiguracion.url;

    //Controles // Accion     Trabajando con URL Relativa 
    fetch(objConfiguracion.url)
        .then(res => res.json())
        .then(res => {
            var contenido = "";
             //Configuracion de Formulario
            if (objFormulario != undefined) {
               
                if (objFormulario.guardar == undefined)
                    objFormulario.guardar = true            
                if (objFormulario.limpiar == undefined)
                    objFormulario.limpiar = true
                if (objFormulario.formulariogenerico == undefined)
                    objFormulario.formulariogenerico = false
                
                var type = objFormulario.type;
                if (type == "fieldset") {
                    contenido += "<fieldset class='form-control'>";
                    if (objFormulario.legend != undefined) {
                        contenido += "<legend>" + objFormulario.legend + "</legend>";
                    }

                    contenido += ConstruirFormulario(objFormulario)
                    contenido += `
                    ${objFormulario.guardar == true ? `<div class="form-control">
                    <button class="btn btn-primary"
                    onclick="${ (objFormulario.formulariogenerico == undefined
                            || objFormulario.formulariogenerico == false ) ? 'GuardarDatos()'
                    :'GuardarGenerico()'}"> Aceptar</button>` : ''}

                    ${objFormulario.limpiar == true ? `<button class="btn btn-danger" onclick="Limpiar()">Limpiar</button></div >`:'' }`
                    contenido += "</fieldset>";
                }
               
            }
            if (objBusqueda != undefined && objBusqueda.busqueda == true) {
                if (objBusqueda.placeholder == undefined)
                    objBusqueda.placeholder = "Ingrese un Valor"
                if (objBusqueda.id == undefined) 
                    objBusqueda.id = "txtbusqueda"
                if (objConfiguracion.id == undefined)
                    objConfiguracion.id == "divtabla"
                if (objBusqueda.button == undefined)
                    objBusqueda.button = true;
                if (objConfiguracion.editar == undefined)
                    objConfiguracion.editar = false;
                if (objConfiguracion.eliminar == undefined)
                    objConfiguracion.eliminar = false;
                if (objConfiguracion.propiedadId == undefined)
                    objConfiguracion.propiedadId = "Id";
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

function LimpiarDatos(idFormulario, exceptiones=[]) {
    var elementos = document.querySelectorAll("#frmTipoHabitacion [name]")
    for (var i = 0; i < elementos.length; i++) {
        //si esta incluido no hacer nada 
        if (!exceptiones.includes(elementos[i].name)) {
            elementos[i].value = "";
        }
       
    }
}

function GenerarTabla(objConfiguracion, res) {
    var contenido = "";
    contenido += "<table class='table table-bordered'>";
    contenido += "<tr>";
    for (var j = 0; j < objConfiguracion.cabeceras.length; j++) {
        contenido += "<th>" + objConfiguracion.cabeceras[j] + "</th>"
    }
    if (objConfiguracion.editar == true || objConfiguracion.eliminar ==true) {
        contenido += "<th>Operaciones</th>";
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
        if (objConfiguracion.editar == true || objConfiguracion.eliminar == true) {
            contenido += "<td>";
            if (objConfiguracion.editar == true) {
                contenido += `<i class="btn btn-primary" onclick='Editar(${fila[objConfiguracion.propiedadId]})'><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                              <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                              <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                              </svg></i>`
            }
            if (objConfiguracion.eliminar == true) {
                contenido += `<i class="btn btn-danger" onclick='Eliminar(${fila[objConfiguracion.propiedadId]})'><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                              <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
                              <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
                              </svg></i>`
            }

            contenido += "</td>";
        }

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

function fetchGetText(url, callback) {
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbsoluta = window.location.protocol + "//" +
        window.location.host + raiz + url;
    fetch(urlAbsoluta).then(res => res.text())
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

function fetchPostText(url, frm, callback){
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbsoluta = window.location.protocol + "//" +
        window.location.host + raiz + url;
    fetch(url, {
        method: "POST",
        body: frm
    }).then(res => res.text())
        .then(res => {
            callback(res)
        }).catch(err => {
            console.log(err)
        });
}

function RecuperarGenerico(url, idFormulario, exceptiones = []) {
    var elementos = document.querySelectorAll("#" + idFormulario + " [name]")
    var NombreName;
    fetchGet(url, function (res) {
        for (var i = 0; i < elementos.length; i++) {
            NombreName = elementos[i].name
            //si esta incluido no hacer nada 
            if (!exceptiones.includes(elementos[i].name)) {
                setParametros(NombreName, res[NombreName])
            }
        }

    });
    
}

function ConstruirFormulario(objFormulario) {
    var elementos = objFormulario.formulario;
    var contenido = "<div class='mt-3 mb-3'>";
    //Filas
    var arrayelemento;
    var numeroarrayelemento;
    for (var i = 0; i < elementos.length; i++) {
        arrayelemento = elementos[i];
        numeroarrayelemento = arrayelemento.length;
        contenido += "<div class='row'>";
        for (var j = 0; j < numeroarrayelemento; j++){
            var hijosArray = arrayelemento[j]
            if (hijosArray.class == undefined) {
                hijosArray.class = "mb-3";
            }
            if (hijosArray.type == undefined) {
                hijosArray.type = "text";
            }
            if (hijosArray.readonly == undefined) {
                hijosArray.readonly = false;
            }
            if (hijosArray.value == undefined) {
                hijosArray.value = "";
            }
            if (hijosArray.label == undefined) {
                hijosArray.label = hijosArray.name;
            }
            if (hijosArray.rows == undefined) {
                hijosArray.rows = "3";
            }
            if (hijosArray.cols == undefined) {
                hijosArray.cols = "10";
            }
            var typelemento = hijosArray.type;
            contenido += `<div class="${hijosArray.class}">`
            contenido += `<label>${hijosArray.label}</label>`
            if (typelemento == "text" || typelemento == "number" || typelemento == "date") {
                contenido += `<input type="${typelemento}" class="form-control" name="${hijosArray.name}" value="${hijosArray.value}" ${hijosArray.readonly == true ? "readonly": ""} />`
            } else if (typelemento == "textarea") {
                contenido += `<textarea name="${hijosArray.name}"
                class="form-control"
                rows="${hijosArray.rows}" cols="${hijosArray.cols}"> ${hijosArray.value}</textarea>`
            }
            contenido += `</div>`
        }
        contenido += "</div>"
    }        
    return contenido;
}