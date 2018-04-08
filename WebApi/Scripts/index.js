$(document).ready(function () {
    $('#tblPolizas').DataTable({
        "ajax": { "url": "/api/Poliza", "dataSrc": "" },
        "columns": [
            { "data": "ID_Poliza" },
            { "data": "Nombre" },
            { "data": "Periodo" },
            { "data": "Riesgo" },
            { "data": "Cubrimiento" },
            { "data": "Inicio_Vigencia" }
        ],
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ning˙n dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "⁄ltimo",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }
    });

    var $tblPolizas = $('#tblPolizas');

    $tblPolizas
        .on('init.dt', function () {
            $tblPolizas.DataTable().rows().every(function (rowIdx, tableLoop, rowLoop) {
                var data = this.data();
                data.Inicio_Vigencia = data.Inicio_Vigencia.substr(0, data.Inicio_Vigencia.indexOf('T'));
                this.data(data);
            });


            $tblPolizas.DataTable().columns.adjust().draw();

        })
        .dataTable();

    $('#tblPolizas tbody').on('click', 'tr', function () {
        window.location.href = "/Polizas/Show/" + $(this).find('td').eq(0).text();
    });


});