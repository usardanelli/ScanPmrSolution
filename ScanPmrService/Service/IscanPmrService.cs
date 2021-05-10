using ScanPmrService.Models;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace ScanPmrService.Service
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IScanPmrService" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IScanPmrService
    {
     
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "ValidationBarCodes")]
        string ValidationBarCodes(string barCodes);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "InsertPmr")]
        string InsertPmr(ARSCAN input);

    }
}
