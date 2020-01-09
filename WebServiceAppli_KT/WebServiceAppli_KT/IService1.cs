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
        [WebGet(UriTemplate = "/recuperarContrasena/{usuario}/{nuevaContrasena}",
                ResponseFormat = WebMessageFormat.Json)]
        bool RecuperarContrasena(string usuario, string nuevaContrasena);
        [OperationContract]
        [WebGet(UriTemplate = "/validarUsuario/{usuario}",
                ResponseFormat = WebMessageFormat.Json)]
        bool ValidarUsuario(string usuario);
        [OperationContract]
        [WebInvoke(UriTemplate = "/validarContrasenia/{contrasenia}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        bool ValidarContrasenia(string contrasenia);

        [OperationContract]
        [WebInvoke(UriTemplate = "/crearCuenta/{usuario}/{contrasena}/{idAlumno}/{tipoUsuario}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, 
            Method = "GET")]
        bool CrearCuenta(string usuario, string contrasena, string idAlumno, string tipoUsuario);

        //Perfil
        #region Persona
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST")]
        List<int> CrearPerfil(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "PUT")]
        bool ModificarPerfil(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE")]
        bool EliminarPerfil(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil/{cve_usuario}/{cve_persona}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        Persona ConsultarPerfilS(string cve_usuario, string cve_persona);
        #endregion
        #region Empleado
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleado",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST")]
        List<int> CrearPerfilEmpleado(Empleado empleado);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleado",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "PUT")]
        bool ModificarPerfilEmpleado(Empleado empleado);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleado",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE")]
        bool EliminarPerfilEmpleado(Empleado empleado);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleado/{cve_usuario}/{cve_persona}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        Empleado ConsultarPerfilEmpleado(string cve_usuario, string cve_persona);
        #endregion
        #region EmpleadoPlantel
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleadoplantel",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST")]
        List<int> CrearPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleadoplantel",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "PUT")]
        bool ModificarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleadoplantel",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE")]
        bool EliminarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleadoplantel/{cve_usuario}/{cve_persona}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        EmpleadoPlantel ConsultarPerfilEmpleadoPlantel(string cve_usuario, string cve_persona);
        #endregion
        #region PadreFamilia
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST")]
        List<int> CrearPerfilPadreFamilia(PadreFamilia padreFamilia);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "PUT")]
        bool ModificarPerfilPadreFamilia(PadreFamilia padreFamilia);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE")]
        bool EliminarPerfilPadreFamilia(PadreFamilia padreFamilia);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia/{cve_usuario}/{cve_persona}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        PadreFamilia ConsultarPerfilPadreFamilia(string cve_usuario, string cve_persona);
        #endregion
        #region Alumno
        [OperationContract]
        [WebInvoke(UriTemplate = "/alumno",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST")]
        List<int> CrearPerfilAlumno(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/alumno",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "PUT")]
        bool ModificarPerfilAlumno(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/alumno",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE")]
        bool EliminarPerfilAlumno(Persona persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/alumno/{cve_usuario}/{cve_persona}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        Persona ConsultarPerfilAlumno(string cve_usuario, string cve_persona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/alumnocurp/{curp}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        int BuscarAlumnoCurp(string curp);
        #endregion
        //Notificaciones
        [OperationContract]
        [WebInvoke(UriTemplate = "/notificacion",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        Notificaciones ConsultarNotificaciones();
        //Atlas
        #region Planteles
        [OperationContract]
        [WebInvoke(UriTemplate = "/planteles",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        List<PlantelesES> ObtenerPlanteles();

        [OperationContract]
        [WebInvoke(UriTemplate = "/buscarplantelmunicipio/{municipio}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   Method = "GET")]
        PlantelesES BuscarPlantelesMunicipio(string municipio);

        [OperationContract]
        [WebInvoke(UriTemplate = "/buscarplantelid/{carrera}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   Method = "GET")]
        PlantelesES BuscarPlantelesId(string carrera);

        [OperationContract]
        [WebInvoke(UriTemplate = "/buscarplantel/{plantel}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   Method = "GET")]
        PlantelesES BuscarPlanteles(string plantel);
        #endregion
        [OperationContract]
        [WebInvoke(UriTemplate = "/carreras",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        List<CarrerasES> ObtenerCarreras();
        [OperationContract]
        [WebInvoke(UriTemplate = "/gruposeguridad",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   Method = "GET")]
        List<string> ObtenerGrupos();
        //Direccion
        [OperationContract]
        [WebInvoke(UriTemplate = "/colonia/{cp}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   Method = "GET")]
        List<Colonias> ObtenerColonias(string cp);
        [OperationContract]
        [WebInvoke(UriTemplate = "/coloniaid/{colonia}",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           Method = "GET")]
        int BuscarColonia(string colonia);
        [OperationContract]
        [WebInvoke(UriTemplate = "/municipios/{estado}",
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  Method = "GET")]
        List<Municipios> ObtenerMunicipios(string estado);

        [OperationContract]
        [WebGet(UriTemplate = "/estados",
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json)]
        List < Estados> ObtenerEstados();

        [OperationContract]
        [WebInvoke(UriTemplate = "/paises",
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  Method = "GET")]
        List<Paises> ObtenerPaises();
        //Historial

        // TODO: agregue aquí sus operaciones de servicio
    }
}
