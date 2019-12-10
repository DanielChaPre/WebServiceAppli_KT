using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int cve_usuario { get; set; }
        [DataMember]
        public int idAlumno { get; set; }
        [DataMember]
        public string usuario { get; set; }
        [DataMember]
        public string contrasena { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public string  estatus { get; set; }
        [DataMember]
        public string alias_red { get; set; }
    }
}