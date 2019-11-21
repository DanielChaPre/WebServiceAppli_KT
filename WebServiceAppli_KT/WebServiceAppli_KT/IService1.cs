﻿using System;
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
        #region Persona
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
        Persona ConsultarPerfilS(string user, string pass);
        #endregion
        #region Empleado
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleado",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool CrearPerfilEmpleado(Empleado empleado);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleado",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "UPDATE",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool ModificarPerfilEmpleado(Empleado empleado);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleado",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool EliminarPerfilEmpleado(Empleado empleado);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleado/{user}/{pass}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        Empleado ConsultarPerfilEmpleado(string user, string pass);
        #endregion
        #region EmpleadoPlantel
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleadoplantel",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool CrearPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleadoplantel",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "UPDATE",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool ModificarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleadoplantel",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool EliminarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleadoplantel/{user}/{pass}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        EmpleadoPlantel ConsultarPerfilEmpleadoPlantel(string user, string pass);
        #endregion
        #region PadreFamilia
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool CrearPerfilPadreFamilia(PadreFamilia persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "UPDATE",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool ModificarPerfilPadreFamilia(PadreFamilia persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool EliminarPerfilPadreFamilia(PadreFamilia persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia/{user}/{pass}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        PadreFamilia ConsultarPerfilPadreFamilia(string user, string pass);
        #endregion
        #region Alumno
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool CrearPerfilAlumno(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "UPDATE",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool ModificarPerfilAlumno(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool EliminarPerfilAlumno(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia/{user}/{pass}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        Persona ConsultarPerfilAlumno(string user, string pass);
        #endregion
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
