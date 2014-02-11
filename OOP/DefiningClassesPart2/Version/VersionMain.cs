namespace Version
{
    using System;

    [Version("2.12")]
    public class VersionMain
    {
        static void Main()
        {
            Type type = typeof(VersionMain);

            var attributes = type.GetCustomAttributes(typeof(VersionAttribute), false);

            Console.WriteLine("Class' version: {0}", (attributes[0] as VersionAttribute).Version);
        }
    }
}
