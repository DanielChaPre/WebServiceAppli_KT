using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Estados
    {
        [DataMember]
        public int IdEstado { get; set; }
        [DataMember]
        public string NombreEstado { get; set; }
        [DataMember]
        public int idPais { get; set; }
    }
}