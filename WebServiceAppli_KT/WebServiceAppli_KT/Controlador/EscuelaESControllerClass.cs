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
        List<PlantelesESClass> lstPlanteles;

        public EscuelaESControllerClass()
        {
            escuelaESDAO = new EscuelaESDAOClass();
        }

        public List<PlantelesESClass> obtenerPlanteles()
        {
            try
            {
                lstPlanteles = new List<PlantelesESClass>();
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