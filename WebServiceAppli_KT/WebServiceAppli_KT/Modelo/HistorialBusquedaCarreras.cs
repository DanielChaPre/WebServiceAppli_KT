using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class HistorialBusquedaClass
    {
        [DataMember]
        public int cveHistorialBusqueda { get; set; }
        [DataMember]
        public string usuario { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
    }
}