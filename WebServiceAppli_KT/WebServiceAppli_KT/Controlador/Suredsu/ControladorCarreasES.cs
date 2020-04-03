using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class ControladorCarreasES
    {
        CarrerasDAO carrerasDAO;
        List<CarrerasES> lstCarreras;

        public ControladorCarreasES()
        {
            carrerasDAO = new CarrerasDAO();
        }

        public List<CarrerasES> ObtenerCarreras()
        {
            try
            {
                lstCarreras = new List<CarrerasES>();
                lstCarreras = carrerasDAO.ObtenerCarreras();
                return lstCarreras;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<DetalleCarreraPlantel> ObtenerDetalleCarreras()
        {
                return carrerasDAO.ObtenerDetalleCarreras();
        }

        public List<CarrerasES> ObtenerCarrerasPlantel(string idPlantelES)
        {
            return carrerasDAO.ObtenerCarrerasPlantel(idPlantelES);
        }
    }
}