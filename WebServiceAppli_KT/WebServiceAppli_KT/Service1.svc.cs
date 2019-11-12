using System;
using System.Collections.Generic;
using WebServiceAppli_KT.Controlador;
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
        #endregion

        #region variables(Objetos)
        Notificaciones entNotificacion;
        Usuario entUsuario = new Usuario();
        List<PlantelesES> lstPlanteles;
        List<CarrerasES> lstCarreras;
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

        public Usuario ConsultarPerfil(string user, string pass)
        {
            try
            {
                perfilController = new ControladorPerfil();
                entUsuario = perfilController.ConsultarPerfil(user, pass);
                return entUsuario;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            
        }

        //public bool CrearCuenta(string usuario, string contrasenia)
        public bool CrearCuenta(Usuario usuario)
        {
            try
            {
                loginController = new ControladorLogin();
                //if (loginController.CrearCuenta(usuario, contrasenia))
                if (loginController.CrearCuenta(usuario))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CrearPerfil(Usuario usuario)
        {
            try
            {
                perfilController = new ControladorPerfil();
                perfilController.CrearPerfil(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool EliminarPerfil(Usuario usuario)
        {
            try
            {
                perfilController = new ControladorPerfil();
                perfilController.EliminarPerfil(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

       

        public bool ModificarPerfil(Usuario usuario)
        {
            try
            {
                perfilController = new ControladorPerfil();
                perfilController.ModificarPerfil(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
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
