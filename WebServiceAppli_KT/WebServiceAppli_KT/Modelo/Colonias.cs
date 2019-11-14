using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Colonias
    {
        [DataMember]
        public int idColonia { get; set; }
        [DataMember]
        public string NombreColonia { get; set; }
        [DataMember]
        public string CP { get; set; }
        [DataMember]
        public int idMunicipio { get; set; }
    }
}