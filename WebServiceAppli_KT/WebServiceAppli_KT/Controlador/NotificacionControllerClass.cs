using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class NotificacionControllerClass
    {
        NotificacionDAOClass notificacionDAO;
        NotificacionClass entNotificacion;

        public NotificacionControllerClass()
        {
            notificacionDAO = new NotificacionDAOClass();
        }

        public NotificacionClass consultar()
        {
            try
            {
                entNotificacion = new NotificacionClass();
                entNotificacion = notificacionDAO.consultarNotificaciones();
                return entNotificacion;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}