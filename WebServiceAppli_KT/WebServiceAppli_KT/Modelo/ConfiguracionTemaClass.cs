using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class ConfiguracionTemaClass
    {
        [DataMember]
        public int cveConfiguracionTema { get; set; }
        [DataMember]
        public int configuracion { get; set; }
        [DataMember]
        public int portada { get; set; }
        [DataMember]
        public DateTime fechaRegistro { get; set; }
        [DataMember]
        public int color { get; set; }
        [DataMember]
        public string logo { get; set; }
        [DataMember]
        public DateTime fechaCambio { get; set; }
        [DataMember]
        public string estiloLetraPrincipal { get; set; }
        [DataMember]
        public string estiloLetraSecundario { get; set; }
    }
}