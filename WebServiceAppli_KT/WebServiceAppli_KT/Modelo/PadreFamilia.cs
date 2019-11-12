using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class PadreFamilia
    {
        [DataMember]
        public int cve_padre_familia { get; set; }
        [DataMember]
        public int id_alumno { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public Persona persona { get; set; }
        [DataMember]
        public int idAlumno { get; set; }
        [DataMember]
        public Usuario usuario { get; set; }
    }
}