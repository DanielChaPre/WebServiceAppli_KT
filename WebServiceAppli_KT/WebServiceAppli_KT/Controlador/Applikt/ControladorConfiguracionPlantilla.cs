using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Datos.Applikt;

namespace WebServiceAppli_KT.Controlador.Applikt
{
    public class ControladorConfiguracionPlantilla
    {
        ConfiguracionPlantillasDAO configuracionPlantillasDAO;
        public ControladorConfiguracionPlantilla()
        {
            configuracionPlantillasDAO = new ConfiguracionPlantillasDAO();

        }

        public List<string> ConsultarPlantillasUsuario(string cveUsuario)
        {
            return configuracionPlantillasDAO.ConfigurarPlantillaUsuarios(cveUsuario);
        }

        public List<string> ConsultarPlantillasUsuarioAlumno(string idAlumno)
        {
            return configuracionPlantillasDAO.ConfigurarPlantillaUsuariosAlumno(idAlumno);
        }

        public List<string> ConsultarTema()
        {
            return configuracionPlantillasDAO.ObtenerColores();
        }
    }
}