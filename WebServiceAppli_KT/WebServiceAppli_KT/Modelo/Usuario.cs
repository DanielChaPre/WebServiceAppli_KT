using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Usuario
    {
        private int cve_usuario;
        private int idAlumno;
        private string nombre_usuario;
        private string contrasena;
        private DateTime fecha_registro;
        private string  estatus;
        private string alias_red;

        [DataMember]
        public int Cve_Usuario { get => cve_usuario; set => cve_usuario = value; }
        [DataMember]
        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        [DataMember]
        public string Nombre_Usuario { get => nombre_usuario; set => nombre_usuario = value; }
        [DataMember]
        public string Contrasena { get => contrasena; set => contrasena = value; }
        [DataMember]
        public DateTime Fecha_Registro { get => fecha_registro; set => fecha_registro = value; }
        [DataMember]
        public string Estatus { get => estatus; set => estatus = value; }
        [DataMember]
        public string Alias_Red { get => alias_red; set => alias_red = value; }
    }
}