using ScanPmrService.DAL;
using ScanPmrService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace ScanPmrService.Service
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "ScanPmrService" nel codice, nel file svc e nel file di configurazione contemporaneamente.
    // NOTA: per avviare il client di prova WCF per testare il servizio, selezionare ScanPmrService.svc o ScanPmrService.svc.cs in Esplora soluzioni e avviare il debug.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ScanPmrService : IScanPmrService
    {
        public string DoWork()
        {
            return "Hello REST WCF Service! :)";
        }

        public string InsertPmr(ARSCAN input)
        {
            var context = new DbContext();
            var strings = context.InsertPMR(input);
            return strings;
        }

        public string ValidationBarCodes(string barCodes)
        {
            try
            {
				var context = new DbContext();
				var strings =  context.ValidationBarCodes(barCodes);
			    return strings;
			}
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


	}
}

