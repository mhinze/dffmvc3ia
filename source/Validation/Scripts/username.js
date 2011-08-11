(function ($) {
   
    $.validator.addMethod('username', function (value) {
        return value.toLowerCase() !== value.replace('[^a-zA-Z]', '').toLowerCase();
    });
    
    $.validator.unobtrusive.adapters.addBool('username');
   
} (jQuery));