using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebServiceAppli_KT.Controlador;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        LoginControllerClass loginController;
        NotificacionControllerClass notificacionController;
        NotificacionClass entNotificacion;
        UsuarioClass entUsuarion = new UsuarioClass();


        public NotificacionClass consultar()
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

        public bool IniciarSesion(string user, string pass)
        {
            loginController = new LoginControllerClass();
            try
            {
                entUsuarion.nombreUsuario = user;
                entUsuarion.contrasenia = pass;
                loginController.iniciarSesion(entUsuarion);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
