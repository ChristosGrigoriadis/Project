
$(document).ready(function () {

    let table = $("#users").DataTable({});

    $("#users").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to remove this user from UberTap?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/applicationusers/" + button.attr("data-user-id"),
                    method: "POST",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                })
                    .done(function () {
                        bootbox.alert("User successfully removed!");
                    })
                    .fail(function () {
                        bootbox.alert("Ooops something went wrong!");
                    });
            }
        });
    });
});