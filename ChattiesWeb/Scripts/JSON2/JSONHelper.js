//Dependiendo del framework regresa el objeto correcto
function getMain(obj) {
    if (obj.hasOwnProperty('d')) {
        return obj.d;
    }
    else {
        return obj;
    }
}

// Funcion generica para hacer los callbacks al servidor
function doJsonObjectAjaxCallback(formPath, serverParamVariableName, jsonObject, successFunction) {
    $.ajax(
        {
            type: "POST",
            url: formPath,
            data: "{" + serverParamVariableName + ": " + jsonObject + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunction,
            error: function (xhr, status, error)
            {
                $("#lblMensaje").text(xhr.responseText);
                $("#alertDiv").css("display", "block");
            }
        });
}