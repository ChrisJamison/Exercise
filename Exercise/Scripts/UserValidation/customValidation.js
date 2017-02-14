
(function ($) {
    var addCustomError = function () {
        $(appConstants.daySelector).addClass(appConstants.customValidationErrorClass);
        $(appConstants.monthSelector).addClass(appConstants.customValidationErrorClass);
        $(appConstants.yearSelector).addClass(appConstants.customValidationErrorClass);
    };

    var removeCustomError = function () {
        $(appConstants.daySelector).removeClass(appConstants.customValidationErrorClass);
        $(appConstants.monthSelector).removeClass(appConstants.customValidationErrorClass);
        $(appConstants.yearSelector).removeClass(appConstants.customValidationErrorClass);
    };

    $.validator.addMethod('minimumage', function (value, element, params) {
        if (!this.optional(element)) {
            var targetAge = parseInt(params.targetage);
            var ms = moment().startOf('day').diff(moment($(appConstants.dateOfBirthSelector).val(), appConstants.dateFormatMomentJS));
            var duration = moment.duration(ms).asYears();
            if (duration <= targetAge) {
                addCustomError();
                return false;
            }     
        }
        removeCustomError();
        return true;
    });
    $.validator.unobtrusive.adapters.add(
        'minimumage',
        ['targetage'],
        function (options) {
            options.messages['minimumage'] = options.message;
            options.rules['minimumage'] =
            {
                targetage: options.params.targetage
            };
        });
    $.validator.methods.date = function (value, element) {
        return this.optional(element) || moment(value, appConstants.dateFormatMomentJS).isValid();
    };

    $.validator.setDefaults({ ignore: '' });



}(jQuery));

