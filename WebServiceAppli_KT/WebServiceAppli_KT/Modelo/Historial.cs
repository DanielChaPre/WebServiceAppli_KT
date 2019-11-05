using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Historial
    {
        [DataMember]
        public int cve_historial { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string cve_categoria { get; set; }
    }
}