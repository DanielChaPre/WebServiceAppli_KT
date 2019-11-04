using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class CarrerasES
    {
        [DataMember]
        public int idCarreraES { get; set; }
        [DataMember]
        public string nombreCarreraES { get; set; }
        [DataMember]
        public PlantelesES plantelES { get; set; }
        [DataMember]
        public int activa { get; set; }
        [DataMember]
        public string claveCarrera { get; set; }
        [DataMember]
        public string campoAmplio2016 { get; set; }
        [DataMember]
        public string campoAmplioAnterior { get; set; }
        [DataMember]
        public string nivel { get; set; }
        [DataMember]
        public string campoEspecifico2016 { get; set; }
        [DataMember]
        public string campoEspecificoAnterior { get; set; }

    }
}