using System;
using System.Collections.Generic;
using WebServiceAppli_KT.Controlador;
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
        #endregion

        #region variables(Objetos)
        Notificaciones entNotificacion;
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


        public Notificaciones ConsultarNotificaciones()
        {
            try
            {
                notificacionController = new ControladorNotificacion();
                entNotificacion = new Notificaciones();
                entNotificacion = notificacionController.Consultar();
                return entNotificacion;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public bool CrearCuenta(string usuario, string contrasenia)
        public bool CrearCuenta(string usuario, string contrasena, string idAlumno)
        {
            try
            {
                loginController = new ControladorLogin();
                //if (loginController.CrearCuenta(usuario, contrasenia))
                if (loginController.CrearCuenta(usuario, contrasena, idAlumno))
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
        public Persona ConsultarPerfilAlumno(string cve_usuario, string cve_persona)
        {
            controladorAlumno = new ControladorAlumno();
            entPersona = new Persona();
            entPersona = controladorAlumno.ConsultarAlumno(Convert.ToInt16(cve_usuario));
            return entPersona;
        }

        public Empleado ConsultarPerfilEmpleado(string cve_usuario, string cve_persona)
        {
            perfilController = new ControladorPerfil();
            ent_empleado = new Empleado();
            ent_empleado = perfilController.ConsultarPerfilEmpleado(Convert.ToInt16(cve_usuario), Convert.ToInt16(cve_persona));
            return ent_empleado;

        }

        public EmpleadoPlantel ConsultarPerfilEmpleadoPlantel(string cve_usuario, string cve_persona)
        {
            perfilController = new ControladorPerfil();
            ent_empleado_plantel = new EmpleadoPlantel();
            ent_empleado_plantel = perfilController.ConsultarPerfilEmpleadoPlantel(Convert.ToInt16(cve_usuario), Convert.ToInt16(cve_persona));
            return ent_empleado_plantel;
        }

        public PadreFamilia ConsultarPerfilPadreFamilia(string cve_usuario, string cve_persona)
        {
            perfilController = new ControladorPerfil();
            ent_padre_familia = new PadreFamilia();
            ent_padre_familia = perfilController.ConsultarPerfilPadreFamilia(Convert.ToInt16(cve_usuario), Convert.ToInt16(cve_persona));
            return ent_padre_familia;
        }

        public Persona ConsultarPerfilS(string cve_usuario, string cve_persona)
        {
            try
            {
                perfilController = new ControladorPerfil();
                entPersona = perfilController.ConsultarPerfill(Convert.ToInt16(cve_usuario));
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
        public List<int> CrearPerfil(Persona persona)
        {
            try
            {
                perfilController = new ControladorPerfil();
                return perfilController.CrearPerfill(persona);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<int> CrearPerfilAlumno(Persona persona)
        {
            controladorAlumno = new ControladorAlumno();
            return controladorAlumno.GuardarAlumno(persona);

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

        public bool EliminarPerfilAlumno(Persona persona)
        {
            bool realizado;
            controladorAlumno = new ControladorAlumno();
            realizado = controladorAlumno.EliminarAlumno(persona);
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

        public bool ModificarPerfilAlumno(Persona persona)
        {
            controladorAlumno = new ControladorAlumno();
            return controladorAlumno.ModificarAlumno(persona);
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

        public bool ValidarContrasenia(string contrasenia)
        {
            try
            {
                loginController = new ControladorLogin();
                if (loginController.ValidarContrasenia(contrasenia))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool ValidarUsuario(string usuario)
        {
            try
            {
                loginController = new ControladorLogin();
                return loginController.ValidarUsuario(usuario);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        #region Plantel
        public List<PlantelesES> ObtenerPlanteles()
        {
            try
            {
                escuelaESController = new ControladorEscuelasES();
                lstPlanteles = new List<PlantelesES>();
                lstPlanteles = escuelaESController.ObtenerPlanteles();
                return lstPlanteles;
            }
            catch (Exception)
            {
                return null;
            }
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
            return loginController.RecuperarContrasena(usuario, nuevaContrasena);
        }
        #endregion

    }
}
