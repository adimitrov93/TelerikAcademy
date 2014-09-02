namespace WritingToExcelFile
{
    using System;
    using System.Data.OleDb;

    public class Program
    {
        public static void Main()
        {
            AppendRow("Ninja", 10000);
        }

        public static void AppendRow(string name, int score)
        {
            OleDbConnection dbConnection = new OleDbConnection(Settings.Default.DBConnectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                OleDbCommand cmdExtractFromExcel = new OleDbCommand("INSERT INTO [Sheet1$](Name, Score) VALUES (@name, @score)", dbConnection);
                cmdExtractFromExcel.Parameters.AddWithValue("@name", name);
                cmdExtractFromExcel.Parameters.AddWithValue("@score", score);

                cmdExtractFromExcel.ExecuteNonQuery();
            }
        }
    }
}
