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
        LoginControllerClass loginController;
        NotificacionControllerClass notificacionController;
        EscuelaESControllerClass escuelaESController;
        CarrerasControllerClass carrerasController;
        PerfilController perfilController;
        #endregion

        #region variables(Objetos)
        NotificacionClass entNotificacion;
        UsuarioClass entUsuario = new UsuarioClass();
        List<PlantelesESClass> lstPlanteles;
        List<CarrerasESClass> lstCarreras;
        #endregion


        public NotificacionClass ConsultarNotificaciones()
        {
            try
            {
                notificacionController = new NotificacionControllerClass();
                entNotificacion = new NotificacionClass();
                entNotificacion = notificacionController.consultar();
                return entNotificacion;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UsuarioClass ConsultarPerfil(string user, string pass)
        {
            try
            {
                perfilController = new PerfilController();
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
        public bool CrearCuenta(UsuarioClass usuario)
        {
            try
            {
                loginController = new LoginControllerClass();
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

        public bool CrearPerfil(UsuarioClass usuario)
        {
            try
            {
                perfilController = new PerfilController();
                perfilController.CrearPerfil(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool EliminarPerfil(int cveUsuario, int cvePersona)
        {
            try
            {
                perfilController = new PerfilController();
                perfilController.EliminarPerfil(cveUsuario, cvePersona);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

       

        public bool ModificarPerfil(UsuarioClass usuario)
        {
            try
            {
                perfilController = new PerfilController();
                perfilController.ModificarPerfil(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<CarrerasESClass> ObtenerCarreras()
        {
            try
            {
                carrerasController = new CarrerasControllerClass();
                lstCarreras = new List<CarrerasESClass>();
                lstCarreras = carrerasController.obtenerCarreras();
                return lstCarreras;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PlantelesESClass> ObtenerPlanteles()
        {
            try
            {
                escuelaESController = new EscuelaESControllerClass();
                lstPlanteles = new List<PlantelesESClass>();
                lstPlanteles = escuelaESController.obtenerPlanteles();
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
                loginController = new LoginControllerClass();
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
                loginController = new LoginControllerClass();
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
