using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador.Applikt
{
    public class ControladorHistorial
    {
        public List<Historial> ConsultarHistorial(string cveUsuario)
        {
            var historialDao =new HistorialDAO();
            return historialDao.ConsultarHistorial(cveUsuario);
        }
    }
}