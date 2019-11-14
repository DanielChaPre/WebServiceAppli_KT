using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Paises
    {
        [DataMember]
        public int IdPais { get; set; }
        [DataMember]
        public string NombrePais { get; set; }
    }
}