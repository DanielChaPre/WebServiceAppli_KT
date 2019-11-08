using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class ControladorNotificacion
    {
        NotificacionDAO notificacionDAO;
        Notificaciones entNotificacion;

        public ControladorNotificacion()
        {
            notificacionDAO = new NotificacionDAO();
        }

        public Notificaciones Consultar()
        {
            try
            {
                entNotificacion = new Notificaciones();
                entNotificacion = notificacionDAO.ConsultarNotificaciones();
                return entNotificacion;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}