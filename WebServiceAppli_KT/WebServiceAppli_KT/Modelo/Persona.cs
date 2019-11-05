using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Persona
    {
        [DataMember]
        public int cve_persona { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellido_paterno { get; set; }
        [DataMember]
        public string apellido_materno { get; set; }
        [DataMember]
        public string rfc { get; set; }
        [DataMember]
        public string curp { get; set; }
        [DataMember]
        public string sexo { get; set; }
        [DataMember]
        public DateTime fecha_nacimiento { get; set; }
        [DataMember]
        public string numero_telefono { get; set; }
        [DataMember]
        public string correo_electronico { get; set; }
        [DataMember]
        public int estado_civil { get; set; }
        [DataMember]
        public string nacionalidad { get; set; }
        [DataMember]
        public string municipio { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public string colonia { get; set; }
        [DataMember]
        public int cve_grupo_seguridad_usuario { get; set; }
    }
}