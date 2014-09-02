function createCalendar(selector, events) {
    var container = document.querySelector(selector);
    var documentFragment = document.createDocumentFragment();
    var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

    container.style.width = '950px';

    generateBoxes();
    insertEvents();

    container.addEventListener('click', function (e) {
        var selectedBox = document.querySelector('#' + e.target.getAttribute('id'));
        var selectedBoxHeader = selectedBox.querySelector('.header');

        if (selectedBoxHeader.style.backgroundColor === 'white') {
            selectedBoxHeader.style.backgroundColor = 'lightgray';
        }
        else {
            selectedBoxHeader.style.backgroundColor = 'white';
        }
    }, false);

    container.appendChild(documentFragment);

    function generateBoxes() {
        var header = document.createElement('div');
        header.className = 'header';
        header.style.textAlign = 'center';
        header.style.borderBottom = '1px solid black';
        header.style.backgroundColor = 'lightgray';
        header.style.fontWeight = 'bold';

        var box = document.createElement('div');
        box.className = 'date-box';
        box.appendChild(header);
        box.style.width = '130px';
        box.style.height = '130px';
        box.style.border = '1px solid black';
        box.style.float = 'left';

        for (var i = 0; i < 30; i++) {
            box.id = 'box-' + (i + 1);
            box.querySelector('.header').innerHTML = (days[i % 7]) + ' ' + (i + 1) + ' ' + 'June 2014';
            documentFragment.appendChild(box.cloneNode(true));
        }
    }

    function insertEvents() {
        var boxes = documentFragment.childNodes;

        for (var i = 0, length = events.length; i < length; i++) {
            boxes[parseInt(events[i].date) - 1].innerHTML += '<strong>' + events[i].hour + ' ' + events[i].title + '</strong>';
        }
    }
}