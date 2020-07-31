using ConsoleAppTEST.ServiceReference1;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleAppTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            var photo = GetImages(@"C:\Users\umber\Desktop\Test\Insert");
            //using (var proxy = new ServiceReference2.ScanPmrServiceClient())
            //{
            //    string validationCodes = $"78620343004,12312421412,1321312314";

            //    Console.WriteLine("Begins test");
            //    //ServicePointManager.ServerCertificateValidationCallback += customXertificateValidation;
            //    //Console.WriteLine(proxy.ValidationBarCodes(validationCodes));
            //    //Console.WriteLine("Ends test");

            //    //var photo = GetPhoto(@"C:\Users\umber\Pictures\Annotazione 2020-04-22 141247.png");
            //    Console.WriteLine("Begins test");
            //    ServicePointManager.ServerCertificateValidationCallback += customXertificateValidation;


            //    Console.WriteLine("Ends test");
            //    Console.ReadLine();
            //}



        }
        private static bool customXertificateValidation(object sender, X509Certificate cert,
        X509Chain chain, System.Net.Security.SslPolicyErrors error)
        {
            var certificate = (X509Certificate2)cert;
            return true;
        }

        public static void AddEmployee(
          string lastName,
          string firstName,
          string title,
          DateTime hireDate,
          int reportsTo,
          string photoFilePath,
          string connectionString)
        {
            byte[] photo = GetImages(photoFilePath);

            //using (SqlConnection connection = new SqlConnection(
            //  connectionString))

            //    SqlCommand command = new SqlCommand(
            //      "INSERT INTO Employees (LastName, FirstName, " +
            //      "Title, HireDate, ReportsTo, Photo) " +
            //      "Values(@LastName, @FirstName, @Title, " +
            //      "@HireDate, @ReportsTo, @Photo)", connection);

            //command.Parameters.Add("@LastName",
            //   SqlDbType.NVarChar, 20).Value = lastName;
            //command.Parameters.Add("@FirstName",
            //    SqlDbType.NVarChar, 10).Value = firstName;
            //command.Parameters.Add("@Title",
            //    SqlDbType.NVarChar, 30).Value = title;
            //command.Parameters.Add("@HireDate",
            //     SqlDbType.DateTime).Value = hireDate;
            //command.Parameters.Add("@ReportsTo",
            //    SqlDbType.Int).Value = reportsTo;

            //command.Parameters.Add("@Photo",
            //    SqlDbType.Image, photo.Length).Value = photo;

            //connection.Open();
            //command.ExecuteNonQuery();
        }
    

    public static byte[] GetImages(string filePath)
    {
       byte[] photo = null;
            try
            {
                
                Console.WriteLine("Ends test");
                string[] fileEntries = Directory.GetFiles(filePath);
                foreach (string fileName in fileEntries)
                {
                    FileStream stream = new FileStream(
                    fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(stream);

                    photo = reader.ReadBytes((int)stream.Length);

                    using (var proxy = new ServiceReference1.ScanPmrServiceClient())
                    {

                        Console.WriteLine("Begins test");
                        ServicePointManager.ServerCertificateValidationCallback += customXertificateValidation;
                        Console.WriteLine(proxy.InsertPmr(new ARSCAN()
                        {
                            IMMAGINE_FRONTE = photo,
                            IMMAGINE_RETRO = photo,
                            CODE_BAR = "12345678910",
                            CODE_OPE_SCAN = "umber"
                        }
                        ));

                        Console.WriteLine("Ends test");


                        Console.ReadLine();
                    }
                    reader.Close();
                    stream.Close();
                }      
              

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        return photo;
    }
}
}
