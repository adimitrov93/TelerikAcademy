window.onload = function () {
    var options = [{
        value: 1,
        text: 'One'
    }, {
        value: 2,
        text: 'Two'
    }, {
        value: 3,
        text: 'Three'
    }, {
        value: 4,
        text: 'Four'
    }, {
        value: 5,
        text: 'Five'
    }];

    var selectContainer = document.getElementById('select-container');

    var selectTemplate = Handlebars.compile((document.getElementById('select-template')).innerHTML);

    selectContainer.innerHTML = selectTemplate({
        options: options
    });
};