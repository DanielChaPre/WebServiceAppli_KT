using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Empleado
    {
        [DataMember]
        public int cve_empleado { get; set; }
        [DataMember]
        public string numero_empleado { get; set; }
        [DataMember]
        public string estatus { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public Persona persona { get; set; }
    }
}