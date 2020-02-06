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
        List<Notificaciones> lstentNotificacion;

        public ControladorNotificacion()
        {
            notificacionDAO = new NotificacionDAO();
        }

        public List<Notificaciones> Consultar(string cveUsuario)
        {
            try
            {
                lstentNotificacion = new List<Notificaciones>();
                lstentNotificacion = notificacionDAO.ConsultarNotificaciones(cveUsuario);
                return lstentNotificacion;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public bool EliminarNotificacion(string cveUsuario, string cveNotificacion)
        {
            return notificacionDAO.EliminarNotificacion(cveUsuario, cveNotificacion);
        }
    }
}