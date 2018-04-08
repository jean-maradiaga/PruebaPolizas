
var $formFields;
var poliza;
var cliente;

$(document).ready(function () {

$formFields = $("#frmPoliza").find('input:not([name=Cliente]),select,textarea');


    var request = $.ajax({
        url: "/api/Poliza/" + idPoliza,
        method: "GET",
        contentType: "application/json"
    });

    request.done(function (data) {
        data.Inicio_Vigencia = data.Inicio_Vigencia.substr(0, data.Inicio_Vigencia.indexOf('T'));
        fillForm($("#frmPoliza"), data);
        poliza = data;
        cliente = poliza.Cliente;
    });

    request.fail(function (jqXHR, textStatus) {
        alert("Request failed: " + textStatus);
    });

});
var toggleFormFields = function(isDisabled) {
    
    $formFields.each(function(index, input) {
        input.disabled = isDisabled;
    });

}

var fillForm = function($form, data) {

    $form.find('input,textarea').each(function (index,input) {
        this.value = data[$(this).attr("name")];
    });

    $("input[name=Cliente]").val(data.Cliente.Nombre + " " + data.Cliente.Apellido);
    selectOption("sltCubrimientos", data.Cubrimiento);
    selectOption("sltRiesgos", data.Riesgo);

}

var GetDataForm = function($form) {
    $form.find('input, select, textarea').each(function (index,input) {
        poliza[$(this).attr("name")] = this.value;
    });

    poliza.Cliente = cliente;
    poliza.ID_Poliza = idPoliza; 

    console.log(poliza);

    return poliza;
}

var selectOption = function(selectId, value) {
    $("#" + selectId + " option[value=" + value + "]").prop('selected', true);
}



$("#frmPoliza").find('input,select,textarea').each(function (index, input) {
        input.disabled = true;
});


var $formCtas = $(".form-cta");
var $updBtnContainer = $("#upd-btn-container");

function toggleFormCtas(isDisabled) {
    $formCtas.each(function (index, item) {
        item.disabled = isDisabled;
    });
}

$("#btn-editar").click(function () {

    toggleFormCtas(true);
    $updBtnContainer.css('visibility', 'visible');
    toggleFormFields(false);

});

$("#btn-cancelar").click(function () {

    toggleFormFields(true);
    $updBtnContainer.css('visibility', 'hidden');
    toggleFormCtas(false);
    fillForm($("#frmPoliza"), poliza);

});

$("#btn-guardar").click(function () {

    console.log(GetDataForm($("#frmPoliza")));


    $.ajax({
        url: "/api/Poliza/",
        method: "PUT",
        data: JSON.stringify(GetDataForm($("#frmPoliza"))),
        contentType: "application/json"
    }).done(function (data) {
        $("#btn-cancelar").trigger("click");
    }).fail(function (jqXHR, textStatus) {
        alert("Request failed: " + textStatus);
    });

});

