using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class EmpleadoPlantel
    {
        [DataMember]
        public int cve_empleado_plantel { get; set; }
        [DataMember]
        public int idPlantelesES { get; set; }
        [DataMember]// 1.- directivo, 2.- Profesor
        public int tipo { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public Persona persona { get; set; }
    }
}