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
        private int cve_padre_familia;
        private int idAlumno;
        private string fecha_registro;
        private Persona persona;

        [DataMember]
        public int Cve_Padre_Familia { get => cve_padre_familia; set => cve_padre_familia = value; }
        [DataMember]
        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        [DataMember]
        public string Fecha_Registro { get => fecha_registro; set => fecha_registro = value; }
        [DataMember]
        public Persona Persona { get => persona; set => persona = value; }


    }
}