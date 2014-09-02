(function () {
	var students = StudentModule.generateStudentsArray(),
		filteredStudents,
		sortedStudents;

	console.log(students);

	// Task 01. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Print the students in descending order by full name.
	filteredStudents = _.filter(students, function (student) {
		return student.firstName < student.lastName;
	});
	sortedStudents = _.sortBy(filteredStudents, function (student) {
		return student.firstName + ' ' + student.lastName;
	}).reverse();;

	console.log(sortedStudents);

	// Task 02. Write function that finds the first name and last name of all students with age between 18 and 24. Use Underscore.js
	filteredStudents = _.filter(students, function (student) {
		return 18 <= student.age && student.age <= 24;
	});

	console.log(filteredStudents);

	// Task 03. Write a function that by a given array of students finds the student with highest marks
	filteredStudents = _.max(students, function (student) {
		var marksSum = 0;
		_.map(student.marks, function (mark) {
			marksSum += mark.mark;
		});

		return marksSum / student.marks.length;
	});

	console.log(filteredStudents);
})();