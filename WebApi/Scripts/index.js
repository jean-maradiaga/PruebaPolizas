$(document).ready(function () {

    var cols = [
        { "data": "Nombre" },
        { "data": "Periodo" },
        { "data": "Riesgo" },
        { "data": "Cubrimiento" },
        { "data": "Inicio_Vigencia" }
    ];

    var table = initTable("/api/Poliza", cols, "tblPolizas");
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
        var rowData = table.row(this).data();
        window.location.href = "/Polizas/Show/" + rowData.ID_Poliza;
    });


});