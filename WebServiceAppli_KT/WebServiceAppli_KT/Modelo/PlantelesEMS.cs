using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class PlantelesEMS
    {
        [DataMember]
        public int idPlantelesEMS { get; set; }
        [DataMember]
        public string ClavePlantel { get; set; }
        [DataMember]
        public string NombrePlantelEMS { get; set; }
        [DataMember]
        public string Subsistema { get; set; }
        [DataMember]
        public string Sostenimiento { get; set; }
        [DataMember]
        public string Control { get; set; }
        [DataMember]
        public string subcontrol { get; set; }
        [DataMember]
        public string Municipio { get; set; }
        [DataMember]
        public string Turno { get; set; }
        [DataMember]
        public string subsistemaSices { get; set; }
        [DataMember]
        public int Activo { get; set; }
    }
}