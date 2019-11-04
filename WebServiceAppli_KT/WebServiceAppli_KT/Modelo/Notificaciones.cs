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
        public int cveNotificaciones { get; set; }
        [DataMember]
        public string tipoNotificacion { get; set;}
        [DataMember]
        public string texto { get; set; }
        [DataMember]
        public string responsable { get; set; }
        [DataMember]
        public string categorizacion { get; set;}
        [DataMember]
        public string titulo { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string audiencia { get; set; }
        [DataMember]
        public MediosEnvio medioDifusion { get; set; }
        [DataMember]
        public string colorSemaforizacion { get; set; }
      /*  [DataMember]
        public string fechaNotificacion { get; set; }
        [DataMember]
        public string horaNotificacion { get; set; }*/

    }
}