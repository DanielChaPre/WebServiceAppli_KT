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
        List<CarrerasESClass> lstCarreras;

        public CarrerasControllerClass()
        {
            carrerasDAO = new CarrerasDAOClass();
        }

        public List<CarrerasESClass> obtenerCarreras()
        {
            try
            {
                lstCarreras = new List<CarrerasESClass>();
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