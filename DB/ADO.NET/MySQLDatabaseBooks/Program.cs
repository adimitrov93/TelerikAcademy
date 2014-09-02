// Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool . Create a MySQL database to store Books (title, author, publish date and ISBN). Write methods for listing all books, finding a book by name and adding a book.

namespace MySQLDatabaseBooks
{
    using System;
    using System.Text;

    using MySql.Data.MySqlClient;

    public class Program
    {
        public static void Main()
        {
            AddBook("Some title", "Some author", "1234567891234");
            AddBook("Another title", "Another author", "9876543219876");
            Console.WriteLine("Some title:");
            Console.WriteLine(GetBook("Some title"));
            Console.WriteLine("All books:");
            Console.WriteLine(GetAllBooks());
        }

        public static string GetAllBooks()
        {
            var db = OpenConnection();
            var result = new StringBuilder();

            using (db)
            {
                var cmdFindBook = new MySqlCommand("SELECT * FROM Books", db);
                var reader = cmdFindBook.ExecuteReader();

                using(reader)
                {
                    while (reader.Read())
                    {
                        result.AppendFormat("Title: {0}; Author: {1}, ISBN: {2}{3}", reader["Title"], reader["Author"], reader["ISBN"], Environment.NewLine);
                    }
                }
            }

            return result.ToString();
        }

        public static string GetBook(string title)
        {
            var db = OpenConnection();

            using(db)
            {
                var cmdFindBook = new MySqlCommand("SELECT * FROM Books WHERE Title = @title", db);
                cmdFindBook.Parameters.AddWithValue("@title", title);
                var reader = cmdFindBook.ExecuteReader();

                if (reader.Read())
                {
                    return string.Format("Title: {0}; Author: {1}, ISBN: {2}", reader["Title"], reader["Author"], reader["ISBN"]);
                }
                else
                {
                    throw new ArgumentException("Book not find.", "title");
                }
            }
        }

        public static void AddBook(string title, string author, string isbn)
        {
            var db = OpenConnection();

            using(db)
            {
                var cmdAddBook = new MySqlCommand("INSERT INTO Books(Title, Author, ISBN) VALUES (@title, @author, @isbn)", db);
                cmdAddBook.Parameters.AddWithValue("@title", title);
                cmdAddBook.Parameters.AddWithValue("@author", author);
                cmdAddBook.Parameters.AddWithValue("@isbn", isbn);

                cmdAddBook.ExecuteNonQuery();
            }
        }

        private static MySqlConnection OpenConnection()
        {
            MySqlConnection db = new MySqlConnection(Settings.Default.ConnectionString);
            db.Open();

            return db;
        }
    }
}