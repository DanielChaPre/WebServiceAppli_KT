using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos.Applikt;

namespace WebServiceAppli_KT.Controlador.Applikt
{
    public class ControladorHistorialBusquedaCarrera
    {
        HistorialBusquedaCarreraDAO historialBusquedaCarreraDAO;

        public ControladorHistorialBusquedaCarrera()
        {
            historialBusquedaCarreraDAO = new HistorialBusquedaCarreraDAO();
        }

        public bool AgregarBusquedaCarrera(string cveUsuario, string idCarrera)
        {
            return historialBusquedaCarreraDAO.AgregarHistorialCarrera(cveUsuario, idCarrera);
        }

        public bool AgregarHistorialVisita(string cveUsuario)
        {
            return historialBusquedaCarreraDAO.AgregarHistorialVisita(cveUsuario);
        }
    }
}