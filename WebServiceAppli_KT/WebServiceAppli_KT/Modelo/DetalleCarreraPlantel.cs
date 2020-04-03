using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class DetalleCarreraPlantel
    {
        [DataMember]
        public int cve_detalle_carrera_plantel; 
        [DataMember]
        public int idCarreraES;
        [DataMember]
        public string perfil_ingreso;
        [DataMember]
        public string perfil_egreso;
        [DataMember]
        public string sector_productivo;
        [DataMember]
        public string RVOE;
        [DataMember]
        public string modalidad;
             [DataMember]
        public string duracion;
             [DataMember]
        public string costos;
             [DataMember]
        public int cve_detalle_plantel ;
    }
}