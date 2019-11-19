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
        [WebGet(UriTemplate = "/validarUsuario/{usuario}",
                ResponseFormat = WebMessageFormat.Json, 
                BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool ValidarUsuario(string usuario);
        [OperationContract]
        [WebInvoke(UriTemplate = "/validarContrasenia/{contrasenia}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool ValidarContrasenia(string contrasenia);
        [OperationContract]
        [WebInvoke(UriTemplate = "/crearCuenta",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, 
            Method = "POST", 
            BodyStyle = WebMessageBodyStyle.Wrapped)]
       // bool CrearCuenta(string usuario, string contrasenia);
        bool CrearCuenta(Persona persona);
        //Perfil
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool CrearPerfil(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "UPDATE",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool ModificarPerfil(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool EliminarPerfil(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil/{user}/{pass}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        Usuario ConsultarPerfilS(string user, string pass);
        //Notificaciones
        [OperationContract]
        [WebInvoke(UriTemplate = "/notificacion",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        Notificaciones ConsultarNotificaciones();
        //Atlas
        [OperationContract]
        [WebInvoke(UriTemplate = "/planteles",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<PlantelesES> ObtenerPlanteles();
        [OperationContract]
        [WebInvoke(UriTemplate = "/carreras",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<CarrerasES> ObtenerCarreras();
        [OperationContract]
        [WebInvoke(UriTemplate = "/gruposeguridad",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   Method = "GET",
                   BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<string> ObtenerGrupos();
        //Direccion
        [WebInvoke(UriTemplate = "/colonia",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   Method = "GET",
                   BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Colonias> ObtenerColonias();
        [WebInvoke(UriTemplate = "/municipios",
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  Method = "GET",
                  BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Municipios> ObtenerMunicipios();
        [WebInvoke(UriTemplate = "/estados",
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  Method = "GET",
                  BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Estados> ObtenerEstados();
        [WebInvoke(UriTemplate = "/paises",
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  Method = "GET",
                  BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Paises> ObtenerPaises();
        //Historial

        // TODO: agregue aquí sus operaciones de servicio
    }
}
