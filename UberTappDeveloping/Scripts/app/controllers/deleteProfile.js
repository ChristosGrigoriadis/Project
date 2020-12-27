
$(document).ready(function () {
    $("#deleteBtn").on("click", function () {
        bootbox.alert('You cannot delete your profile! If you wish to unsubscribe' +
            ' from UberTapp please click on "Contact => Report An Issue" and submit a request!');
    });
});