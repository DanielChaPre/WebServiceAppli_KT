﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador.Suredsu
{
    public class ControladorDireccion
    {
        List<Colonias> lst_colonias;
        List<Estados> lst_estados;
        List<Municipios> lst_municipios;
        List<Paises> lst_paises;
        ColoniasDAO coloniasDAO;
        EstadosDAO estadosDAO;
        MunicipiosDAO municipiosDAO;
        PaisesDAO paisesDAO;

        public ControladorDireccion()
        {
            coloniasDAO = new ColoniasDAO();
            estadosDAO = new EstadosDAO();
            municipiosDAO = new MunicipiosDAO();
            paisesDAO = new PaisesDAO();
        }

        public List<Colonias> ConsultarColonia(string cp)
        {
            try
            {
                lst_colonias = new List<Colonias>();
                lst_colonias = coloniasDAO.ConsultarColonia(cp);
                return lst_colonias;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public int BuscarColonia(string colonia)
        {
            return coloniasDAO.BuscarColonia(colonia);
        }

        public List<Estados> ConsultarEstados()
        {
            try
            {
                lst_estados = new List<Estados>();
                lst_estados = estadosDAO.ConsultarEstados();
                return lst_estados;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<Municipios> ConsultarTodosMunicipios()
        {
            try
            {
                return municipiosDAO.ObtenerTodosMunicipios();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }


        public List<Municipios> ConsultarMunicipios(string estado)
        {
            try
            {
                lst_municipios = new List<Municipios>();
                lst_municipios = municipiosDAO.ObtenerMunicipios(estado);
                return lst_municipios;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<Paises> ConsultarPaises()
        { 
            try
            {
                lst_paises = new List<Paises>();
                lst_paises = paisesDAO.ObtenerPaises();
                return lst_paises;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}