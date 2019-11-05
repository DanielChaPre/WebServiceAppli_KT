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
        public string NombreCarreraES { get; set; }
        [DataMember]
        public PlantelesES PlantelES { get; set; }
        [DataMember]
        public int Activa { get; set; }
        [DataMember]
        public string ClaveCarrera { get; set; }
        [DataMember]
        public string CampoAmplio2016 { get; set; }
        [DataMember]
        public string CampoAmplioAnterior { get; set; }
        [DataMember]
        public string Nivel { get; set; }
        [DataMember]
        public string CampoEspecifico2016 { get; set; }
        [DataMember]
        public string CampoEspecificoAnterior { get; set; }

    }
}