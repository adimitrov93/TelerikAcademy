namespace StudentProgram
{
    using System;
    using System.Text;

    public class Student : ICloneable, IComparable<Student>
    {
        // Fields
        private string firstName;
        private string middleName;
        private string lastName;

        private string ssn;

        // Constructors
        public Student(string firstName, string middleName, string lastName, string ssn,
            string permanentAddress, string mobilePhone, string email, string course,
            University university, Faculty faculty, Specialty specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }

        // Properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("First name cannot be less than 2 characters");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Middle name cannot be less than 2 characters");
                }

                this.middleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Last name cannot be less than 2 characters");
                }

                this.lastName = value;
            }
        }

        public string SSN
        {
            get
            {
                return this.ssn;
            }
            private set
            {
                if (value.Length != 9)
                {
                    throw new ArgumentException("SSN must be 9 digits long");
                }

                foreach (var character in value)
                {
                    if (!char.IsDigit(character))
                    {
                        throw new ArgumentException("SSN must contain only digits");
                    }
                }

                this.ssn = value;
            }
        }

        public string PermanentAddress { get; private set; }

        public string MobilePhone { get; private set; }
        
        public string Email { get; private set; }

        public string Course { get; private set; }

        public University University { get; private set; }
        
        public Faculty Faculty { get; private set; }
        
        public Specialty Specialty { get; private set; }

        // Methods
        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            if (student == null)
            {
                throw new ArgumentException("The passed object is not a student");
            }

            if (this.SSN == student.SSN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName));
            result.AppendLine(string.Format("SSN: {0}", this.SSN));
            result.AppendLine(string.Format("Permanent address: {0}", this.PermanentAddress));
            result.AppendLine(string.Format("Mobile phone: {0}", this.MobilePhone));
            result.AppendLine(string.Format("Email: {0}", this.Email));
            result.AppendLine(string.Format("Course: {0}", this.Course));
            result.AppendLine(string.Format("University: {0}", this.University));
            result.AppendLine(string.Format("Faculty: {0}", this.Faculty));
            result.AppendLine(string.Format("Specialty: {0}", this.Specialty));

            return result.ToString();
        }

        public override int GetHashCode()
        {
            int result = this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.SSN.GetHashCode() ^
                this.PermanentAddress.GetHashCode() ^ this.MobilePhone.GetHashCode() ^ this.Email.GetHashCode() ^ this.Course.GetHashCode() ^
                this.University.GetHashCode() ^ this.Faculty.GetHashCode() ^ this.Specialty.GetHashCode();

            return result;
        }

        public object Clone()
        {
            return this.MemberwiseClone();      // This works perfectly for this case, because we don't have refence type fields, only value-type and MemberwiseClone will copy them correctly
        }

        public int CompareTo(Student student)
        {
            if (this.FirstName != student.FirstName)
            {
                return (this.FirstName.CompareTo(student.FirstName));
            }
            else if (this.MiddleName != student.MiddleName)
            {
                return (this.MiddleName.CompareTo(student.MiddleName));
            }
            else if (this.LastName != student.LastName)
            {
                return (this.lastName.CompareTo(student.LastName));
            }
            else
            {
                int firstSSN = int.Parse(this.SSN);
                int secondSSN = int.Parse(student.SSN);

                if (firstSSN - secondSSN < 0)
                {
                    return -1;
                }
                else if (firstSSN - secondSSN > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        // Operators
        public static bool operator ==(Student first, Student second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !first.Equals(second);
        }
    }
}
