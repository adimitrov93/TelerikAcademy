(function ($) {
    $(function () {
        var hideAllContainers = function () {
            $('.container').hide();
        };

        var showContainer = function (selector) {
            $(selector).show();
        };

        var unHighlightAllLabels = function () {
            $('.tab-label').removeClass('selected');
        };

        var highlightLabel = function (selector) {
            $(selector).addClass('selected');
        };

        var refreshStudents = function () {
            $.get('http://localhost:3000/students', function (data) {
                var source = $("#student-template").html();
                var template = Handlebars.compile(source);
                var html = template(data);

                $('.student-item').remove();
                $('#students-container').append(html);
                $('#id-input').attr('max', data.students[data.students.length - 1].id);
            });
        };

        var emptyAllErrors = function () {
            $('.error-field').text('');
        };

        $('.tab-label').on('click', function () {
            hideAllContainers();
            unHighlightAllLabels();

            showContainer('.' + this.id);
            highlightLabel('#' + this.id);
        });

        $('#add-student-btn').on('click', function () {
            emptyAllErrors();

            var $nameInput = $('#name-input');
            var $gradeInput = $('#grade-input');
            var grade = $gradeInput.val();

            if ($nameInput.val() !== '') {
                if (2 <= grade && grade <= 6) {
                    $.post('http://localhost:3000/students', {
                        name: $nameInput.val(),
                        grade: grade
                    }, function () {
                        refreshStudents();
                        $nameInput.val('');
                        $gradeInput.val('');
                    });
                }
                else {
                    $('#grade-input-error').text('Grade must be between 2 and 6.');
                }
            }
            else {
                $('#name-input-error').text('Name cannot be empty.');
            }
        });

        $('#remove-student-btn').on('click', function () {
            emptyAllErrors();

            var $idInput = $('#id-input');
            var id = $idInput.val();
            var ids = $('.id-col');
            var isValidId = false;
            debugger;

            for (var i = 0, len = ids.length; i < len; i++) {
                if ($(ids[i]).text() === id) {
                    isValidId = true;
                    break;
                }
            }

            if (isValidId) {
                // This is some sort of hack, I think, but it's the only way of doing DELETE without changing the server code
                $.ajax({
                    url: 'http://localhost:3000/students/' + id,
                    type: 'POST',
                    data: { _method: 'delete' }
                }).done(function () {
                    refreshStudents();
                    $idInput.val('');
                });
            }
            else {
                $('#id-input-error').text('There is no such student.');
            }
        });
        hideAllContainers();
        refreshStudents();
        $('#add-student').click();
        alert('You must start the server from server/app.js before using the app.');
    });
})(jQuery);