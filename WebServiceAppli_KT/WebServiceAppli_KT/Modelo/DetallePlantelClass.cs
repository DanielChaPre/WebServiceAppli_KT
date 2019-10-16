using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class DetallePlantelClass
    {
        [DataMember]
        public int cveDetallePlantel { get; set; }
        [DataMember]
        public string urlVinculacion { get; set; }
        [DataMember]
        public string imagenPlantel { get; set; }
        [DataMember]
        public string logoPlantel { get; set; }
        [DataMember]
        public string costos { get; set; }
        [DataMember]
        public string requisitos { get; set; }
        [DataMember]
        public DateTime fechas { get; set; }
        [DataMember]
        public string reseña { get; set; }
        [DataMember]
        public string ubicacion { get; set; }
        [DataMember]
        public string latitud { get; set; }
        [DataMember]
        public string longitud { get; set; }
        [DataMember]
        public string nivelEstudio { get; set; }
    }
}