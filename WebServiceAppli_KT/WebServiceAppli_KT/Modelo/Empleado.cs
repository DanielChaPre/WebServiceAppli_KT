using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Empleado
    {
        private int cve_empleado;
        private string numero_empleado;
        private string estatus;
        private string fecha_registro;
        private Persona persona;

        [DataMember]
        public int Cve_Empleado { get => cve_empleado; set => cve_empleado = value; }
        [DataMember]
        public string Numero_Empleado { get => numero_empleado; set => numero_empleado = value; }
        [DataMember]
        public string Estatus { get => estatus; set => estatus = value; }
        [DataMember]
        public string Fecha_Registro { get => fecha_registro; set => fecha_registro = value; }
        [DataMember]
        public Persona Persona { get => persona; set => persona = value; }
    }
}