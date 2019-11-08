using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class ControladorAlumno
    {
        AlumnoDAO alumnoDAO;
        Alumno alumno;

        public ControladorAlumno()
        {
            alumnoDAO = new AlumnoDAO();
        }

        public bool GuardarAlumno(Alumno alumno)
        {
            try
            {
                if (!alumnoDAO.GuardarAlummo(alumno))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarAlumno()
        {
            try
            {
                if (!alumnoDAO.GuardarAlummo(alumno))
                { 
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarAlumno()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Alumno ConsultarAlumno()
        {
            try
            {
                return alumno;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}