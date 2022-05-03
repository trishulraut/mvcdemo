$(document).ready(function () {
    //alert("Category added Sucessfully");
    getMainCategoryList();
    //$('#demo').multiselect();
    $('#demo').multiselect({
        selectAllValue: 'multiselect-all',
        //enableFiltering: true,
        enableFullValueFiltering: true,


    });
   
});


var savevalidation = function () {
    var NAME = $("#txtname").val();
    var AGE = $("#txtage").val();
    var MOBILE = $("#txtmob").val();
    var EMAIL = $("#txtemail").val();
    var N_ID = $("#lblvid").val();
  

    var model = {
        NAME: NAME, MOBILE: MOBILE, AGE: AGE, EMAIL: EMAIL, N_ID: N_ID
    };
    $.ajax({
        url: "/validation/Savevalidation",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",

        success: function (response) {
            $.alert({
                title: 'alert',
                content: "DONE",
                type: "blue"
            });
            //alert(response.Message);
            //getMainCategoryList();
        }
      
    });
}

var getMainCategoryList = function () {
    $.ajax({
        url: "/validation/Getvalidet",
        method: "post",
        //data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tbl_validater tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.N_ID + "</td><td>" + elementValue.NAME + "</td><td>" + elementValue.AGE + "</td> <td>" + elementValue.EMAIL + "</td><td>" + elementValue.MOBILE + "</td><td><input type = 'submit' value = 'Delete' onClick = 'deleteRegistration(" + elementValue.N_ID + ")'/> </td> <td> <input type = 'submit' value = 'Edit' onClick = 'Editdata(" + elementValue.N_ID + ")'/></td> </td></tr>";

            });
            $("#tbl_validater").append(html);
        }
    })
}
var deleteRegistration = function (ID) {
    var model = { ID: ID };
    $.confirm({
        title: 'warnning',
        buttom: {
            confirm: function () {
                $.ajax({
                    url: "/validation/deletevalidation",
                    method: "post",
                    data: JSON.stringify(model),
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        $.alert({
                            title: 'alter',
                            content: "deleted",
                            type :'red'
                        })
                    }
                });
            }
        }
    });
    
   
}
var Editdata = function (id) {

    var model = { ID: id };
    alert("Record Edit Successfully ....");
    $.ajax({

        url: "/validation/GetEditData ",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            $("#lblvid").val(response.model.N_ID);
            $("#txtname").val(response.model.NAME);
            $("#txtage").val(response.model.AGE);
            $("#txtemail").val(response.model.EMAIL);
            $("#txtmob").val(response.model.MOBILE);
            alert("Record Edit Successfully ....");

        }
    });

}
var ClearData = function () {

    $("#lblvid").val("");
    $("#txtname").val("");
    $("#txtemail").val("");
    $("#txtmob").val("");

}
