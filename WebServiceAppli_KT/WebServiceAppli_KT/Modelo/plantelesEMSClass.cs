using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class PlantelesEMSClass
    {
        [DataMember]
        public int idPlantelesEMS { get; set; }
        [DataMember]
        public string clavePlantel { get; set; }
        [DataMember]
        public string nombrePlantelEMS { get; set; }
        [DataMember]
        public string subsistema { get; set; }
        [DataMember]
        public string sostenimiento { get; set; }
        [DataMember]
        public string control { get; set; }
        [DataMember]
        public string subcontrol { get; set; }
        [DataMember]
        public string municipio { get; set; }
        [DataMember]
        public string turno { get; set; }
        [DataMember]
        public string subsistemaSICES { get; set; }
        [DataMember]
        public int activo { get; set; }
    }
}