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
        public string nombre_usuario { get; set; }
        [DataMember]
        public string contraseña { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public string  estatus { get; set; }
        [DataMember]
        public string rol { get; set; }
        [DataMember]
        public Persona persona { get; set; }
    }
}