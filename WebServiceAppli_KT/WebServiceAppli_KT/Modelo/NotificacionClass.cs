using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{ 
    [DataContract]
    public class NotificacionClass
    {
        [DataMember]
        public int cveNotificaciones { get; set; }
        [DataMember]
        public string tipoNotificacion { get; set;}
        [DataMember]
        public string texto { get; set; }
        [DataMember]
        public string detalle { get; set; }
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
        public MediosEnvioClass medioDifusion { get; set; }
        [DataMember]
        public string colorSemaforizacion { get; set; }
        [DataMember]
        public DateTime fechaNotificacion { get; set; }
        [DataMember]
        public DateTime horaNotificacion { get; set; }

    }
}