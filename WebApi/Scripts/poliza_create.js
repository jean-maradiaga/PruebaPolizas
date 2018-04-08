function GetCliente() {

    var cliente = JSON.parse(localStorage.getItem("cliente"));

    if (!(cliente && cliente.ID && cliente.Nombre && cliente.Apellido)) {
        window.location.replace("/Clientes");
    }

    $("input[name=Cliente]").val(cliente.Nombre + " " + cliente.Apellido);

    return cliente;
}

var GetDataForm = function ($form) {

    var poliza = {};

    $form.find('input, select, textarea').each(function (index, input) {
        poliza[$(this).attr("name")] = this.value;
    });

    poliza.Cliente = cliente;
    poliza.ID_Poliza = 0;
    return poliza;
};

$("#frmPoliza").submit(function (e) {

    e.preventDefault();

    if (!$(this).valid()) {
        return false;
    }

    $.ajax({
        url: "/api/Poliza/",
        method: "POST",
        data: JSON.stringify(GetDataForm($("#frmPoliza"))),
        contentType: "application/json"
    }).done(function (data) {
        window.location.href = "/Polizas";
    }).fail(function (jqXHR, textStatus) {
        alert("Request failed: " + textStatus);
    });

});

var cliente = GetCliente();
$("input[name=Cliente]").attr("disabled", "disabled");