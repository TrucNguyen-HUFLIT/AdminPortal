//#region Change Background-color button Login & Signup
function backgroundColorSwap1() {
    document.getElementById("btn-signup").style.backgroundColor = "#00bbff"
    document.getElementById("btn-signup").style.color = "#FFFFFF";
    document.getElementById("btn-signup").style.borderColor = "#FFFFFF";

    document.getElementById("btn-login").style.color = "#00bbff";
    document.getElementById("btn-login").style.backgroundColor = "rgba(0,0,0,.0)";
    document.getElementById("btn-login").style.borderColor = "#00bbff";
}

function backgroundColorSwap2() {
    document.getElementById("btn-signup").style.backgroundColor = "rgba(0,0,0,.0)"
    document.getElementById("btn-signup").style.color = "#00bbff";
    document.getElementById("btn-signup").style.borderColor = "#00bbff";

    document.getElementById("btn-login").style.backgroundColor = "#00bbff";
    document.getElementById("btn-login").style.color = "#FFFFFF";
    document.getElementById("btn-login").style.borderColor = "#FFFFFF";
}
//#endregion

//#region Call the dataTables jQuery plugin
$(document).ready(function () {
    $('#dataTable').DataTable();
});
//#endregion

//#region Show button Save when change Img src
function ShowBtnSave() {
    document.getElementById("btn-save-img").style.display = 'block';
}
//#endregion

//#region Change Img 
function ChangeImg(src) {
    document.getElementById('output').src = window.URL.createObjectURL(src.files[0])
}
//#endregion

//#region Show button Save, input Password and '*' Required when change user's information 
function ShowBtnSave_PW_Required() {
    if (document.getElementById("save_password").style.display == 'none') {
        document.getElementById("save_password").style.display = 'block';
        document.getElementById("requiredFN").style.display = 'inline-block';
        document.getElementById("requiredLN").style.display = 'inline-block';

    }
}
//#endregion

//#region Show form change Password
function ShowForm_PW() {
    if (document.getElementById("form-changepassword").style.display == 'none') {
        document.getElementById("form-changepassword").style.display = 'block';
    } else if (document.getElementById("form-changepassword").style.display == 'block') {
        document.getElementById("form-changepassword").style.display = 'none';
    }
}
//#endregion

//#region Add class 'active' to item of left menu

function Active() {
    var y = document.getElementById("Active").value;

    if (y == "active") {
        var x = document.getElementById("addActive");
        x.classList.add("active");
    }
}

function ActiveProfile() {
    var y = document.getElementById("ActiveProfile").value;

    if (y == "active") {
        var x = document.getElementById("addActiveProfile");
        x.classList.add("active");
    }

}
window.onload = function () {
    Active();
    ActiveProfile();
};
//#endregion

//#region Login in Login View
$("#login-form").submit(function (e) {
    e.preventDefault();

    let form = $(this).serializeArray();
    $.ajax({
        url: '/account/login',
        type: 'post',
        contentType: 'application/x-www-form-urlencoded',
        data: form,
        success: function () {
            window.location.replace("/profile/index");
        },
        error: function (data) {
            console.log(data);
            shakeModalLogin();

            var errors = data.responseJSON;

            document.getElementById("Err_EmailLogin").innerHTML = "";
            document.getElementById("Err_PasswordLogin").innerHTML = "";

            $.each(errors, function (key, value) {
                if (value != null) {
                    $("#Err_" + key + "Login").html(value[value.length - 1]);
                    console.log(value[0]);
                }
            });

            //#region code cũ
            //try {
            //    var objectValidation = data.responseJSON;
            //    if (objectValidation["Email"] != undefined)
            //        document.getElementById("Err_Email1").innerHTML = objectValidation["Email"];
            //    else
            //        document.getElementById("Err_Email1").innerHTML = "";

            //    if (objectValidation["Password"] != undefined)
            //        document.getElementById("Err_Password1").innerHTML = objectValidation["Password"];
            //    else
            //        document.getElementById("Err_Password1").innerHTML = "";

            //    shakeModalLogin();
            //}
            //catch {
            //    document.getElementById("Err_Email1").innerHTML = "";
            //    document.getElementById("Err_Password1").innerHTML = "";
            //    shakeModalLogin();
            //}
            //#endregion
        },

    });
});
//#endregion

//#region Register Account in Login View
function Register() {
    let form = $('#register-form').serializeArray();
    console.log(form);
    $.ajax({
        url: '/account/register',
        type: 'post',
        contentType: 'application/x-www-form-urlencoded',
        data: form,
        success: function (data, textStatus, jQxhr) {

            ToastRegister();
            showLoginForm();
        },
        error: function (data) {
            console.log(data);
            shakeModalLogin();

            var errors = data.responseJSON;

            document.getElementById("Err_EmailRegister").innerHTML = "";
            document.getElementById("Err_PasswordRegister").innerHTML = "";
            document.getElementById("Err_ConfirmPasswordRegister").innerHTML = "";

            $.each(errors, function (key, value) {
                if (value != null) {
                    $("#Err_" + key + "Register").html(value[value.length - 1]);
                    console.log(value[0]);
                }
            });

            //#region code cũ
            //try {
            //    var objectValidation = JSON.parse(data.responseText);
            //    if (objectValidation["Email"] != undefined)
            //        document.getElementById("Err_Email2").innerHTML = objectValidation["Email"];
            //    else
            //        document.getElementById("Err_Email2").innerHTML = "";

            //    if (objectValidation["Password"] != undefined)
            //        document.getElementById("Err_Password2").innerHTML = objectValidation["Password"];
            //    else
            //        document.getElementById("Err_Password2").innerHTML = "";

            //    if (objectValidation["ConfirmPassword"] != undefined)
            //        document.getElementById("Err_ConfirmPassword").innerHTML = objectValidation["ConfirmPassword"];
            //    else
            //        document.getElementById("Err_ConfirmPassword").innerHTML = "";

            //    shakeModalRegister();
            //}
            //catch {
            //    document.getElementById("Err_Email2").innerHTML = "";
            //    document.getElementById("Err_Password2").innerHTML = "";
            //    document.getElementById("Err_ConfirmPassword").innerHTML = "";
            //    shakeModalRegister();
            //}
            //#endregion
        }
    });
}
//#endregion

//#region Delete Account in Edit View
function DeleteAcc() {
    var confirm = prompt('Text "Delete" to Delete this account').toLowerCase();

    if (confirm == "delete") {

        let form = $('#edit-delete-acc-form').serializeArray();
        console.log(form);
        $.ajax({
            url: '/account/delete',
            type: 'delete',
            contentType: 'application/x-www-form-urlencoded',
            data: form,
            success: function () {
                ToastDelete();
                setTimeout(() => window.location.replace("/account/index"), 2000);
            }
        });
    }
    else {
        DeleteAcc();
    }
}
//#endregion

//#region Show Toast when Register, Delete and Create is successful
function ToastRegister() {
    // Get the snackbar DIV
    var x = document.getElementById("toastRegister");

    // Add the "show" class to DIV
    x.className = "show";

    // After 3 seconds, remove the show class from DIV
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 1500);
}

function ToastDelete() {
    // Get the snackbar DIV
    var x = document.getElementById("toastDelete");

    // Add the "show" class to DIV
    x.className = "show";

    // After 3 seconds, remove the show class from DIV
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 4000);
}

function ToastCreate() {
    // Get the snackbar DIV
    var x = document.getElementById("toastCreate");

    // Add the "show" class to DIV
    x.className = "show";

    // After 3 seconds, remove the show class from DIV
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 4000);
    getElementById("toastCreate").style.visibility = "hidden";
}
//#endregion

//#region Shake model when Login and Register is wrong
function shakeModalLogin() {
    $('#loginModal .modal-dialog').addClass('shake');
    $('.error').addClass('alert alert-danger').html("Invalid email/password combination!");
    $('input[type="password"]').val('');
    setTimeout(function () {
        $('#loginModal .modal-dialog').removeClass('shake');
    }, 1000);
}
function shakeModalRegister() {
    $('#loginModal .modal-dialog').addClass('shake');
    $('.error').addClass('alert alert-danger').html("Email already exists or check your password!");

    $('input[type="password"]').val('');
    setTimeout(function () {
        $('#loginModal .modal-dialog').removeClass('shake');
    }, 1000);
}
//#endregion

//#region Create in Create View
$("#create-acc-form").submit(function (e) {
    e.preventDefault();
    //FromData to post upload File
    var formData = new FormData($(this)[0]);
    //form valid

    $.ajax({
        url: '/account/create',
        type: 'post',
        contentType: false,
        async: false,
        cache: false,
        data: formData,
        enctype: 'multipart/form-data',
        processData: false,
        success: function () {
            window.location.replace("/account/index");
        },
        error: function (data) {
            console.log(data);

            var errors = data.responseJSON;
            if (errors == undefined) {
                document.getElementById("EmailExisted").innerHTML = data.responseText;
                return;
            }

            document.getElementById("Err_FirstName").innerHTML = "";
            document.getElementById("Err_LastName").innerHTML = "";
            document.getElementById("Err_Email").innerHTML = "";
            document.getElementById("Err_Password").innerHTML = "";

            $.each(errors, function (key, value) {
                if (value != null) {
                    var id = "#Err_" + key.substring(14);
                    $(id).html(value[value.length - 1]);
                    console.log(value[0]);
                }
            });

            //#region code cũ
            //try {
            //    var objectValidation = data.responseJSON;

            //    if (objectValidation["accountCreate.FirstName"] != undefined)
            //        document.getElementById("Err_FirstName").innerHTML = objectValidation["accountCreate.FirstName"];
            //    else
            //        document.getElementById("Err_FirstName").innerHTML = "";

            //    if (objectValidation["accountCreate.LastName"] != undefined)
            //        document.getElementById("Err_LastName").innerHTML = objectValidation["accountCreate.LastName"];
            //    else
            //        document.getElementById("Err_LastName").innerHTML = "";

            //    if (objectValidation["accountCreate.Email"] != undefined)
            //        document.getElementById("Err_Email").innerHTML = objectValidation["accountCreate.Email"];
            //    else
            //        document.getElementById("Err_Email").innerHTML = "";

            //    if (objectValidation["accountCreate.Password"] != undefined)
            //        document.getElementById("Err_Password").innerHTML = objectValidation["accountCreate.Password"];
            //    else
            //        document.getElementById("Err_Password").innerHTML = "";
            //}
            //catch {
            //    document.getElementById("Err_FirstName").innerHTML = "";
            //    document.getElementById("Err_LastName").innerHTML = "";
            //    document.getElementById("Err_Email").innerHTML = "";
            //    document.getElementById("Err_Password").innerHTML = "";
            //}
            //#endregion
        },

    });
});
//#endregion

//#region Edit in Edit View
$("#edit-delete-acc-form").submit(function (e) {
    e.preventDefault();

    let form = $(this).serializeArray();
    $.ajax({
        url: '/account/edit',
        type: 'post',
        contentType: 'application/x-www-form-urlencoded',
        data: form,
        success: function (data) {
            console.log(data);
            window.location.replace("/account/edit/"+data);
        },
        error: function (data) {
            console.log(data);

            try {
                var objectValidation = data.responseJSON;

                if (objectValidation["accountEdit.FirstName"] != undefined)
                    document.getElementById("Err_FirstName").innerHTML = objectValidation["accountEdit.FirstName"];
                else
                    document.getElementById("Err_FirstName").innerHTML = "";

                if (objectValidation["accountEdit.LastName"] != undefined)
                    document.getElementById("Err_LastName").innerHTML = objectValidation["accountEdit.LastName"];
                else
                    document.getElementById("Err_LastName").innerHTML = "";
            }
            catch {
                document.getElementById("Err_FirstName").innerHTML = "";
                document.getElementById("Err_LastName").innerHTML = "";
            }
        },

    });
});
//#endregion