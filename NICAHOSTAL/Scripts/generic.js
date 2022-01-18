function get(id) {
    return document.getElementById(id).value;
}

function pintar(objConfiguracion) {
    //URL Absoluta  https://localhost ...
    var raiz = document.getElementById("hdfOculto").value;
    var urlAbsolute = window.location.protocol + "//" +
        window.host + raiz + objConfiguracion.url;

    //Controles // Accion     Trabajando con URL Relativa 
    fetch(objConfiguracion.url)
        .then(res => res.json())
        .then(res => {
            var contenido = "<table class='table'>";
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