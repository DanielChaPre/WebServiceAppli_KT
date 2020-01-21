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
        private int idAlumno;
        private string Nombre;
        private string ApellidoPaterno;
        private string ApellidoMaterno;
        private string CURP;
        private string Sexo;
        private string Calle;
        private string NumeroExterior;
        private string NumeroInterior;
        private string Email;
        private string Celular;
        private string Telefono;
        private int OtroCicloEnProceso;
        private string MotivoNoEstudiar1;
        private string MotivoNoEstudiar2;
        private string MotivoNoEstudiar3;
        private string MeGustariaEstudiar;
        private string FOLIOSUREDSU;
        private string FolioSUREMS;
        private string Password;
        private int SeguirEstudiando;
        private int idColonia;
        private int idPlantelEMS;
        private string ClavePlantelESEC;
        private int idCarreraES1;
        private int idCarreraES2;
        private int idCarreraES3;
        private string Nacionalidad;
        private string TEMP_CP;
        private int Paso;
        private string UID_Firebase;
        private string Actualizaciones;
        private string PregutaActual;
        private int Finalizo;
        private int TerminosAceptadso;
        private int idMunicipio;
        private int idPais;
        private string OtraColonia;
        private string idMunicipioPlantel;
        private string idPaisPlantel;
        private string OtroPlantel;
        private string FechaRegistro;
        private string EmailValido;

        [DataMember]
        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        [DataMember]
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        [DataMember]
        public string ApellidoPaterno1 { get => ApellidoPaterno; set => ApellidoPaterno = value; }
        [DataMember]
        public string ApellidoMaterno1 { get => ApellidoMaterno; set => ApellidoMaterno = value; }
        [DataMember]
        public string CURP1 { get => CURP; set => CURP = value; }
        [DataMember]
        public string Sexo1 { get => Sexo; set => Sexo = value; }
        [DataMember]
        public string Calle1 { get => Calle; set => Calle = value; }
        [DataMember]
        public string NumeroExterior1 { get => NumeroExterior; set => NumeroExterior = value; }
        [DataMember]
        public string NumeroInterior1 { get => NumeroInterior; set => NumeroInterior = value; }
        [DataMember]
        public string Email1 { get => Email; set => Email = value; }
        [DataMember]
        public string Celular1 { get => Celular; set => Celular = value; }
        [DataMember]
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        [DataMember]
        public int OtroCicloEnProceso1 { get => OtroCicloEnProceso; set => OtroCicloEnProceso = value; }
        [DataMember]
        public string MotivoNoEstudiar11 { get => MotivoNoEstudiar1; set => MotivoNoEstudiar1 = value; }
        [DataMember]
        public string MotivoNoEstudiar21 { get => MotivoNoEstudiar2; set => MotivoNoEstudiar2 = value; }
        [DataMember]
        public string MotivoNoEstudiar31 { get => MotivoNoEstudiar3; set => MotivoNoEstudiar3 = value; }
        [DataMember]
        public string MeGustariaEstudiar1 { get => MeGustariaEstudiar; set => MeGustariaEstudiar = value; }
        [DataMember]
        public string FOLIOSUREDSU1 { get => FOLIOSUREDSU; set => FOLIOSUREDSU = value; }
        [DataMember]
        public string FolioSUREMS1 { get => FolioSUREMS; set => FolioSUREMS = value; }
        [DataMember]
        public string Password1 { get => Password; set => Password = value; }
        [DataMember]
        public int SeguirEstudiando1 { get => SeguirEstudiando; set => SeguirEstudiando = value; }
        [DataMember]
        public int IdColonia { get => idColonia; set => idColonia = value; }
        [DataMember]
        public int IdPlantelEMS { get => idPlantelEMS; set => idPlantelEMS = value; }
        [DataMember]
        public string ClavePlantelESEC1 { get => ClavePlantelESEC; set => ClavePlantelESEC = value; }
        [DataMember]
        public int IdCarreraES1 { get => idCarreraES1; set => idCarreraES1 = value; }
        [DataMember]
        public int IdCarreraES2 { get => idCarreraES2; set => idCarreraES2 = value; }
        [DataMember]
        public int IdCarreraES3 { get => idCarreraES3; set => idCarreraES3 = value; }
        [DataMember]
        public string Nacionalidad1 { get => Nacionalidad; set => Nacionalidad = value; }
        [DataMember]
        public string TEMP_CP1 { get => TEMP_CP; set => TEMP_CP = value; }
        [DataMember]
        public int Paso1 { get => Paso; set => Paso = value; }
        [DataMember]
        public string UID_Firebase1 { get => UID_Firebase; set => UID_Firebase = value; }
        [DataMember]
        public string Actualizaciones1 { get => Actualizaciones; set => Actualizaciones = value; }
        [DataMember]
        public string PregutaActual1 { get => PregutaActual; set => PregutaActual = value; }
        [DataMember]
        public int Finalizo1 { get => Finalizo; set => Finalizo = value; }
        [DataMember]
        public int TerminosAceptadso1 { get => TerminosAceptadso; set => TerminosAceptadso = value; }
        [DataMember]
        public int IdMunicipio { get => idMunicipio; set => idMunicipio = value; }
        [DataMember]
        public int IdPais { get => idPais; set => idPais = value; }
        [DataMember]
        public string OtraColonia1 { get => OtraColonia; set => OtraColonia = value; }
        [DataMember]
        public string IdMunicipioPlantel { get => idMunicipioPlantel; set => idMunicipioPlantel = value; }
        [DataMember]
        public string IdPaisPlantel { get => idPaisPlantel; set => idPaisPlantel = value; }
        [DataMember]
        public string OtroPlantel1 { get => OtroPlantel; set => OtroPlantel = value; }
        [DataMember]
        public string FechaRegistro1 { get => FechaRegistro; set => FechaRegistro = value; }
        [DataMember]
        public string EmailValido1 { get => EmailValido; set => EmailValido = value; }
    }

}