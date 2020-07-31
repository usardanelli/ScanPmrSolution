using ScanPmrService.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ScanPmrService.DAL
{
    public class DbContext
    {
        private readonly string connectionStringPsdb;
        private readonly string connectionStringArLocal;
        private readonly string validazioneStoredProcs; 
        private readonly string inserimentoPmrStoredProcs;
        public DbContext()
        {
            connectionStringPsdb = ConfigurationManager.ConnectionStrings["SQL_PSDB"].ConnectionString;
            connectionStringArLocal = ConfigurationManager.ConnectionStrings["SQL_AR_LOCAL"].ConnectionString;

            validazioneStoredProcs = "RSP_SCANSIONE_PMR_VALIDAZIONE_BAR_CODES";

            inserimentoPmrStoredProcs = "RSP_SCANSIONE_PMR_INSERISCI_PLICO";
        }
        

        public string ValidationBarCodes(string barCodes)
        {
            string result = null;
            using (var conn = new SqlConnection(connectionStringPsdb))
            {
                // Create ADO.NET objects.
                SqlCommand cmd = new SqlCommand(validazioneStoredProcs, conn);

                // Configure command and add input parameters.

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param;

                param = cmd.Parameters.Add("@LIST_BAR_CODES", SqlDbType.VarChar, 8000);

                param.Value = barCodes;

                // Add the output parameter.

                param = cmd.Parameters.Add("@RET_CODE_BAR", SqlDbType.VarChar, 8000);

                param.Direction = ParameterDirection.Output;

                // Execute the command.

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
                result = (string) param.Value;
                Console.WriteLine("" + param.Value);

            }          

            return result;
        }

        public string InsertPMR(ARSCAN input)
        {
            string result = null;

            using (var conn = new SqlConnection(connectionStringArLocal))
            {
                // Create ADO.NET objects.
                SqlCommand cmd = new SqlCommand(inserimentoPmrStoredProcs, conn);

                // Configure command and add input parameters.

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param;

                param = cmd.Parameters.Add("@IMMAGINE_FRONTE", SqlDbType.Image);

                param.Value = input.IMMAGINE_FRONTE;

                param = cmd.Parameters.Add("@IMMAGINE_RETRO", SqlDbType.Image);

                param.Value = input.IMMAGINE_RETRO;

                param = cmd.Parameters.Add("@CODE_BAR", SqlDbType.Char, 11);

                param.Value = input.CODE_BAR;

                param = cmd.Parameters.Add("@CODE_OPE_SCAN", SqlDbType.Char, 5);

                param.Value = input.CODE_OPE_SCAN;

                           
                // Execute the command.

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
                result = (string)param.Value;
                Console.WriteLine("" + param.Value);

            }

            return result;
        }
    }
}