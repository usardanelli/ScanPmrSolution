using ScanPmrService.DAL;
using ScanPmrService.Models;
using System;
using System.ServiceModel.Activation;

namespace ScanPmrService.Service
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "ScanPmrService" nel codice, nel file svc e nel file di configurazione contemporaneamente.
    // NOTA: per avviare il client di prova WCF per testare il servizio, selezionare ScanPmrService.svc o ScanPmrService.svc.cs in Esplora soluzioni e avviare il debug.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ScanPmrService : IScanPmrService
    {
       
        public string InsertPmr(ARSCAN input)
        {

            try
            {
                input.Validation();
                var context = new DbContext();
                var strings = context.InsertPMR(input);
                return strings;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
                return ex.Message;
            }
        }


	}
}

