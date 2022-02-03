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
            type: "fieldset",
            guardar: true,
            limpiar: true,
            formulariogenerico : false,  // en caso que desee usar el guardado del formulario Genericamente poner en true
            legend: "Datos de la Cama",
            formulario: [
                [{
                    class: "mb-3 col-md-5",
                  
                    label: "Id Cama",
                    name: "Id",
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

