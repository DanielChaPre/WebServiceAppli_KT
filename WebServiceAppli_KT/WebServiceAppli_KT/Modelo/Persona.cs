using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Persona
    {

        private int cve_persona;
        private string nombre;
        private string apellido_paterno;
        private string apellido_materno;
        private string rfc;
        private string curp;
        private string sexo;
        private string fecha_nacimiento;
        private string numero_telefono;
        private int estado_civil;
        private string nacionalidad;
        private string municipio;
        private int idColonia;
        private Usuario usuario;

        [DataMember]
        public int Cve_Persona { get => cve_persona; set => cve_persona = value; } 
        [DataMember]
        public string Nombre { get => nombre; set => nombre = value; }
        [DataMember]
        public string Apellido_Paterno { get => apellido_paterno; set => apellido_paterno = value; }
        [DataMember]
        public string Apellido_Materno { get => apellido_materno; set => apellido_materno = value; }
        [DataMember]
        public string RFC { get => rfc; set => rfc = value; }
        [DataMember]
        public string CURP { get => curp; set => curp = value; }
        [DataMember]
        public string Sexo { get => sexo; set => sexo = value; }
        [DataMember]
        public string Fecha_Nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; } 
        [DataMember]
        public string Numero_Telefono { get => numero_telefono; set => numero_telefono = value; }
        [DataMember]
        public int Estado_Civil { get => estado_civil; set => estado_civil = value; }
        [DataMember]
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        [DataMember]
        public string Municipio { get => municipio; set => municipio = value; }
        [DataMember]
        public int IdColonia { get => idColonia; set => idColonia = value; }
        [DataMember]
        public Usuario Usuario { get => usuario; set => usuario = value; }
    }
}