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
        Persona persona;

        public ControladorAlumno()
        {
            alumnoDAO = new AlumnoDAO();
        }

        public bool GuardarAlumno(Persona persona)
        {
            try
            {
                if (!alumnoDAO.GuardarAlummo(persona))
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

        public bool EliminarAlumno(Persona persona)
        {
            try
            {
                if (!alumnoDAO.GuardarAlummo(persona))
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

        public bool ModificarAlumno(Persona persona)
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

        public Persona ConsultarAlumno(int cve_usuario)
        {
            try
            {
                return persona;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}