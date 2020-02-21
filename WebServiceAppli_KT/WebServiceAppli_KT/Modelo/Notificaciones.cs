using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{ 
    [DataContract]
    public class Notificaciones
    {
        [DataMember]
        public int cve_notificacion { get; set; }
        [DataMember]
        public int estatus { get; set; }
        [DataMember]
        public string texto { get; set;}
        [DataMember]
        public string responsable { get; set; }
        [DataMember]
        public string cve_categoria { get; set; }
        [DataMember]
        public string titulo { get; set;}
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public int cve_tipo_notificacion { get; set; }
        [DataMember]
        public string fecha_notificacion { get; set; }
        [DataMember]
        public string hora_notificacion { get; set; }
    }
}