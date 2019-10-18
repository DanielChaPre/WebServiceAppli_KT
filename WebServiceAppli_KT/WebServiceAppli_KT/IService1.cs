using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool IniciarSesion(string user, string pass);
        [OperationContract]
        NotificacionClass consultar();
        [OperationContract]
        List<PlantelesESClass> obtenerPlanteles();
        [OperationContract]
        List<CarrerasESClass> obtenerCarreras();
        // TODO: agregue aquí sus operaciones de servicio
    }
}
