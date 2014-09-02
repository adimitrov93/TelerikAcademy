(function () {
    var sublists = document.querySelectorAll('#list ul');

    for (var i = 0; i < sublists.length; i++) {
        sublists[i].style.display = 'none';
    }

    document.querySelector('#list').addEventListener('click', function (e) {
        if (e.target instanceof HTMLSpanElement) {
            var listItem = e.target.parentNode;
            var sublist = listItem.querySelector('ul');

            if (sublist) {
                if (sublist.style.display === '') {
                    sublist.style.display = 'none';

                    // Closing all inner expanded lists.
                    var sublists = listItem.querySelectorAll('ul');
                    for (var i = 0; i < sublists.length; i++) {
                        sublists[i].style.display = 'none';
                    }
                }
                else {
                    sublist.style.display = '';
                }
            }
        }
    });
})();