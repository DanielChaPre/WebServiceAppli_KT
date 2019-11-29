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

        public Persona ConsultarPerfilAlumno(string cve_usuario)
        {
            controladorAlumno = new ControladorAlumno();
            entPersona = new Persona();
            entPersona = controladorAlumno.ConsultarAlumno(Convert.ToInt16(cve_usuario));
            return entPersona;
        }

        public Empleado ConsultarPerfilEmpleado(string cve_usuario)
        {
            perfilController = new ControladorPerfil();
            ent_empleado = new Empleado();
            ent_empleado = perfilController.ConsultarPerfilEmpleado(Convert.ToInt16(cve_usuario));
            return ent_empleado;

        }

        public EmpleadoPlantel ConsultarPerfilEmpleadoPlantel(string cve_usuario)
        {
            perfilController = new ControladorPerfil();
            ent_empleado_plantel = new EmpleadoPlantel();
            ent_empleado_plantel = perfilController.ConsultarPerfilEmpleadoPlantel(Convert.ToInt16(cve_usuario));
            return ent_empleado_plantel;
        }

        public PadreFamilia ConsultarPerfilPadreFamilia(string cve_usuario)
        {
            perfilController = new ControladorPerfil();
            ent_padre_familia = new PadreFamilia();
            ent_padre_familia = perfilController.ConsultarPerfilPadreFamilia(Convert.ToInt16(cve_usuario));
            return ent_padre_familia;
        }

        public Persona ConsultarPerfilS(string cve_usuario)
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

        //public bool CrearCuenta(string usuario, string contrasenia)
        public bool CrearCuenta(Persona persona)
        {
            try
            {
                loginController = new ControladorLogin();
                //if (loginController.CrearCuenta(usuario, contrasenia))
                if (loginController.CrearCuenta(persona))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int CrearPerfil(Persona persona)
        {
            try
            {
                perfilController = new ControladorPerfil();
                return perfilController.CrearPerfill(persona);
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public bool CrearPerfilAlumno(Persona persona)
        {
            bool realizado;
            controladorAlumno = new ControladorAlumno();
            realizado = controladorAlumno.GuardarAlumno(persona);
            return realizado;

        }

        public bool CrearPerfilEmpleado(Empleado empleado)
        {
            bool realizado;
            perfilController = new ControladorPerfil();
            realizado = perfilController.CrearPerfilEmpleado(empleado);
            return realizado;
        }

        public bool CrearPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel)
        {
            bool realizado;
            perfilController = new ControladorPerfil();
            realizado = perfilController.CrearPerfilEmpleadoPlantel(empleadoPlantel);
            return realizado;
        }

        public bool CrearPerfilPadreFamilia(PadreFamilia persona)
        {
            bool realizado;
            perfilController = new ControladorPerfil();
            realizado = perfilController.CrearPerfilPadreFamilia(persona);
            return realizado;
        }

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

        public bool ModificarPerfil(Persona persona)
        {
            try
            {
                perfilController = new ControladorPerfil();
                perfilController.ModificarPerfill(persona);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool ModificarPerfilAlumno(Persona persona)
        {
            bool realizado;
            controladorAlumno = new ControladorAlumno();
            realizado = controladorAlumno.ModificarAlumno(persona);
            return realizado;
        }

        public bool ModificarPerfilEmpleado(Empleado empleado)
        {
            bool realizado;
            perfilController = new ControladorPerfil();
            realizado = perfilController.ModificarPerfilEmpleado(empleado);
            return realizado;
        }

        public bool ModificarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel)
        {
            bool realizado;
            perfilController = new ControladorPerfil();
            realizado = perfilController.ModificarPerfilEmpleadoPlantel(empleadoPlantel);
            return realizado;
        }

        public bool ModificarPerfilPadreFamilia(PadreFamilia persona)
        {
            bool realizado;
            perfilController = new ControladorPerfil();
            realizado = perfilController.ModificarPerfilPadreFamilia(persona);
            return realizado;
        }

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

        public List<Colonias> ObtenerColonias()
        {
            try
            {
                controladorDireccion = new ControladorDireccion();
                lst_colonias = new List<Colonias>();
                lst_colonias = controladorDireccion.ConsultarColonia();
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

        public List<Municipios> ObtenerMunicipios()
        {
            try
            {
                controladorDireccion = new ControladorDireccion();
                lst_municipios = new List<Municipios>();
                lst_municipios = controladorDireccion.ConsultarMunicipios();
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
                if (loginController.ValidarUsuario(usuario))
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
    }
}
