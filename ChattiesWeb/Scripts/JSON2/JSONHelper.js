// Funcion generica para hacer los callbacks al servidor
function doJsonObjectAjaxCallback(serviceUrl, method, jsonObject, successFunction) {
    $.ajax(
        {
            type: "POST",
            url: chattiesObjects.BaseURL + serviceUrl + method,
            data: JSON.stringify(jsonObject),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunction,
            error: function (xhr, status, error) {
                chattiesObjects.GlobalMessage.Show(xhr.responseText, true);
            }
        });
}