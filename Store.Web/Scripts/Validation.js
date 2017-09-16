
function alphanumeric(event) {
    if (event.keyCode >= 48 && event.keyCode <= 57)
        return true;
    if (event.keyCode >= 65 && event.keyCode <= 90)
        return true;
    if (event.keyCode >= 97 && event.keyCode <= 122)
        return true;
    if (event.keyCode == 230 || event.keyCode == 216 || event.keyCode == 248 || event.keyCode == 229 || event.keyCode == 198 || event.keyCode == 32)
        return true;

    return false;

}
function ValidateEmail(event, email) {
   
    if (event.keyCode == 13 || event.keyCode == 9) {
        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email)) {
            return (true)
        }
        alert("You have entered an invalid email address!")
        return (false)
    }
}
function isNumberKeyforcpr(evt) {
    var chk = true;
    var charCode = (evt.which) ? evt.which : event.keyCode;
    // alert(  );
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        chk = false;
    }
    if (chk) {
        if ($('#txtCPR1').val().length == 6) {
            // $('#txtCPR1').val($('#txtCPR1').val()+'-')
            // $('#txtCPR2').val(String.fromCharCode(charCode))
            $('#txtCPR2').focus();

        }
    }
    return chk;  //true;
}
function isNumberKey(evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode;

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    if (charCode == 8) {
        document.getElementById("hdlbl").value = "";
        if (document.getElementById("txtpostcode").value.length > 4) {
            document.getElementById("txtpostcode").value = "";

        }

    }

    return true;
}
function isNumberKeyBestelling(evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode;

    if ((charCode > 48 && charCode <= 57))
        return true;
    else
        return false;
}
function datevalidation(evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode;

    if (charCode == 45)
        return true;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;




    return true;
}
function isAlpha(keyCode) {

    return ((keyCode >= 65 && keyCode <= 90) || (event.keyCode >= 97 && event.keyCode <= 122) || keyCode == 8 || keyCode == 230 || keyCode == 216 || keyCode == 248 || keyCode == 229 || keyCode == 198 || keyCode == 32)
}

function isAlphabetilling(keyCode) {

    return ((keyCode >= 65 && keyCode <= 90) || (event.keyCode >= 97 && event.keyCode <= 122) || keyCode == 8 || keyCode == 230 || keyCode == 216 || keyCode == 221 || keyCode == 222 || keyCode == 192 || keyCode == 32)
}