var StudentModule = (function () {
    var Student = (function () {
        var markToString = function () {
            return this.subject + ': ' + this.mark;
        };

        function Student(firstName, lastName, age, grade) {
            PersonModule.Person.call(this, firstName, lastName, age);
            this.grade = grade;
            this.marks = [];
        }

        Student.prototype = new PersonModule.Person();

        Student.prototype.addMark = function (subject, mark) {
            this.marks.push({
                subject: subject,
                mark: mark,
                toString: markToString
            });

            return this;
        };

        return Student;
    }());

    var generateStudentsArray = function (count) {
        count = count || 15;

        var marksCount = 10,
		    students = [],
            firstNames = ['Pesho', 'Gosho', 'Ivan', 'Petkan', 'Dimitar', 'Aleksandar', 'Boiko', 'Veselin', 'Pencho', 'Ilian', 'Ivo'],
            lastNames = ['Dimitrov', 'Peshev', 'Ivanov', 'Petrov', 'Genadiev', 'Penchev', 'Gigov', 'Todorov', 'Mishev'];

        for (var s = 0; s < count; s += 1) {
            var firstName = firstNames[getRandomNumber(firstNames.length)];
            var lastName = lastNames[getRandomNumber(lastNames.length)];
            var age = getRandomNumber(18, 30);

            //random grade from 1 to 12
            var grade = getRandomNumber(12);

            var student = new Student(firstName, lastName, age, grade);

            for (var m = 0; m < marksCount; m += 1) {
                var subject = 'Subject #' + (m + 1);

                //random mark from 2 to 6
                var mark = Math.random() * 4 + 2;
                student.addMark(subject, mark);
            }

            students.push(student);
        }

        return students;
    };

    var getRandomNumber = function (min, max) {
        if (!max) {
            max = min;
            min = 0;
        }

        return Math.floor(Math.random() * (max - min) + min);
    };

    return {
        Student: Student,
        generateStudentsArray: generateStudentsArray
    };
})();