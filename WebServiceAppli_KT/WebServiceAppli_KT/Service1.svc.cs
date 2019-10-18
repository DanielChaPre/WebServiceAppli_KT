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
        #region controladores
        LoginControllerClass loginController;
        NotificacionControllerClass notificacionController;
        EscuelaESControllerClass escuelaESController;
        CarrerasControllerClass carrerasController;
        #endregion
        #region variabnles(Objetos)
        NotificacionClass entNotificacion;
        UsuarioClass entUsuarion = new UsuarioClass();
        List<PlantelesESClass> lstPlanteles;
        List<CarrerasESClass> lstCarreras;
        #endregion


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
            }
        }

        public List<CarrerasESClass> obtenerCarreras()
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

        public List<PlantelesESClass> obtenerPlanteles()
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
    }
}
