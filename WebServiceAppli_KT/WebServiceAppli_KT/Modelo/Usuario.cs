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
        public int cveUsuario { get; set; }
        [DataMember]
        public string nombreUsuario { get; set; }
        [DataMember]
        public string contrasenia { get; set; }
        [DataMember]
        public DateTime fechaRegistro { get; set; }
        [DataMember]
        public string  estatus { get; set; }
        [DataMember]
        public string rol { get; set; }
        [DataMember]
        public Persona persona { get; set; }
    }
}