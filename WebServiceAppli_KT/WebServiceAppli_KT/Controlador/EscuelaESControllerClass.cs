using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class EscuelaESControllerClass
    {
        EscuelaESDAOClass escuelaESDAO;
        List<PlantelesES> lstPlanteles;

        public EscuelaESControllerClass()
        {
            escuelaESDAO = new EscuelaESDAOClass();
        }

        public List<PlantelesES> obtenerPlanteles()
        {
            try
            {
                lstPlanteles = new List<PlantelesES>();
                lstPlanteles = escuelaESDAO.obtenerPlnateles();
                return lstPlanteles;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}