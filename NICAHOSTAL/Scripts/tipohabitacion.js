window.onload = function () {
    listarTipoHabitacion();
}
function listarTipoHabitacion() {
    pintar({
        url: "TipoHabitacion/ListAll", id: "divtabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["Id", "Nombre", "Descripcion"]
    });

    fetch("TipoHabitacion/ListAll")
        .then(res => res.json())
        .then(res => {
            var contenido = "<table class='table'>";
            contenido += "<tr>";
            contenido += "<th>Id</th>"
            contenido += "<th>Nombre</th>"
            contenido += "<th>Descripcion</th>"
            contenido += "</tr>";
            for (var i = 0; i < res.length; i++) {
                fila = res[i]
                contenido += "<tr>";
                contenido += "<td>" + fila.Id +"</td>";
                contenido += "<td>" + fila.Nombre +"</td>";
                contenido += "<td>" + fila.Descripcion +"</td>";
                contenido += "</tr>";
            }
            contenido+="</table>"
            document.getElementById("divtabla").innerHTML = contenido;
            alert(res)
        })
}