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
        public string ClavePlantel { get; set; }
        [DataMember]
        public string NombrePlantelES { get; set; }
        [DataMember]
        public string Subsistema { get; set; }
        [DataMember]
        public string Sostenimiento { get; set; }
        [DataMember]
        public string Municipio { get; set; }
        [DataMember]
        public int Activo { get; set; }
        [DataMember]
        public string ClaveInstitucion { get; set; }
        [DataMember]
        public string NombreInstitucionES { get; set; }
        [DataMember]
        public string OPD { get; set; }
        [DataMember]
        public string NivelAgrupado { get; set; }
        [DataMember]
        public string CarreraES { get; set; }
        [DataMember]
        public DetallePlantel detalle_plantel { get; set; }
    }
}