using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class MediosEnvioClass
    {
        [DataMember]
        public int cveMedioEnvio { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string estatus { get; set; }
    }
}