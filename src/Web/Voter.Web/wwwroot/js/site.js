(function () {
    angular.module('intuitHomeApp')
        .constant('settings', {

        });
});



$(function () {
    $('ul li').click(function () {
        $(this).addClass('vote-done good');
        $(this).find('.progress').addClass('pro-90');
    });

});