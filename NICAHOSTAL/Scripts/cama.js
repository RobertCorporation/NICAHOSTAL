window.onload = function () {
    ListarCama();
}

function ListarCama() {
    pintar({
        url: "Cama/ListarCama",
        id:"divtabla",
        cabeceras: ["ID Cama", "Nombre", "Descripcion"],
        propiedades: ["IdCama", "Nombre", "Descripcion"],
        editar: true,
        eliminar: true,
        urlEliminar: "Cama/EliminarCama",
        parametroEliminar: "IdCama",
        urlRecuperar: "Cama/RecuperarCama",
        parametroRecuperar: "IdCamita",
        propiedadId: "IdCama"
    },
        {
            busqueda: true,
            url:"Cama/FiltrarCamaPorNombre",
            nombreparametro:"nombre",            
            //placeholder: "Ingrese nombre cama"
            type: "text",
            button:false,
            id: "txtnombrecama",
        },
        {
            Id:"frmCama",
            type: "fieldset",               
            urlGuardar:"Cama/GuardarCama",
            legend: "Datos de la Cama",
            formulario: [
                [{
                    class: "mb-3 col-md-5",
                  
                    label: "Id Cama",
                    name: "IdCama",
                    value: 0,
                    readonly: true
                },
                    {
                        class: "mb-3 col-md-7",
                      
                        label: "Nombre",
                        name: "Nombre"
                       
                    }],

                [{
                    class: "mb-3 col-md-12",
                    type: "textarea",
                    label: "Descripcion",
                    name: "Descripcion",
                    rows: "3",
                    cols: "10"
                 
                }]
            ]
        }
    )
}

