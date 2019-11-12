using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class ControladorEscuelasES
    {
        EscuelaESDAO escuelaESDAO;
        List<PlantelesES> lstPlanteles;

        public ControladorEscuelasES()
        {
            escuelaESDAO = new EscuelaESDAO();
        }

        public List<PlantelesES> ObtenerPlanteles()
        {
            try
            {
                lstPlanteles = new List<PlantelesES>();
                lstPlanteles = escuelaESDAO.ObtenerPlnateles();
                return lstPlanteles;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}