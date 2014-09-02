window.onload = function () {
    var backgroundColorPicker = document.getElementById('background-color-picker');
    var fontColorPicker = document.getElementById('font-color-picker');
    var input = document.getElementById('input');

    backgroundColorPicker.addEventListener('change', function () {
        input.style.backgroundColor = backgroundColorPicker.value;
    });

    fontColorPicker.addEventListener('change', function () {

        input.style.color = fontColorPicker.value;
    });
};