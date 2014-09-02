/// <reference path="../../Scripts/jquery-2.1.1.js" />

$(function () {
    var students = [{
        fname: 'Peter',
        lname: 'Ivanov',
        grade: 3
    }, {
        fname: 'Milena',
        lname: 'Grigorova',
        grade: 6
    }, {
        fname: 'Gergana',
        lname: 'Borisova',
        grade: 12
    }, {
        fname: 'Boyko',
        lname: 'Petrov',
        grade: 7
    }];

    var $table = generateTable(students);

    $('#table-container').append($table);
});

function generateTable(data) {
    var $table = $('<table>');
    var $tr = $('<tr>');
    var $td = $('<td>');
    var $th = $('<th>');

    $table.css('border-collapse', 'collapse');
    $td.css('border', '1px solid black');
    $th.css('border', '1px solid black');

    $th.html('First name');
    $tr.append($th.clone(true));
    $th.html('Last name');
    $tr.append($th.clone(true));
    $th.html('Grade');
    $tr.append($th.clone(true));

    $table.append($tr.clone(true));

    for (var i = 0, length = data.length; i < length; i++) {
        $tr.html('');

        $td.html(data[i].fname);
        $tr.append($td.clone(true));
        $td.html(data[i].lname);
        $tr.append($td.clone(true));
        $td.html(data[i].grade);
        $tr.append($td.clone(true));

        $table.append($tr.clone(true));
    }

    return $table;
}