namespace TestSchool
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using School;

    [TestClass]
    public class TestCourse
    {
        [TestMethod]
        public void AfterAddingFirstStudentToCourseTheStudentsCountMustBe1()
        {
            Student student = new Student("Test student", 10000);
            Course course = new Course();

            course.Join(student);

            Assert.AreEqual(1, course.StudentsCount, "Students count is incorrect after adding first student.");
        }

        [TestMethod]
        public void AfterAdding20StudentsToCourseTheStudentsCountMustBe20()
        {
            Course course = new Course();

            for (int i = 0; i < 20; i++)
            {
                string currentStudentsName = "Test student #" + (i + 1);
                int currentStudentsUniqueNumber = 10000 + i;
                Student student = new Student(currentStudentsName, currentStudentsUniqueNumber);

                course.Join(student);
            }

            Assert.AreEqual(20, course.StudentsCount, "Students count is incorrect after adding 20 students.");
        }

        [TestMethod]
        public void AfterStudentsLeavingStudentsCountShoudBe1Less()
        {
            Course course = new Course();
            Student student = null;

            for (int i = 0; i < 5; i++)
            {
                string currentStudentsName = "Test student #" + (i + 1);
                int currentStudentsUniqueNumber = 10000 + i;
                student = new Student(currentStudentsName, currentStudentsUniqueNumber);

                course.Join(student);
            }

            int currentStudentsCount = course.StudentsCount;
            int studentsCountAfter1LivingStudent = currentStudentsCount - 1;

            course.Leave(student);

            Assert.AreEqual(studentsCountAfter1LivingStudent, course.StudentsCount, "Students count is incorrect after removing 1 student.");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void AfterAdding31StudentsToCourseAnExceptionShoudBeThrown()
        {
            Course course = new Course();

            for (int i = 0; i < 31; i++)
            {
                string currentStudentsName = "Test student #" + (i + 1);
                int currentStudentsUniqueNumber = 10000 + i;
                Student student = new Student(currentStudentsName, currentStudentsUniqueNumber);

                course.Join(student);
            }
        }
    }
}
