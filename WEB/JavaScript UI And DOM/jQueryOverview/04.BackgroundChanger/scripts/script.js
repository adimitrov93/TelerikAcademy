/// <reference path="../../Scripts/jquery-2.1.1.js" />

$(function () {
    $('#color-picker').on('change', function () {
        $(document.body).css('background-color', this.value);
    });
});