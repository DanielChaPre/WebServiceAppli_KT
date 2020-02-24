using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class AlumnoDAO
    {
        // ConexionAppliktDAO conexion = new ConexionAppliktDAO();
        ConexionSuredsuDAO conexion = new ConexionSuredsuDAO();
        MySqlConnection con;
        Alumno alumno;

        public List<int> GuardarAlummo(Alumno alumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Insert into alumnos( Nombre, ApellidoPaterno , ApellidoMaterno, CURP ,Sexo ,Calle ," +
                "NumeroExterior , NumeroInterior , Email ,Celular ,Telefono , OtroCicloEnProceso," +
                "MotivoNoEstudiar1, MotivoNoEstudiar2, MotivoNoEstudiar3 , MeGustariaEstudiar , FOLIOSUREDSU ," +
                "FolioSUREMS ,Password ,SeguirEstudiando, idColonia,idPlantelEMS , ClavePlantelESEC,idCarreraES1 , idCarreraES2," +
                "idCarreraES3 , Nacionalidad , TEMP_CP ,Paso , UID_Firebase, Actualizaciones ," +
                "PreguntaActual ,Finalizo , TerminosAceptados , idMunicipio =, idPais , OtraColonia , " +
                "idMunicipioPlantel ,idPaisPlantel, OtroPlantel ,FechaRegistro , EmailValidado) " +
                "values ( @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Curp, @Sexo, @Calle," +
                "@NumeroExterior, @NumeroInterior, @Email,@Celular, @Telefono, @OtroCicloEnProceso," +
                "@MotivoNoEstudiar1,  @MotivoNoEstudiar2, @MotivoNoEstudiar3, @MeGustaEstudiar, @FOLIOSUREDSU," +
                "@FolioSUREMS,@Password,@SeguirEstudiando, @idColonia, @idPlantelEMS, @ClavePlantelESEC,@idCarreraES1," +
                " @idCarreraES2, @idCarreraES3,@Nacionalidad, @TEMP_CP, @Paso, @UID_Firebase, @Actualizaciones," +
                " @PreguntaActual,@Finalizo, @TerminosAceptados, @idMunicipio,  @idPais, @OtraColonia, @idMunicipioPlantel," +
                " @idPaisPlantel, @OtroPlantel, @FechaRegistro, @EmailValidado)";
                cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre1);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", alumno.ApellidoPaterno1);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", alumno.ApellidoMaterno1);
                cmd.Parameters.AddWithValue("@Curp", alumno.CURP1);
                cmd.Parameters.AddWithValue("@Sexo", alumno.Sexo1);
                cmd.Parameters.AddWithValue("@Calle", alumno.Calle1);
                cmd.Parameters.AddWithValue("@NumeroExterior", alumno.NumeroExterior1);
                cmd.Parameters.AddWithValue("@NumeroInterior", alumno.NumeroInterior1);
                cmd.Parameters.AddWithValue("@Email", alumno.Email1);
                cmd.Parameters.AddWithValue("@Celular", alumno.Celular1);
                cmd.Parameters.AddWithValue("@Telefono", alumno.Telefono1);
                cmd.Parameters.AddWithValue("@OtroCicloEnProceso", alumno.OtroCicloEnProceso1);
                cmd.Parameters.AddWithValue("@MotivoNoEstudiar1", alumno.MotivoNoEstudiar11);
                cmd.Parameters.AddWithValue("@MotivoNoEstudiar2", alumno.MotivoNoEstudiar21);
                cmd.Parameters.AddWithValue("@MotivoNoEstudiar3", alumno.MotivoNoEstudiar31);
                cmd.Parameters.AddWithValue("@MeGustaEstudiar", alumno.MeGustariaEstudiar1);
                cmd.Parameters.AddWithValue("@FOLIOSUREDSU", alumno.FOLIOSUREDSU1);
                cmd.Parameters.AddWithValue("@FolioSUREMS", alumno.FolioSUREMS1);
                cmd.Parameters.AddWithValue("@Password", alumno.Password1);
                cmd.Parameters.AddWithValue("@SeguirEstudiando", alumno.SeguirEstudiando1);
                cmd.Parameters.AddWithValue("@idColonia", alumno.Colonias.idColonia);
                cmd.Parameters.AddWithValue("@idPlantelEMS", alumno.IdPlantelEMS);
                cmd.Parameters.AddWithValue("@ClavePlantelESEC", alumno.ClavePlantelESEC1);
                cmd.Parameters.AddWithValue("@idCarreraES1", alumno.IdCarreraES1);
                cmd.Parameters.AddWithValue("@idCarreraES2", alumno.IdCarreraES2);
                cmd.Parameters.AddWithValue("@idCarreraES3", alumno.IdCarreraES3);
                cmd.Parameters.AddWithValue("@Nacionalidad", alumno.Nacionalidad1);
                cmd.Parameters.AddWithValue("@TEMP_CP", alumno.TEMP_CP1);
                cmd.Parameters.AddWithValue("@Paso", alumno.Paso1);
                cmd.Parameters.AddWithValue("@UID_Firebase", alumno.UID_Firebase1);
                cmd.Parameters.AddWithValue("@Actualizaciones", alumno.Actualizaciones1);
                cmd.Parameters.AddWithValue("@PreguntaActual", alumno.PregutaActual1);
                cmd.Parameters.AddWithValue("@Finalizo", alumno.Finalizo1);
                cmd.Parameters.AddWithValue("@TerminosAceptados", alumno.TerminosAceptadso1);
                cmd.Parameters.AddWithValue("@idMunicipio", alumno.Municipios.idMunicipio);
                cmd.Parameters.AddWithValue("@idPais", alumno.IdPais);
                cmd.Parameters.AddWithValue("@OtraColonia", alumno.OtraColonia1);
                cmd.Parameters.AddWithValue("@idMunicipioPlantel", alumno.IdMunicipioPlantel);
                cmd.Parameters.AddWithValue("@idPaisPlantel", alumno.IdPaisPlantel);
                cmd.Parameters.AddWithValue("@OtroPlantel", alumno.OtroPlantel1);
                cmd.Parameters.AddWithValue("@FechaRegistro", alumno.FechaRegistro1);
                cmd.Parameters.AddWithValue("@EmailValidado", alumno.EmailValido1);
                cmd.Parameters.AddWithValue("@idAlumno", alumno.IdAlumno);
                con.Open();
                cmd.ExecuteNonQuery();
                return null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public bool EliminarAlumno(int idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Delete from Alumno where idAlumno = @idAlumno";
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool ModificarAlumno(Alumno alumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE alumnos SET Nombre = @Nombre, ApellidoPaterno = @ApellidoPaterno," +
                " ApellidoMaterno = @ApellidoMaterno, CURP = @Curp,Sexo = @Sexo,Calle = @Calle," +
                "NumeroExterior = @NumeroExterior, NumeroInterior = @NumeroInterior," +
                "Email = @Email,Celular = @Celular,Telefono = @Telefono, OtroCicloEnProceso = @OtroCicloEnProceso," +
                "MotivoNoEstudiar1 = @MotivoNoEstudiar1, MotivoNoEstudiar2 = @MotivoNoEstudiar2," +
                "MotivoNoEstudiar3 = @MotivoNoEstudiar3, MeGustariaEstudiar = @MeGustaEstudiar, FOLIOSUREDSU = @FOLIOSUREDSU," +
                "FolioSUREMS = @FolioSUREMS,Password = @Password,SeguirEstudiando = @SeguirEstudiando, " +
                "idColonia =@idColonia,idPlantelEMS = @idPlantelEMS," +
                "ClavePlantelESEC = @ClavePlantelESEC,idCarreraES1 = @idCarreraES1, idCarreraES2 = @idCarreraES2," +
                "idCarreraES3 = @idCarreraES3, Nacionalidad = @Nacionalidad, TEMP_CP = @TEMP_CP,Paso = @Paso," +
                " UID_Firebase = @UID_Firebase, Actualizaciones = @Actualizaciones," +
                "PreguntaActual = @PreguntaActual,Finalizo = @Finalizo, TerminosAceptados = @TerminosAceptados," +
                "idMunicipio = @idMunicipio, idPais = @idPais, OtraColonia = @OtraColonia, " +
                "idMunicipioPlantel = @idMunicipioPlantel,idPaisPlantel = @idPaisPlantel," +
                "OtroPlantel = @OtroPlantel,FechaRegistro = @FechaRegistro, EmailValidado =@EmailValidado " +
                "WHERE idAlumno = @idAlumno";
                cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre1);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", alumno.ApellidoPaterno1);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", alumno.ApellidoMaterno1);
                cmd.Parameters.AddWithValue("@Curp", alumno.CURP1);
                cmd.Parameters.AddWithValue("@Sexo", alumno.Sexo1);
                cmd.Parameters.AddWithValue("@Calle", alumno.Calle1);
                cmd.Parameters.AddWithValue("@NumeroExterior", alumno.NumeroExterior1);
                cmd.Parameters.AddWithValue("@NumeroInterior", alumno.NumeroInterior1);
                cmd.Parameters.AddWithValue("@Email", alumno.Email1);
                cmd.Parameters.AddWithValue("@Celular", alumno.Celular1);
                cmd.Parameters.AddWithValue("@Telefono", alumno.Telefono1);
                cmd.Parameters.AddWithValue("@OtroCicloEnProceso", alumno.OtroCicloEnProceso1);
                cmd.Parameters.AddWithValue("@MotivoNoEstudiar1", alumno.MotivoNoEstudiar11);
                cmd.Parameters.AddWithValue("@MotivoNoEstudiar2", alumno.MotivoNoEstudiar21);
                cmd.Parameters.AddWithValue("@MotivoNoEstudiar3", alumno.MotivoNoEstudiar31);
                cmd.Parameters.AddWithValue("@MeGustaEstudiar", alumno.MeGustariaEstudiar1);
                cmd.Parameters.AddWithValue("@FOLIOSUREDSU", alumno.FOLIOSUREDSU1);
                cmd.Parameters.AddWithValue("@FolioSUREMS", alumno.FolioSUREMS1);
                cmd.Parameters.AddWithValue("@Password", alumno.Password1);
                cmd.Parameters.AddWithValue("@SeguirEstudiando", alumno.SeguirEstudiando1);
                cmd.Parameters.AddWithValue("@idColonia", alumno.Colonias.idColonia);
                cmd.Parameters.AddWithValue("@idPlantelEMS", alumno.IdPlantelEMS);
                cmd.Parameters.AddWithValue("@ClavePlantelESEC", alumno.ClavePlantelESEC1);
                cmd.Parameters.AddWithValue("@idCarreraES1", alumno.IdCarreraES1);
                cmd.Parameters.AddWithValue("@idCarreraES2", alumno.IdCarreraES2);
                cmd.Parameters.AddWithValue("@idCarreraES3", alumno.IdCarreraES3);
                cmd.Parameters.AddWithValue("@Nacionalidad", alumno.Nacionalidad1);
                cmd.Parameters.AddWithValue("@TEMP_CP", alumno.TEMP_CP1);
                cmd.Parameters.AddWithValue("@Paso", alumno.Paso1);
                cmd.Parameters.AddWithValue("@UID_Firebase", alumno.UID_Firebase1);
                cmd.Parameters.AddWithValue("@Actualizaciones", alumno.Actualizaciones1);
                cmd.Parameters.AddWithValue("@PreguntaActual", alumno.PregutaActual1);
                cmd.Parameters.AddWithValue("@Finalizo", alumno.Finalizo1);
                cmd.Parameters.AddWithValue("@TerminosAceptados", alumno.TerminosAceptadso1);
                cmd.Parameters.AddWithValue("@idMunicipio", alumno.Municipios.idMunicipio);
                cmd.Parameters.AddWithValue("@idPais", alumno.IdPais);
                cmd.Parameters.AddWithValue("@OtraColonia", alumno.OtraColonia1);
                cmd.Parameters.AddWithValue("@idMunicipioPlantel", alumno.IdMunicipioPlantel);
                cmd.Parameters.AddWithValue("@idPaisPlantel", alumno.IdPaisPlantel);
                cmd.Parameters.AddWithValue("@OtroPlantel", alumno.OtroPlantel1);
                cmd.Parameters.AddWithValue("@FechaRegistro", alumno.FechaRegistro1);
                cmd.Parameters.AddWithValue("@EmailValidado", alumno.EmailValido1);
                cmd.Parameters.AddWithValue("@idAlumno", alumno.IdAlumno);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Alumno ConsultarAlumno(int idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select Nombre, ApellidoPaterno, ApellidoMaterno, CURP, Sexo, Calle, NumeroExterior, NumeroInterior," +
                    " Email, Celular, Telefono, FOLIOSUREDSU, FolioSUREMS, idColonia, Nacionalidad, idMunicipio, idPais, ClavePlantelESEC," +
                    " idPlantelEMS from alumnos where idAlumno = @idAlumno";
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    alumno = new Alumno();
                    alumno.IdAlumno = idAlumno;
                    alumno.Nombre1 = reader["Nombre"].ToString();
                    alumno.ApellidoPaterno1 = reader["ApellidoPaterno"].ToString();
                    alumno.ApellidoMaterno1 = reader["ApellidoMaterno"].ToString();
                    alumno.CURP1 = reader["CURP"].ToString();
                    alumno.Sexo1 = reader["Sexo"].ToString();
                    alumno.Calle1 = reader["Calle"].ToString();
                    alumno.NumeroExterior1 = reader["NumeroExterior"].ToString();
                    alumno.NumeroInterior1 = reader["NumeroInterior"].ToString();
                    alumno.Email1 = reader["Email"].ToString();
                    alumno.Celular1 = reader["Celular"].ToString();
                    alumno.Telefono1 = reader["Telefono"].ToString();
                    alumno.FOLIOSUREDSU1 = reader["FOLIOSUREDSU"].ToString();
                    alumno.FolioSUREMS1 = reader["FolioSUREMS"].ToString();
                    alumno.Colonias = new Colonias(){
                        idColonia = Convert.ToInt32(reader["idColonia"].ToString()),
                        CP = reader["CP"].ToString(),
                        idMunicipio = Convert.ToInt32(reader["idMunicipio"].ToString()),
                        NombreColonia = reader["NombreColonia"].ToString()
                         };
                    alumno.Municipios = new Municipios()
                    {
                        idMunicipio = Convert.ToInt32(reader["idMunicipio"].ToString()),
                        idEstado = Convert.ToInt32(reader["idEstado"].ToString())
                        };
                    alumno.IdPais = Convert.ToInt32(reader["idPais"].ToString());
                    alumno.ClavePlantelESEC1 = reader["ClavePlantelESEC"].ToString();
                    alumno.IdPlantelEMS = Convert.ToInt32(reader["idPlantelEMS"].ToString());
                    alumno.Nacionalidad1 = reader["Nacionalidad"].ToString();
                }
                return alumno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int BuscarIdAlumnoCurp(string curp)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select idAlumno From alumnos where CURP = @curp";
                cmd.Parameters.AddWithValue("@curp", curp);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                int idAlumno = 0;
                if (reader.Read())
                {
                    idAlumno = Convert.ToInt32(reader["idAlumno"].ToString());
                }
                return idAlumno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}