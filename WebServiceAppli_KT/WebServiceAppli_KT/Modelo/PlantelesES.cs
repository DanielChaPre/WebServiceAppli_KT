using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class PlantelesES
    {
        [DataMember]
        public int idPlantelesES { get; set; }
        [DataMember]
        public string clavePlantel { get; set; }
        [DataMember]
        public string nombrePlantelES { get; set; }
        [DataMember]
        public string subsistema { get; set; }
        [DataMember]
        public string sostenimiento { get; set; }
        [DataMember]
        public string municipio { get; set; }
        [DataMember]
        public string claveInstitucion { get; set; }
        [DataMember]
        public string nombreInstitucionEs { get; set; }
        [DataMember]
        public string OPD { get; set; }
        [DataMember]
        public int activo { get; set; }
        [DataMember]
        public string nivelAgrupado { get; set; }
        [DataMember]
        public DetallePlantel detallePlantel { get; set; }
    }
}