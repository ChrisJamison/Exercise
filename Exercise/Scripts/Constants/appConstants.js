var appConstants = (function () {

    //Date format
    var dateFormatMomentJs = "DD/MM/YYYY";

    //Custom class
    var customValidationErrorClass = "custom-validation-error";

    //Selector
    var dateOfBirthSelector = "#DateOfBirth";
    var dateOfBirthDaySelector = "#DateOfBirth_Day";
    var dateOfBirthMonthSelector = "#DateOfBirth_Month";
    var dateOfBirthYearSelector = "#DateOfBirth_Year";

    return {
        dateFormatMomentJS: dateFormatMomentJs,
        customValidationErrorClass: customValidationErrorClass,
        dateOfBirthSelector: dateOfBirthSelector,
        daySelector: dateOfBirthDaySelector,
        monthSelector: dateOfBirthMonthSelector,
        yearSelector: dateOfBirthYearSelector
    };
}(appConstants));