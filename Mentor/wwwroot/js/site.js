// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//console.log("document is loaded");
//$(document).ready(function () {
//    console.log("document is loaded");
//    $('#btnSubmit').click(function () {

//    }});



/*
 *   $(document).ready(function () {
    console.log("document is loaded");
    $("#submitBtn").click(function () {
        console.log("document is clicked");
        var form_data;
        form_data = new FormData();
        form_data.append("FirstName", $("#FirstName").val());
        form_data.append("LastName", $("#LastName").val());
        form_data.append("Password", $("#password").val());
        form_data.append("Gender", $("Gender").val());
        form_data.append("Education", $("education").val());
        form_data.append("Country", $("country").val());
        form_data.append("City", $("City").val());
        form_data.append("PhoneCode", $("pcode").val());
        form_data.append("PhoneNumber", $("PhoneNum").val());
        form_data.append("Address", $("address").val());
        form_data.append("Email", $("email").val());
        //submitForm(form_data);
        var obj = form_data;
        $.ajax({
            type: "POST",
            url: "/Student/StudentForm",
            contentType: false,
            processData: false,
            data: obj,
            success: function (data) {
                alert(data.message);
            },
            error: function () {
                alert("Error occured!!")
            }
        });
    });
    });
 * 
 */
