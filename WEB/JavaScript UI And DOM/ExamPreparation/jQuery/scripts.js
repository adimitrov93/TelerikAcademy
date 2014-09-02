/// <reference path="jquery.min.js" />
$.fn.tabs = function () {
    var $this = $(this);
    var $container = $this;

    $this.addClass('tabs-container');

    $this.find('.tab-item-title').on('click', function () {
        var $this = $(this);

        $container.find('.tab-item-content').hide();
        $this.next().show();

        $container.find('.tab-item').removeClass('current');
        $this.parent().addClass('current');
    });

    $this.find('.tab-item-title').first().click();
};