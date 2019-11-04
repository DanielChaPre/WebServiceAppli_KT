using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class CarrerasControllerClass
    {
        CarrerasDAOClass carrerasDAO;
        List<CarrerasES> lstCarreras;

        public CarrerasControllerClass()
        {
            carrerasDAO = new CarrerasDAOClass();
        }

        public List<CarrerasES> obtenerCarreras()
        {
            try
            {
                lstCarreras = new List<CarrerasES>();
                lstCarreras = carrerasDAO.obtenerCarreras();
                return lstCarreras;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

    }
}