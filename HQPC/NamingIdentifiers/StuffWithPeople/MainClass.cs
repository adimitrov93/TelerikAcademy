public class MainClass
{
    public enum Sex
    {
        Male,
        Female
    }

    public class Person
    {
        public Sex Sex { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    public void ProducePerson(int age)
    {
        Person newPerson = new Person();
        newPerson.Age = age;

        if (age % 2 == 0)
        {
            newPerson.Name = "The batka";
            newPerson.Sex = Sex.Male;
        }
        else
        {
            newPerson.Name = "The mace";
            newPerson.Sex = Sex.Female;
        }
    }
}