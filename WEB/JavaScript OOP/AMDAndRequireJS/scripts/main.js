define(['data', 'combobox'], function (cars, combobox) {
    var run = function () {
        var myCombobox = combobox.getComboBoxController(cars);
        myCombobox.renderTemplate('#combobox-template');
        myCombobox.createCombo('#combobox-root');
    }

    return {
        run: run
    }
})