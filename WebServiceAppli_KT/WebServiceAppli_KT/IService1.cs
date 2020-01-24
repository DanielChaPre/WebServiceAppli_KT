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
        [WebGet(UriTemplate = "/recuperarContrasena/{usuario}/{nuevaContrasena}",
                ResponseFormat = WebMessageFormat.Json)]
        bool RecuperarContrasena(string usuario, string nuevaContrasena);
        [OperationContract]
        [WebGet(UriTemplate = "/validarUsuario/{usuario}",
                ResponseFormat = WebMessageFormat.Json)]
        bool ValidarUsuario(string usuario);
        [OperationContract]
        [WebInvoke(UriTemplate = "/validarContrasenia/{contrasenia}/{usuario}/{idAlumno}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        int ValidarContrasenia(string contrasenia, string usuario, string idAlumno);

        [OperationContract]
        [WebInvoke(UriTemplate = "/crearCuenta/{usuario}/{contrasena}/{idAlumno}/{tipoUsuario}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, 
            Method = "GET")]
        bool CrearCuenta(string usuario, string contrasena, string idAlumno, string tipoUsuario);

        [OperationContract]
        [WebInvoke(UriTemplate = "/verificarAlumno/{contrasena}/{idAlumno}",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           Method = "GET")]
        bool VerificarRegistroAlumno(string contrasena, string idAlumno);

        //Perfil
        #region Persona
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil",
                  RequestFormat = WebMessageFormat.Json, 
                  ResponseFormat = WebMessageFormat.Json, 
                  Method = "POST", 
                  BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<int> CrearPerfil(Persona entpersona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "PUT",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool ModificarPerfil(Persona entpersona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    Method = "DELETE")]
        bool EliminarPerfil(Persona entpersona);
        [OperationContract]
        [WebInvoke(UriTemplate = "/perfil/{usuario}/{contrasenia}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        Persona ConsultarPerfilS(string usuario, string contrasenia);
        #endregion
        #region Empleado
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleado",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST",
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<int> CrearPerfilEmpleado(Empleado empleado);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleado",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "PUT",
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
        [WebInvoke(UriTemplate = "/empleado/{usuario}/{contrasenia}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        Empleado ConsultarPerfilEmpleado(string usuario, string contrasenia);
        #endregion
        #region EmpleadoPlantel
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleadoplantel",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST",
                  BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<int> CrearPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel);
        [OperationContract]
        [WebInvoke(UriTemplate = "/empleadoplantel",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "PUT",
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
        [WebInvoke(UriTemplate = "/empleadoplantel/{usuario}/{contrasenia}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        EmpleadoPlantel ConsultarPerfilEmpleadoPlantel(string usuario, string contrasenia);
        #endregion
        #region PadreFamilia
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST",
                  BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<int> CrearPerfilPadreFamilia(PadreFamilia padreFamilia);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "PUT",
                  BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool ModificarPerfilPadreFamilia(PadreFamilia padreFamilia);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE",
                  BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool EliminarPerfilPadreFamilia(PadreFamilia padreFamilia);
        [OperationContract]
        [WebInvoke(UriTemplate = "/padrefamilia/{usuario}/{contrasenia}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        PadreFamilia ConsultarPerfilPadreFamilia(string usuario, string contrasenia);
        #endregion
        #region Alumno
        [OperationContract]
        [WebInvoke(UriTemplate = "/alumno",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "POST",
                  BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<int> CrearPerfilAlumno(Alumno alumno);
        [OperationContract]
        [WebInvoke(UriTemplate = "/alumno",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "PUT",
                  BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool ModificarPerfilAlumno(Alumno alumno);
        [OperationContract]
        [WebInvoke(UriTemplate = "/alumno",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "DELETE",
                  BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool EliminarPerfilAlumno(Alumno alumno);
        [OperationContract]
        [WebInvoke(UriTemplate = "/alumno/{idAlumno}",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    Method = "GET")]
        Alumno ConsultarPerfilAlumno(string idAlumno);
        [OperationContract]
        [WebInvoke(UriTemplate = "/usuarioalumno/{idAlumno}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   Method = "GET")]
        Usuario ConsultarUsuarioAlumno(string idAlumno);

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

        [OperationContract]
        [WebInvoke(UriTemplate = "/buscarplantelEMS/{idplantel}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   Method = "GET")]
        PlantelesEMS BuscarPlantelesEMS(string idplantel);
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
