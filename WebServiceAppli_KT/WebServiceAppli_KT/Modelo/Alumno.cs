using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceAppli_KT.Modelo
{
    [DataContract]
    public class Alumno
    {
        [DataMember]
        public int idAlumno { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string CURP { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string Calle { get; set; }
        [DataMember]
        public string NumeroExterior { get; set; }
        [DataMember]
        public string NumeroInterior { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Celular { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public int OtroCicloEnProceso { get; set; }
        [DataMember]
        public string MotivoNoEstudiar1 { get; set; }
        [DataMember]
        public string MotivoNoEstudiar2 { get; set; }
        [DataMember]
        public string MotivoNoEstudiar3 { get; set; }
        [DataMember]
        public string MeGustariaEstudiar { get; set; }
        [DataMember]
        public string FOLIOSUREDSU { get; set; }
        [DataMember]
        public string FolioSUREMS { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int SeguirEstudiando { get; set; }
        [DataMember]
        public int idColonia { get; set; }
        [DataMember]
        public int idPlantelEMS { get; set; }
        [DataMember]
        public string ClavePlantelESEC { get; set; }
        [DataMember]
        public int idCarreraES1 { get; set; }
        [DataMember]
        public int idCarreraES2 { get; set; }
        [DataMember]
        public int idCarreraES3 { get; set; }
        [DataMember]
        public string Nacionalidad { get; set; }
        [DataMember]
        public string TEMP_CP { get; set; }
        [DataMember]
        public int Paso { get; set; }
        [DataMember]
        public string UID_Firebase { get; set; }
        [DataMember]
        public string Actualizaciones { get; set; }
        [DataMember]
        public string PregutaActual { get; set; }
        [DataMember]
        public int Finalizo { get; set; }
        [DataMember]
        public int TerminosAceptadso { get; set; }
        [DataMember]
        public int idMunicipio { get; set; }
        [DataMember]
        public int idPais { get; set; }
        [DataMember]
        public string OtraColonia { get; set; }
        [DataMember]
        public string idMunicipioPlantel { get; set; }
        [DataMember]
        public string idPaisPlantel { get; set; }
        [DataMember]
        public string OtroPlantel { get; set; }
        [DataMember]
        public string FechaRegistro { get; set; }
        [DataMember]
        public string EmailValido { get; set; }
    }
}