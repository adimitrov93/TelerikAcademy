namespace TestSchool
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using School;

    [TestClass]
    public class TestStudent
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatingStudentWithEmptyNameShoudThrowAnException()
        {
            Student student = new Student("", 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreatingStudentWithUniqueNumberLessThan10000ShoudThrowAnException()
        {
            Student student = new Student("Test student", 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreatingStudentWithUniqueNumberBiggerThan99999ShoudThrowAnException()
        {
            Student student = new Student("Test student", 100000);
        }

        [TestMethod]
        public void AfterCreatingStudentWithGivenNameThatStudentsNameShoudBeCorrect()
        {
            Student student = new Student("Test student", 10000);

            Assert.AreEqual("Test student", student.Name, "Student's name is not correct.");
        }

        [TestMethod]
        public void AfterCreatingStudentWithGivenUniqueNumberThatStudentsUniqueNumberShoudBeCorrect()
        {
            Student student = new Student("Test student", 10000);

            Assert.AreEqual(10000, student.UniqueNumber, "Student's unique number is not correct.");
        }
    }
}
