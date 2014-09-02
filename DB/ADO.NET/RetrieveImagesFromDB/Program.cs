// 05. Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.
// The images in the database are broken, somehow and don't work properly. If you want you can add custom picture to test the program.

namespace RetrieveImagesFromDB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            SqlConnection dbConnection = new SqlConnection(Settings.Default.DBConnectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                // Comment from here
                SqlCommand cmdRetrieveImages = new SqlCommand("SELECT Picture FROM Categories", dbConnection);

                var images = cmdRetrieveImages.ExecuteReader();

                int counter = 1;
                while (images.Read())
                {
                    var image = images["Picture"];

                    WriteBinaryFile(string.Format("..\\..\\Images\\{0}.png", counter++), (byte[])image);
                }
                // to here if you want to add picture with the following code

                // InsertImageToDB(ReadBinaryFile("C:\\img.jpg"));
            }
        }

        private static byte[] ReadBinaryFile(string fileName)
        {
            FileStream stream = File.OpenRead(fileName);
            using (stream)
            {
                int pos = 0;
                int length = (int)stream.Length;
                byte[] buf = new byte[length];
                while (true)
                {
                    int bytesRead = stream.Read(buf, pos, length - pos);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    pos += bytesRead;
                }
                return buf;
            }
        }

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }

        private static void InsertImageToDB(byte[] image)
        {
            SqlConnection dbConn = new SqlConnection(Settings.Default.DBConnectionString);
            dbConn.Open();

            using (dbConn)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Categories (CategoryName, Picture) " +
                                                "VALUES ('Test', @image)", dbConn);

                SqlParameter paramImage = new SqlParameter("@image", SqlDbType.Image);
                paramImage.Value = image;
                cmd.Parameters.Add(paramImage);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
