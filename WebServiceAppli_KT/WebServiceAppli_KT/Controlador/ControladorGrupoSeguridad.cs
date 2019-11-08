using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class ControladorGrupoSeguridad
    {
        GrupoSeguridadDAO grupo_seguridadDAO;
        List<GrupoSeguridad> lstgrupoSeguridad;

        public List<GrupoSeguridad> ConsultarAlumno()
        {
            try
            {
                lstgrupoSeguridad = new List<GrupoSeguridad>();
                grupo_seguridadDAO = new GrupoSeguridadDAO();
                lstgrupoSeguridad = grupo_seguridadDAO.ObtenerGrupos();
                return lstgrupoSeguridad;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}