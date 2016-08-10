function validEmail(email) {
    var emailReg = /^[-a-z0-9~!$%^&*_=+}{\'?]+(\.[-a-z0-9~!$%^&*_=+}{\'?]+)*@([a-z0-9_][-a-z0-9_]*(\.[-a-z0-9_]+)*\.(aero|arpa|biz|com|coop|edu|gov|info|int|mil|museum|name|net|org|pro|travel|mobi|[a-z][a-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?$/i;
    return emailReg.test(email);
}

function showWaitDialog(message) {
    $("#loading-div-background").css({ opacity: 0.8 });
    $("#lblWaitMessage").html(message);
    $("#loading-div-background").show();
}

function hideWaitDialog() {
    $("#lblWaitMessage").val('');
    $("#loading-div-background").hide();
}