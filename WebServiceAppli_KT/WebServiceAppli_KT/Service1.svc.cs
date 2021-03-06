﻿using System;
using System.Collections.Generic;
using WebServiceAppli_KT.Controlador;
using WebServiceAppli_KT.Controlador.Applikt;
using WebServiceAppli_KT.Controlador.Suredsu;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        #region controladores
        ControladorLogin loginController;
        ControladorNotificacion notificacionController;
        ControladorEscuelasES escuelaESController;
        ControladorCarreasES carrerasController;
        ControladorPerfil perfilController;
        ControladorGrupoSeguridad grupoSeguridadController;
        ControladorDireccion controladorDireccion;
        ControladorAlumno controladorAlumno;
        ControladorConfiguracionPlantilla controladorConfiguracionPlantilla;
        ControladorHistorialBusquedaCarrera controladorHistorialBusquedaCarrera;
        #endregion

        #region variables(Objetos)
        List<Notificaciones> entNotificacion;
        Alumno entAlumno = new Alumno();
        Persona entPersona = new Persona();
        Usuario entUsuario = new Usuario();
        Empleado ent_empleado = new Empleado();
        EmpleadoPlantel ent_empleado_plantel = new EmpleadoPlantel();
        PadreFamilia ent_padre_familia = new PadreFamilia();
        PlantelesES planteles;
        List<PlantelesES> lstPlanteles;
        List<CarrerasES> lstCarreras;
        List<Colonias> lst_colonias;
        List<Municipios> lst_municipios;
        List<Estados> lst_estados;
        List<Paises> lst_paises;
        #endregion


        public List<Notificaciones> ConsultarNotificaciones(string cveUsuario)
        {
            try
            {
                notificacionController = new ControladorNotificacion();
                entNotificacion = new List<Notificaciones>();
                entNotificacion = notificacionController.Consultar(cveUsuario);
                return entNotificacion;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public bool CrearCuenta(string usuario, string contrasenia)
        public bool CrearCuenta(string usuario, string contrasena, string idAlumno, string tipoUsuario)
        {
            try
            {
                loginController = new ControladorLogin();
                //if (loginController.CrearCuenta(usuario, contrasenia))
                if (loginController.CrearCuenta(usuario, contrasena, idAlumno, tipoUsuario))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region perfiles
        #region consultar perfiles
        public Alumno ConsultarPerfilAlumno(string idAlumno)
        {
            controladorAlumno = new ControladorAlumno();
            //entPersona = controladorAlumno.ConsultarAlumno(Convert.ToInt32(idAlumno));
            return controladorAlumno.ConsultarAlumno(Convert.ToInt32(idAlumno));
        }

        public Empleado ConsultarPerfilEmpleado(string usuario, string contrasenia)
        {
            perfilController = new ControladorPerfil();
            ent_empleado = new Empleado();
            ent_empleado = perfilController.ConsultarPerfilEmpleado(usuario, contrasenia);
            return ent_empleado;

        }

        public EmpleadoPlantel ConsultarPerfilEmpleadoPlantel(string usuario, string contrasenia)
        {
            perfilController = new ControladorPerfil();
            ent_empleado_plantel = new EmpleadoPlantel();
            ent_empleado_plantel = perfilController.ConsultarPerfilEmpleadoPlantel(usuario, contrasenia);
            return ent_empleado_plantel;
        }

        public PadreFamilia ConsultarPerfilPadreFamilia(string usuario, string contrasenia)
        {
            perfilController = new ControladorPerfil();
            ent_padre_familia = new PadreFamilia();
            ent_padre_familia = perfilController.ConsultarPerfilPadreFamilia(usuario, contrasenia);
            return ent_padre_familia;
        }

        public Persona ConsultarPerfilS(string usuario, string contrasenia)
        {
            try
            {
                perfilController = new ControladorPerfil();
                entPersona = perfilController.ConsultarPerfill(usuario, contrasenia);
                return entPersona;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region crear perfil
        public List<int> CrearPerfil(Persona entpersona)
        {
            try
            {
                perfilController = new ControladorPerfil();
                return perfilController.CrearPerfill(entpersona);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<int> CrearPerfilAlumno(Alumno alumno)
        {
            controladorAlumno = new ControladorAlumno();
            return controladorAlumno.GuardarAlumno(alumno);

        }

        public List<int> CrearPerfilEmpleado(Empleado empleado)
        {
            perfilController = new ControladorPerfil();
            return perfilController.CrearPerfilEmpleado(empleado);
        }

        public List<int> CrearPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel)
        {
            perfilController = new ControladorPerfil();
            return perfilController.CrearPerfilEmpleadoPlantel(empleadoPlantel);
        }

        public List<int> CrearPerfilPadreFamilia(PadreFamilia persona)
        {
            perfilController = new ControladorPerfil();
            return perfilController.CrearPerfilPadreFamilia(persona);
        }
        #endregion

        #region Eliminar perfiles
        public bool EliminarPerfil(Persona persona)
        {
            try
            {
                perfilController = new ControladorPerfil();
                perfilController.EliminarPerfill(persona);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool EliminarPerfilAlumno(Alumno alumno)
        {
            bool realizado;
            controladorAlumno = new ControladorAlumno();
            realizado = controladorAlumno.EliminarAlumno(alumno);
            return realizado;
        }

        public bool EliminarPerfilEmpleado(Empleado empleado)
        {
            bool realizado;
            perfilController = new ControladorPerfil();
            realizado = perfilController.EliminarPerfilEmpleado(empleado);
            return realizado;
        }

        public bool EliminarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel)
        {
            bool realizado;
            perfilController = new ControladorPerfil();
            realizado = perfilController.EliminarPerfilEmpleadoPlantel(empleadoPlantel);
            return realizado;
        }

        public bool EliminarPerfilPadreFamilia(PadreFamilia persona)
        {
            bool realizado;
            perfilController = new ControladorPerfil();
            realizado = perfilController.EliminarPerfilPadreFamilia(persona);
            return realizado;
        }
        #endregion

        #region Modificar perfiles
        public bool ModificarPerfil(Persona persona)
        {
            perfilController = new ControladorPerfil();
            return perfilController.ModificarPerfill(persona);
        }

        public bool ModificarPerfilAlumno(Alumno alumno)
        {
            controladorAlumno = new ControladorAlumno();
            return controladorAlumno.ModificarAlumno(alumno);
        }

        public bool ModificarPerfilEmpleado(Empleado empleado)
        {
            perfilController = new ControladorPerfil();
            return perfilController.ModificarPerfilEmpleado(empleado);
        }

        public bool ModificarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel)
        {
            perfilController = new ControladorPerfil();
            return perfilController.ModificarPerfilEmpleadoPlantel(empleadoPlantel);
        }

        public bool ModificarPerfilPadreFamilia(PadreFamilia persona)
        {
            perfilController = new ControladorPerfil();
            return perfilController.ModificarPerfilPadreFamilia(persona);
        }
        #endregion 
        #endregion

        public List<CarrerasES> ObtenerCarreras()
        {
            try
            {
                carrerasController = new ControladorCarreasES();
                lstCarreras = new List<CarrerasES>();
                lstCarreras = carrerasController.ObtenerCarreras();
                return lstCarreras;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Colonias> ObtenerColonias(string cp)
        {
            try
            {
                controladorDireccion = new ControladorDireccion();
                lst_colonias = new List<Colonias>();
                lst_colonias = controladorDireccion.ConsultarColonia(cp);
                return lst_colonias;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<Estados> ObtenerEstados()
        {
            try
            {
                controladorDireccion = new ControladorDireccion();
                lst_estados = new List<Estados>();
                lst_estados = controladorDireccion.ConsultarEstados();
                return lst_estados;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<string> ObtenerGrupos()
        {
            try
            {
                grupoSeguridadController = new ControladorGrupoSeguridad();
                List<string> lstGrupos = new List<string>();
                lstGrupos = grupoSeguridadController.ConsultarGrupos();
                return lstGrupos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Municipios> ObtenerMunicipios(string estado)
        {
            try
            {
                controladorDireccion = new ControladorDireccion();
                lst_municipios = new List<Municipios>();
                lst_municipios = controladorDireccion.ConsultarMunicipios(estado);
                return lst_municipios;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Paises> ObtenerPaises()
        {
            try
            {
                controladorDireccion = new ControladorDireccion();
                lst_paises = new List<Paises>();
                lst_paises = controladorDireccion.ConsultarPaises();
                return lst_paises;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<string> ValidarContrasenia(string contrasenia, string usuario, string idAlumno)
        {
            try
            {
                loginController = new ControladorLogin();
                return loginController.ValidarContrasenia(contrasenia, usuario, idAlumno);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<string> ValidarContraseniaAlumno(string contrasenia, string usuario, string idAlumno)
        {
            try
            {
                loginController = new ControladorLogin();
                return loginController.ValidarContrasenaAlumno(contrasenia, usuario, idAlumno);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public string ValidarUsuario(string usuario)
        {
            try
            {
                loginController = new ControladorLogin();
                return loginController.ValidarUsuario(usuario);
            }
            catch (Exception)
            {
                return "";
                throw;
            }
        }

        public string ValidarUsuarioAlumno(string idAlumno)
        {
            loginController = new ControladorLogin();
            return loginController.ValidarUsuarioAlumno(idAlumno);
        }


        #region Plantel
        public List<PlantelesES> ObtenerPlanteles()
        {
            escuelaESController = new ControladorEscuelasES();
            return escuelaESController.ObtenerPlanteles();
        }

        public List<DetallePlantel> ObtenerDetallePlantel()
        {

            escuelaESController = new ControladorEscuelasES();
            return escuelaESController.ObtenerDetallePlantel();
        }

        public PlantelesES BuscarPlantelesMunicipio(string municipio)
        {
            escuelaESController = new ControladorEscuelasES();
            planteles = new PlantelesES();
            planteles = escuelaESController.BuscarPlantelMunicipio(municipio);
            return planteles;
        }

        public PlantelesES BuscarPlantelesId(string carrera)
        {
            escuelaESController = new ControladorEscuelasES();
            planteles = new PlantelesES();
            planteles = escuelaESController.BuscarPlantelCarrera(carrera);
            return planteles;
        }

        public PlantelesES BuscarPlanteles(string plantel)
        {
            escuelaESController = new ControladorEscuelasES();
            planteles = new PlantelesES();
            planteles = escuelaESController.BuscarPlantel(plantel);
            return planteles;
        }

        public int BuscarAlumnoCurp(string curp)
        {
            controladorAlumno = new ControladorAlumno();
            return controladorAlumno.BuscarAlumnoCurp(curp);
        }


        public int BuscarColonia(string colonia)
        {
            controladorDireccion = new ControladorDireccion();
            return controladorDireccion.BuscarColonia(colonia);
        }

        public bool RecuperarContrasena(string usuario, string nuevaContrasena)
        {
            loginController = new ControladorLogin();
            return loginController.RecuperarContrasena(usuario, nuevaContrasena);
        }

        public bool VerificarRegistroAlumno(string contrasena, string idAlumno)
        {
            loginController = new ControladorLogin();
            return loginController.VerificarRegistroAlumno(contrasena, idAlumno);
        }

        public Usuario ConsultarUsuarioAlumno(string idAlumno)
        {
            loginController = new ControladorLogin();
            return loginController.ConsultarUsuarioAlumno(idAlumno);
        }

        public PlantelesEMS BuscarPlantelesEMS(string idplantel)
        {
            escuelaESController = new ControladorEscuelasES();
            return escuelaESController.BuscarPlantelEMS(Convert.ToInt32(idplantel));
        }

        public bool EliminarNotificacion(string cveUsuario, string cveNotificacion)
        {
            notificacionController = new ControladorNotificacion();
            return notificacionController.EliminarNotificacion(cveUsuario, cveNotificacion);
        }

        public List<Municipios> ObtenerTodosMunicipios()
        {
            controladorDireccion = new ControladorDireccion();
            return controladorDireccion.ConsultarTodosMunicipios();
        }

        public DetallePlantel BuscarDetallePlantel(string idplantel)
        {
            escuelaESController = new ControladorEscuelasES();
            return escuelaESController.BuscarDetallePlantel(idplantel);
        }

        public List<Historial> ObtenerHistorial(string cveUsuario)
        {
            var historialController = new ControladorHistorial();
            return historialController.ConsultarHistorial(cveUsuario);
        }

        public List<string> ConsultarPlantillas(string cveUsuario)
        {
            controladorConfiguracionPlantilla = new ControladorConfiguracionPlantilla();
            return controladorConfiguracionPlantilla.ConsultarPlantillasUsuario(cveUsuario);
        }

        public List<string> ConsultarPlantillasAlumno(string idAlumno)
        {
            controladorConfiguracionPlantilla = new ControladorConfiguracionPlantilla();
            return controladorConfiguracionPlantilla.ConsultarPlantillasUsuarioAlumno(idAlumno);
        }

        public List<string> ValidarUsuarioFacebook(string aliasred)
        {
            loginController = new ControladorLogin();
            return loginController.ValidarUsuarioFacebook(aliasred);
        }

        public List<string> ValidarUsuarioGoogle(string aliasred)
        {
            loginController = new ControladorLogin();
            return loginController.ValidarUsuarioGoogle(aliasred);
        }

        public List<string> RelacionarFacebookUsuario(string aliasred, string usuario, string contrasena)
        {
            loginController = new ControladorLogin();
            return loginController.RelacionarFacebookUsuario(aliasred, usuario, contrasena);
        }

        public List<string> RelacionarGoogleUsuario(string aliasred, string usuario, string contrasena)
        {
            loginController = new ControladorLogin();
            return loginController.RelacionarGoogleUsuario(aliasred, usuario, contrasena);
        }

        public List<string> RelacionarFacebookAlumno(string aliasred, string curp, string contrasena)
        {
            loginController = new ControladorLogin();
            return loginController.RelacionarFacebookAlumno(aliasred, curp, contrasena);
        }

        public List<string> RelacionarGoogleAlumno(string aliasred, string curp, string contrasena)
        {
            loginController = new ControladorLogin();
            return loginController.RelacionarGoogleAlumno(aliasred, curp, contrasena);
        }

        public List<ImagenPlantel> BuscarImagenesPlantel(string idplantel)
        {
            escuelaESController = new ControladorEscuelasES();
            return escuelaESController.BuscarImagenPlantel(idplantel);
        }

        public List<ImagenPlantel> BuscarImagenesPlanteles()
        {
            escuelaESController = new ControladorEscuelasES();
            return escuelaESController.BuscarImagenPlanteles();
        }

        public List<CarrerasES> ObtenerCarrerasPlantel(string idplantel)
        {
            carrerasController = new ControladorCarreasES();
            return carrerasController.ObtenerCarrerasPlantel(idplantel);
        }

        public List<string> ObtenerTema()
        {
            controladorConfiguracionPlantilla = new ControladorConfiguracionPlantilla();
            return controladorConfiguracionPlantilla.ConsultarTema();
        }

        public Resultados BuscarAptitudesAlumno(string idAlumno)
        {
            controladorAlumno = new ControladorAlumno();
            return controladorAlumno.BuscarAptitudesAlumno(idAlumno);
        }

        public List<DetalleCarreraPlantel> BuscarDetalleCarrera()
        {
            carrerasController = new ControladorCarreasES();
            return carrerasController.ObtenerDetalleCarreras();
        }

        public bool BusquedaCarrera(string cveUsuario, string idCarrera)
        {
            controladorHistorialBusquedaCarrera = new ControladorHistorialBusquedaCarrera();
            return controladorHistorialBusquedaCarrera.AgregarBusquedaCarrera(cveUsuario, idCarrera);
        }

        public bool HistorialVisita(string cveUsuario)
        {
            controladorHistorialBusquedaCarrera = new ControladorHistorialBusquedaCarrera();
            return controladorHistorialBusquedaCarrera.AgregarHistorialVisita(cveUsuario);
        }
        #endregion

    }
}
