using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class ImagenPlantel
    {
        [DataMember]
        public int cve_detalle_plantel { get; set; }
        [DataMember]
        public int cve_imagen_plantel { get; set; }
        [DataMember]
        public int imagen_principal { get; set; }
        [DataMember]
        public string ruta { get; set; }
        [DataMember]
        public string descripcion { get; set; }

    }
}