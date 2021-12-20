$(document).ready(function () {
    DISPLAY();
});


var saveimg = function () {

    var message = "";
    $formData = new FormData();
    var IMG = document.getElementById('file1');
    if (IMG.files.length > 0) {
        for (var i = 0; i < IMG.files.length; i++) {
            $formData.append('file-' + i, IMG.files[i]);

        }
    }
    var NAME = $("#txtname").val();
    $formData.append('Name', NAME);

    if (message == "") {
        $.ajax({
            url: "/IMG/Saveimg",
            type: 'post',
            data: $formData,
            dataType: 'json',
            contentType: false,
            processData: false,

            success: function (response) {
                $.alert({
                    title: 'Alert!',
                    content: " successfull",
                    type: 'green'
                });
                alert("done");
            }
        });


    }
}


var DISPLAY = function () {
    $.ajax({
        url: "/IMG/GetDISPLAY",
        method: "Post",
       // data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#TBL_IMG tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.NAME + "</td><td><img src='../img/" + elementValue.IMG + "' width='100px' height='100px'/></td><td><input type = 'submit' value = 'Edit' onClick = 'Editdata(" + elementValue.ID + ")'/></td></tr > ";
     
                //    html += "<tr><td>" + elemntValue.ProductName + "</td><td><img src='../Content/images/" + elementValue.Images + "'/></td><td>" + elementValue.Price + "</td><td>" + elementValue.Discount + "</td><td>" + elementValue.Category + "</td><td>" + elementValue.Unit + "</td></tr>";
            });
            $("#TBL_IMG").append(html);
        }
    });
}
var Editdata = function (id) {
    var model = { ID: id };
    alert("Record Edit Successfully ....");
    $.ajax({
        url: "/IMG/GetEditData ",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#txtid").val(response.model.IMG_ID);
            $("#txtname").val(response.model.NAME);
            
            alert("Record Edit Successfully ....");
        }
    });

}