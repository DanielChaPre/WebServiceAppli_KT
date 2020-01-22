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
        private string fecha_registro;
        private string  estatus;
        private string alias_red;
        private int tipo_usuario;
        private string ruta_imagen;

        [DataMember]
        public int Cve_Usuario { get => cve_usuario; set => cve_usuario = value; }
        [DataMember]
        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        [DataMember]
        public string Nombre_Usuario { get => nombre_usuario; set => nombre_usuario = value; }
        [DataMember]
        public string Contrasena { get => contrasena; set => contrasena = value; }
        [DataMember]
        public string Fecha_Registro { get => fecha_registro; set => fecha_registro = value; }
        [DataMember]
        public string Estatus { get => estatus; set => estatus = value; }
        [DataMember]
        public string Alias_Red { get => alias_red; set => alias_red = value; }
        [DataMember]
        public int Tipo_Usuario { get => tipo_usuario; set => tipo_usuario = value; }
        [DataMember]
        public string Ruta_Imagen { get => ruta_imagen; set => ruta_imagen = value; }
    }
}