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
        CarrerasDAO carrerasDAO;
        MunicipiosDAO municipiosDAO;
        List<PlantelesES> lstPlanteles;
        PlantelesES plantelES;

        public ControladorEscuelasES()
        {
            escuelaESDAO = new EscuelaESDAO();
        }

        public List<DetallePlantel> ObtenerPlanteles()
        {
            try
            {
                lstPlanteles = new List<PlantelesES>();
                return escuelaESDAO.ObtenerPlnateles(); ;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PlantelesES BuscarPlantelMunicipio(string municipio)
        {
            plantelES = new PlantelesES();
            plantelES = escuelaESDAO.BuscarPlantelMunicipio(municipiosDAO.BuscarMunicipio(municipio));
            return plantelES;
        }

        public PlantelesES BuscarPlantelCarrera(string carrera)
        {
            plantelES = new PlantelesES();
            plantelES = escuelaESDAO.BuscarPlantelId(carrerasDAO.BuscarPlantelesId(carrera));
            return plantelES;
        }

        public PlantelesES BuscarPlantel(string plantel)
        {
            plantelES = new PlantelesES();
            plantelES = escuelaESDAO.BuscarPlantel(plantel);
            return plantelES;
        }

        public PlantelesEMS BuscarPlantelEMS(int idplantel)
        {
            var plantelEMS = new PlantelesEMS();
            plantelEMS = escuelaESDAO.BuscarPlantelIDPlantelEMS(idplantel);
            return plantelEMS;
        }

        public DetallePlantel BuscarDetallePlantel(string idPlantel)
        {

            return escuelaESDAO.BuscarDetallePlantel(idPlantel);
        }

    }
}