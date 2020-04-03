using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Resultados
    {
        [DataMember]
        public int idAlumno;
        [DataMember]
        public string aptitud1;
        [DataMember]
        public string aptitud2;
        [DataMember]
        public string aptitud3;
    }
}