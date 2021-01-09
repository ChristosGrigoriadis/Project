let BeersController = function (favouriteService) {
    let button;

    let init = function (container) {
        $(container).on("click", ".js - toggle - attendance", toggleAttendance);
        //$(".js-toggle-attendance").click(toggleAttendance);
    };

    let toggleAttendance = function (e) {
        button = $(e.target);
        let gigId = button.atr("data-gig-id");

        if (button.hasClass("btn-default"))
            favouriteService.createFavourite(gigId, done, fail);
        else
            favouriteService.deleteFavourite(gigId, done, fail);
    };

    let done = function () {
        let text = button.text() === "Going" ? "Going?" : "Going";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    let fail = function () {
        alert("Something failed");
    };

    return {
        init: init
    }

}(AttendanceService); // IIFE