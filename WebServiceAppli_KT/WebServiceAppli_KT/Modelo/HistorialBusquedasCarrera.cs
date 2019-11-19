using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class HistorialBusquedasCarrera
    {
        [DataMember]
        public int cve_historial_busqueda_carrera { get; set; }
        [DataMember]
        public string cve_usuario { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public int idCarreraES { get; set; }
    }
}