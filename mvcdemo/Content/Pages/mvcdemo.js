

$(document).ready(function () {
    //alert("Category added Sucessfully");
    getMainCategoryList();
    $('#tbl_mvcdemo').dataTable({
        searching: true,
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                title: 'Excel',
                text: 'excel'
                //Columns to export
                //exportOptions: {
                //     columns: [0, 1, 2, 3,4,5,6]
                // }
            },
            {
                extend: 'pdfHtml5',
                title: 'PDF',
                text: 'PDF'
                //Columns to export
                //exportOptions: {
                //     columns: [0, 1, 2, 3, 4, 5, 6]
                //  }
            }
        ]
    });


});

   

var savemvcdemo = function () {
    var ID = $("#lblid").val();
    var NAME = $("#txtname").val();
    var MOBILE_NO = $("#txtmob").val();
    var EMAIL = $("#txtemail").val();
  
    var model = {
        NAME: NAME, MOBILE_NO: MOBILE_NO, EMAIL: EMAIL, ID:ID
    };
    $.ajax({
        url: "/mvcdemo/Savemvcdemo",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",

        success: function (response) {
            alert(response.Message);
            getMainCategoryList();
           
        }
    });
    ClearData();

}

var getMainCategoryList = function () {

    $.ajax({
        url: "/mvcdemo/GetMvcdemos",
        method: "post",
        //data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        async: false,
        success: function (response) {
            var html = "";
            $("#tbl_mvcdemo tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.NAME + "</td><td>" + elementValue.EMAIL + "</td><td>" + elementValue.MOBILE_NO + "</td></tr>";/*<td> <input type = 'submit' value = 'Delete' onClick = 'deleteRegistration(" + elementValue.ID + ")'/></td><td> <input type = 'submit' value = 'Edit' onClick = 'Editdata(" + elementValue.ID + ")'/></td>*/

            });
            $("#tbl_mvcdemo").append(html);
            /*$("#tbl_mvcdemo").DataTable();*/

          
        
        }

    });
}
var deleteRegistration = function (id) {
    var model = { ID: id };
    $.ajax({
        url: "/mvcdemo/deletemvc",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
        alert("Record Deleted Successfully ....");
        }
    });
}
var Editdata = function (id) {

        var model = { ID: id };
        alert("Record Edit Successfully ....");
        $.ajax({
            
            url: "/mvcdemo/GetEditData ",
            method: "post",
            data: JSON.stringify(model),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                
                $("#lblid").val(response.model.ID);
                $("#txtname").val(response.model.NAME);
                $("#txtemail").val(response.model.EMAIL);
                $("#txtmob").val(response.model.MOBILE_NO);
                alert("Record Edit Successfully ....");

            }
        });

}
var ClearData = function () {

    $("#lblid").val("");
    $("#txtname").val("");
    $("#txtemail").val("");
    $("#txtmob").val("");

}
//var getMainRegistrationList = function () {
   

//    $.ajax({
//        url: "/mvcdemo/GetRegistrationList",
//        method: "post",
//        data: JSON.stringify(model),
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        async: false,

//        success: function (response) {<td> <input type = 'submit' value = 'Delete' onClick = 'deleteRegistration(" + elementValue.ID + ")'/></td><td> <input type = 'submit' value = 'Edit' onClick = 'Editdata(" + elementValue.ID + ")'/></td>"
//            var html = "";
//            $("#tbl_mvcdemo tbody").empty();
//            $.each(response.model, function (index, elementValue) {
//                html += "<tr><td>" + elementValue.NAME + "</td><td>" + elementValue.EMAIL + "</td><td>" + elementValue.MOBILE_NO + "</td><td> <input type = 'submit' value = 'Delete' onClick = 'deleteRegistration(" + elementValue.ID + ")'/></td><td> <input type = 'submit' value = 'Edit' onClick = 'Editdata(" + elementValue.ID + ")'/></td></tr>";

//            });
//            $("#tbl_mvcdemo").append(html);




//        }
//    });
//}
var getMainRegistrationList = function () {
var companyname = $("#txtAccountName").val();
var model = { CompanyName: companyname };
     
}



