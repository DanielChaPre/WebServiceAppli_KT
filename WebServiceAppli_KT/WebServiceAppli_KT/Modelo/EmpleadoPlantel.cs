using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class EmpleadoPlantel
    {
        private int cve_empleado_plantel;
        private int idPlantelesES;
        private int tipo;
        private DateTime fecha_registro;
        private Persona persona;

        [DataMember]
        public int Cve_Empleado_Plantel { get => cve_empleado_plantel; set => cve_empleado_plantel = value; }
        [DataMember]
        public int IdPlantelesES { get => idPlantelesES; set => idPlantelesES = value; }
        [DataMember]
        public int Tipo { get => tipo; set => tipo = value; }
        [DataMember]
        public DateTime Fecha_Registro { get => fecha_registro; set => fecha_registro = value; }
        [DataMember]
        public Persona Persona { get => persona; set => persona = value; }
    }
}