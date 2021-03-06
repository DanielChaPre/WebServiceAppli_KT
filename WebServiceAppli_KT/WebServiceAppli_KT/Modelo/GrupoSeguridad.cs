﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class GrupoSeguridad
    {
        [DataMember]
        public int cve_grupo_seguridad { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public string estatus { get; set; }
        [DataMember]
        public string fecha_registro { get; set; }
        [DataMember]
        public int cve_usuario { get; set; }
    }
}