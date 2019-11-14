using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Municipios
    {
        [DataMember]
        public int idMunicipio { get; set; }
        [DataMember]
        public string NombreMunicipio { get; set; }
        [DataMember]
        public int idEstado { get; set; }
    }
}