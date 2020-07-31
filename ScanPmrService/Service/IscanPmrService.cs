using ScanPmrService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace ScanPmrService.Service
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IScanPmrService" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IScanPmrService
    {
        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "DoWork")]
        //string DoWork();
    
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "ValidationBarCodes")]
        string ValidationBarCodes(string barCodes);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "InsertPmr")]
        string InsertPmr(ARSCAN input);

    }
}
