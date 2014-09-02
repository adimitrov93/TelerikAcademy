namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using System.Collections.Generic;

    public class StudentSystemConsoleClient
    {
        public static void Main()
        {
            var data = new StudentsSystemData();

            var student = new Student
                {
                    FirstName = "Ivan",
                    LastName = "Geshov",
                    FacultyNumber = "1234567890",
                    Contacts = new ContactInfo
                    {
                        Email = "i.geshov@gmail.com",
                        PhoneNumber = "0888123456"
                    },
                    Courses = new HashSet<Course>
                    {
                        
                    }
                };
            data.Students.Add(student);

            var dbCourse = new Course
                {
                    Name = "DB",
                    Description = "WTF"
                };
            data.Courses.Add(dbCourse);

            var dsaCourse = new Course
                {
                    Name = "DSA",
                    Description = "OMFG"
                };
            data.Courses.Add(dsaCourse);

            student.Courses.Add(dbCourse);

            student.Courses.Add(dsaCourse);

            data.SaveChanges();
        }
    }
}
