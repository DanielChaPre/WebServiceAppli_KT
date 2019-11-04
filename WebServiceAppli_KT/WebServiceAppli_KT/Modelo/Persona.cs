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
        public int cvePersona { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellidoPaterno { get; set; }
        [DataMember]
        public string apellidoMaterno { get; set; }
        [DataMember]
        public string rfc { get; set; }
        [DataMember]
        public string curp { get; set; }
        [DataMember]
        public string sexo { get; set; }
        [DataMember]
        public DateTime fechaNacimiento { get; set; }
        [DataMember]
        public string numeroTelefono { get; set; }
        [DataMember]
        public string correoElectronico { get; set; }
        [DataMember]
        public int estadoCivil { get; set; }
        [DataMember]
        public string nacionalidad { get; set; }
        [DataMember]
        public string municipio { get; set; }
        [DataMember]
        public DateTime fechaRegistro { get; set; }
        [DataMember]
        public string colonia { get; set; }
        [DataMember]
        public string perfil { get; set; }
    }
}