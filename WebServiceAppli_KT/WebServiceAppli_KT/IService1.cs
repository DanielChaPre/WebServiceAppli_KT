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
        //Cuenta
        [OperationContract]
        bool IniciarSesion(string user, string pass);
        [OperationContract]
        bool CrearCuenta(UsuarioClass usuario);
        //Perfil
        [OperationContract]
        bool CrearPerfil(UsuarioClass usuario);
        [OperationContract]
        bool ModificarPerfil(UsuarioClass usuario);
        [OperationContract]
        bool EliminarPerfil(int cveUsuario, int cvePersona);
        [OperationContract]
        UsuarioClass ConsultarPerfil(string user, string pass);
        //Notificaciones
        [OperationContract]
        NotificacionClass consultar();
        //Atlas
        [OperationContract]
        List<PlantelesESClass> obtenerPlanteles();
        [OperationContract]
        List<CarrerasESClass> obtenerCarreras();
        //Historial

        // TODO: agregue aquí sus operaciones de servicio
    }
}
