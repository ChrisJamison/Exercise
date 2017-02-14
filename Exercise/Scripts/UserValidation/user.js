

$(document).ready(function () {
    $(".datepicker").datepicker({
        format: "dd/mm/yyyy",
        autoclose: true
    });

    $(".datepicker").on("change", function () {
        $(this).valid();
    });

    var syncDateOfBirth = function () {
        $(appConstants.dateOfBirthSelector).datepicker("update", new Date(
            moment(
                new Date($(appConstants.yearSelector).val() + '/'
            + $(appConstants.monthSelector).val() + '/'
            + $(appConstants.daySelector).val()),
                appConstants.dateFormatMomentJS)
            )
        );
    };

    $(appConstants.daySelector).on('keyup',
        function () {
            syncDateOfBirth();
        });
    $(appConstants.monthSelector).on('keyup',
        function () {
            syncDateOfBirth();
        });
    $(appConstants.yearSelector).on('keyup',
        function () {
            syncDateOfBirth();
        });
});