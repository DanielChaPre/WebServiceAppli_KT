using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class DetallePlantel
    {
        [DataMember]
        public int cve_detalle_plantel { get; set; }
        [DataMember]
        public string url_vinculacion { get; set; }
        [DataMember]
        public string logo_plantel { get; set; }
        [DataMember]
        public string costos { get; set; }
        [DataMember]
        public string requisitos { get; set; }
        [DataMember]
        public string fechas { get; set; }
        [DataMember]
        public string reseña { get; set; }
        [DataMember]
        public string latitud { get; set; }
        [DataMember]
        public string longitud { get; set; }
        [DataMember]
        public string ubicacion { get; set; }
        [DataMember]
        public string nivel_estudio { get; set; }
        [DataMember]
        public int cve_imagen_plantel{ get; set; }
        [DataMember]
        public int cve_nivel_agrupado { get; set; }
        [DataMember]
        public int cve_nivel_estudio { get; set; }
        [DataMember]
        public PlantelesES PlantelesES { get; set; }
    }
}