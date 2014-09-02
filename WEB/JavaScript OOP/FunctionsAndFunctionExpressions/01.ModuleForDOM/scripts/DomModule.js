var domModule = (function () {
    var appendChild = function (elementToAppend, containerSelector) {
        var container = document.querySelector(containerSelector);
        container.appendChild(elementToAppend);
    };

    var removeChild = function (elementToRemoveSelector, parentSelector) {
        var parent = document.querySelector(parentSelector);
        var child = parent.querySelector(elementToRemoveSelector);

        parent.removeChild(child);
    };

    var addHandler = function (selector, event, handler) {
        var element = document.querySelector(selector);

        if (element.addEventListener) {
            element.addEventListener(event, handler, false);
        }
        else if (element.attachEvent) {
            element.attachEvent(event, handler);
        }
        else {
            var event = 'on' + event;
            element[event] = handler;
        }
    };

    var appendToBuffer = (function () {
        var buffer = [];

        var appendToBuffer = function (containerSelector, elementToAppend) {
            var currentElement = {
                containerSelector: containerSelector,
                elementToAppend: elementToAppend
            };

            buffer.push(currentElement);

            if (buffer.length >= 2) {
                for (var i = 0; i < buffer.length; i++) {
                    var current = buffer[i];
                    document.querySelector(current.containerSelector).appendChild(current.elementToAppend);
                }

                buffer = [];
            }
        };

        return appendToBuffer;
    })();

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    };
})();