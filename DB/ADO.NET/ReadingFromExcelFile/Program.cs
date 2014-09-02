// 06. Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.

namespace ReadingFromExcelFile
{
    using System;
    using System.Data.OleDb;

    public class Program
    {
        public static void Main()
        {
            OleDbConnection dbConnection = new OleDbConnection(Settings.Default.DBConnectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                OleDbCommand cmdExtractFromExcel = new OleDbCommand("SELECT Name, Score FROM [Sheet1$]", dbConnection);
                var reader = cmdExtractFromExcel.ExecuteReader();
                Console.WriteLine("{0, -15} | {1}", "Name", "Score");
                Console.WriteLine(new string('-', 23));

                while (reader.Read())
                {
                    Console.WriteLine("{0, -15} | {1}", reader[0], reader[1]);
                }
            }
        }
    }
}