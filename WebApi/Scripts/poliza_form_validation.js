jQuery.validator.addMethod("riesgo", function (value, element) {
    debugger;
    return !($("select[name=Riesgo]").val() === "Alto" && parseInt(value,10) > 50);
}, "El porcentaje de cubrimiento no puede ser mayor a 50 debido a el riesgo de la poliza.");

$(document).ready(function () {

    $("select[name=Riesgo]").change(function () {
        $("input[name=Deducible]").valid();
    });

});

$(document).ready(function () {
    $("#frmPoliza").validate({
        rules: {
            Nombre: {
                required: true
            },
            Descripcion: {
                required: true,
                maxlength: 150
            },
            Periodo: {
                required: true,
                digits: true
            },

            Deducible: {
                required: true,
                digits: true,
                range: [1, 100],
                riesgo: true
            },
            Precio: {
                required: true,
                digits: true,
            },
            Riesgo: {
                required: true
            },
            Cubrimiento: {
                required: true
            },
            Inicio_Vigencia: {
                required: true
            }

        },
        messages: {
            Nombre: {
                required: "Por favor ingrese el nombre de la poliza",
            },
            Descripcion: {
                required: "Por favor infrese la descripcion de la poliza",
                maxlength: "La descripcion de la poliza debe de tener entre 1 y 150 caracteres"
            },
            Periodo: {
                required: "Por favor ingrese el periodo en meses de la poliza",
                digits: "Este campo solo acepta digitos"
            },

            Deducible: {
                required: "Por favor ingrese el deducible de la poliza en dolares",
                digits: "Este campo solo acepta digitos",
                range: "Este campo solo acepta valores entre 1 y 100"
            },
            Precio: {
                required: "Por favor ingrese el precio de la poliza",
                digits: "Este campo solo acepta digitos"
            },
            Riesgo: {
                required: "Por favor seleccione el riesgo de la poliza"
            },
            Cubrimiento: {
                required: "Por favor seleccione el cubrimiento de la poliza"
            },
            Inicio_Vigencia: {
                required: "Por favor seleccione la fecha de inicio de vigencia"
            }

        },
        errorElement: "div",
        errorPlacement: function (error, element) {
            error.addClass("invalid-feedback");
            error.insertAfter(element);

        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass("is-invalid");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass("is-invalid");
        }
    });
});